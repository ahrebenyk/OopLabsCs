using static System.Console;

namespace Lab4;

public class ComplexTest
{
    public static void Main()
    {
        var defaultValue = new Complex();
        WriteLine("defaultValue = " + defaultValue);

        var realValue = new Complex(11.0);
        WriteLine("real value = " + realValue);
        
        var complexValue = new Complex(11.0, 23.1);
        WriteLine("initialized value = " + complexValue);
        
        var copiedValue = new Complex(complexValue);
        WriteLine("Copied value = " + copiedValue);
   }
    
}