using System.Reflection;

namespace Smakownia.Basket.Application;

public class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}
