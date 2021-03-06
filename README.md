# New Features in C# 6.0 #

This is a [series of blog posts](http://www.alteridem.net/category/net/csharp/csharp-60/) 
on the new features that are coming in C# 6.0. 

If you want to try out any of these features now, check out the 
[Rosyln compiler](https://roslyn.codeplex.com/) and then install the [Visual 
Studio 2015 Preview](http://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs) 
or fire up a VM in Azure with Visual Studio 2015 Preview already installed.

## Primary Constructors ##

### UPDATE ###

[It was decided](https://roslyn.codeplex.com/discussions/568820) that Primary Constructors 
would not make it into the final release of C# 6.0 and they no longer work in Visual Studio 
2015 Preview.

Previous releases of C# were centered around enabling new language features such as async 
support in C# 5.0 or Linq in C# 3.0. If I was to pick a theme for C# 6.0, I would say that 
it is around developer productivity. Most of the features are conveniences that allow you 
to write code more succinctly and clearly. Primary Constructors are one such feature.

Primary Constructors allow you to declare a constructor and parameters directly on the body 
of the class or struct instead of explicitly declaring it within the body of the class or 
struct. For example, prior to C# 6.0 you would write a constructor with parameters like this;

```C#
public class Employee
{
    private string _name;
    private string _department;
    private decimal _salary;

    public Employee(string name, string department, decimal salary)
    {
        _name = name;
        _department = department;
        _salary = salary;
    }

    public string Name { get { return _name; } }
    public string Department { get { return _department; } }
    public decimal Salary { get { return _salary; } }
}
```

There is a fair amount of redundant code in this example. I am creating member variables, 
assigning them from the parameters of the constructor and returning them from the 
properties. C# 6.0 simplifies this;

```C#
public class Employee(string name, string department, decimal salary)
{
    public string Name { get; } = name;
    public string Department { get; } = department;
    public decimal Salary { get; } = salary;
}
```

Notice that we no longer have a constructor, it is inline with the class declaration. We also 
do not have to declare the member variables, the constructor parameters are in scope everywhere 
within the class. Also, notice the properties are using the new Auto-property initializer 
syntax which I will cover in my next post.

### Primary Constructor Bodies ###

If you need to add functionality or validation to the Primary Constructor, you do it by adding 
a body to the Primary Constructor as follows;

```C#
public class Employee(string name, string department, decimal salary)
{
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name cannot be null or empty");
    }
    public string Name { get; } = name;
    public string Department { get; } = department;
    public decimal Salary { get; } = salary;
}
```

### Explicit Constructors ###

 You can still add additional constructors to a class with a Primary Constructor, but those constructors
 must chain to the Primary Constructor by calling the <strong>this</strong> initializer like this;

```C#
public class Employee(string name, string department, decimal salary)
{
    public Employee(string name) : this(name, "Intern", 10000)
    {
    }

    public string Name { get; } = name;
    public string Department { get; } = department;
    public decimal Salary { get; } = salary;
}
```

### Base Initializer ###

A Primary Constructor must always implicitly or explicitly call a base initializer. If you do not 
explicitly call a base constructor, it will call the parameterless base constructor. To explicitly 
call a base constructor, you do it like this;

```C#
public class Person(string name)
{
    public string Name { get; } = name;
}

public class Employee(string name, string department, decimal salary) : Person(name)
{
    public string Department { get; } = department;
    public decimal Salary { get; } = salary;
}
```

## Auto-Property Changes ##

There have been a few small improvements to Auto-Properties.

### Auto-Property Initializers ###

Auto-Properties were introduced way back in C# 3.0, but unlike other members, you had to 
initialize their values in the constructor.

```C#
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product()
    {
        Name = "Toy Car";
        Price = 9.99m;
    }
}
```

In C# 6.0, you can initialize the properties where they are declared.

```C#
public class Product
{
    public string Name { get; set; } = "Toy Car";
    public decimal Price { get; set; } = 9.99m;
}
```

### Getter Only Auto-Properties ###

You could always declare the setter of an auto-property private or protected to prevent 
it from being used outside of the class.

```C#
public decimal Price { get; private set; }
```

Now you can omit the setter and it makes the underlying field read-only, so you can only 
set it in the constructor, or in an auto-property initializer. This is a great feature for 
creating and enforcing imutable classes.

```C#
public class Product
{
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; }
    public decimal Price { get; }
}
```

## Null-Conditional Operators ##

This is one of my favourite new features. Have you ever written code like this?

```C#
if (line != null && line.Product != null)
{
    total += line.Product.Price * line.Quantity;
}
```

C# 6.0 introduces the ?. null-conditional operator that short circuits and returns null if 
anything in the chain is null. This combines really well with the 
[null-coalescing](http://www.alteridem.net/2007/08/17/null-coalescing-operator/) operator 
allowing you to rewrite the above as follows.

```C#
total += line?.Product?.Price ?? 0 * line?.Quantity ?? 0;
```

This also works with indexers,

```C#
var firstProduct = OrderLines?[0].Product;	// Will return null if OrderLines is null
```

It also works with methods. This will be really handy for triggering events. Instead of writing,

```C#
if (OrderChanged != null)
{
    OrderChanged(this, EventArgs.Empty);
}
```

You will now be able to write.

```C#
OrderChanged?.Invoke(this, EventArgs.Empty);
```

## Declaration Expressions ###

### UPDATE ###

[It was decided](https://roslyn.codeplex.com/discussions/568820) that Declaration Expressions 
would not make it into the final release of C# 6.0 and they no longer work in Visual Studio 
2015 Preview.

This is a complex name for a simple concept. Until now, if you ever wanted to use an out 
parameter in a method, you had to declare it before using it.

We've all written code like this,

```C#
int i;
if (Int32.TryParse(value, out i))
{
    // Use i here
}
```

Now you can write the much simpler,

```C#
if (Int32.TryParse(value, out var i))
{
    Assert.That(i, Is.EqualTo(expected));
}
```

There are a couple of things to note here. First is that `i` is only in scope within 
the `if` statement. You cannot use it outside the `if` statement. Second, notice that 
I used `var` and that the type was correctly infered as int.

It is also useful for casting. You no longer have to cast an object as something, then 
check if it is null. You can now do it all within the if statement.

```C#
if ((string str = obj as string) != null )
{
    Console.WriteLine(str);
}
```

It can also be useful for quickly supplying default args for a `TryParse`.

```C#
int x = Int32.TryParse(value, out var i) ? i : -1;
```

Sweet and simple...

## String Interpolation ##

String interpolation in C# is fairly easy if you only have a couple of 
arguments, but it can be error prone with many arguments or if you need 
to re-order the arguments. It is also difficult to quickly see which
variable gets substituted in where.

Currently, we write code like this,

```C#
var msg = string.Format("You ordered {0} {1}{{s}}", line.Quantity, line.Product.Name);
```

C# 6.0 makes this easier. You can ommit the `String.format` and put the variables right
in the curly braces. Notice the slash at the start.

```C#
var msg = "You ordered \{line.Quantity} \{line.Product.Name}{s}";
```

Notice that pesky improper pluralization though. It was always a pain to
deal with. Now, just put the code you need inline.

```C#
var msg = "You ordered \{line.Quantity} \{line.Product.Name}\{line.Quantity > 1 ? "s" : ""}";
```

The syntax currently uses a slash before the brace. In a later update, it will be
switching to a dollar sign before the first quote and no slash, like this,


```C#
var msg = $"You ordered {line.Quantity} {line.Product.Name}{s}";
```