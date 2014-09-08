# New Features in C# 6.0 #

This is a [series of blog posts](http://www.alteridem.net) on the new features that are coming in C# 6.0. 

If you want to try out any of these features now, check out the <a href="https://roslyn.codeplex.com/">Rosyln compiler</a> and then install the latest CTP of <a href="http://www.visualstudio.com/en-us/downloads/visual-studio-14-ctp-vs.aspx">Visual Studio 14</a> or fire up a <a href="http://blogs.msdn.com/b/visualstudioalm/archive/2014/06/04/visual-studio-14-ctp-now-available-in-the-virtual-machine-azure-gallery.aspx">VM in Azure with Visual Studio 14</a> already installed.

To enable the new language features in Visual Studio 14, you will need to hand edit your project file and add the following line to each of the configuration sections,

```XML
<LangVersion>experimental</LangVersion>
```

When you are done, it should look like this,

```XML
<PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <LangVersion>experimental</LangVersion>
</PropertyGroup>
```

## Primary Constructors ##

Previous releases of C# were centered around enabling new language features such as async support in C# 5.0 or Linq in C# 3.0. If I was to pick a theme for C# 6.0, I would say that it is around developer productivity. Most of the features are conveniences that allow you to write code more succinctly and clearly. Primary Constructors are one such feature.

Primary Constructors allow you to declare a constructor and parameters directly on the body of the class or struct instead of explicitly declaring it within the body of the class or struct. For example, prior to C# 6.0 you would write a constructor with parameters like this;

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

There is a fair amount of redundant code in this example. I am creating member variables, assigning them from the parameters of the constructor and returning them from the properties. C# 6.0 simplifies this;

```C#
public class Employee(string name, string department, decimal salary)
{
    public string Name { get; } = name;
    public string Department { get; } = department;
    public decimal Salary { get; } = salary;
}
```

Notice that we no longer have a constructor, it is inline with the class declaration. We also do not have to declare the member variables, the constructor parameters are in scope everywhere within the class. Also, notice the properties are using the new Auto-property initializer syntax which I will cover in my next post.

### Primary Constructor Bodies ###

If you need to add functionality or validation to the Primary Constructor, you do it by adding a body to the Primary Constructor as follows;

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

 You can still add additional constructors to a class with a Primary Constructor, but those constructors must chain to the Primary Constructor by calling the <strong>this</strong> initializer like this;

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

A Primary Constructor must always implicitly or explicitly call a base initializer. If you do not explicitly call a base constructor, it will call the parameterless base constructor. To explicitly call a base constructor, you do it like this;

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