using System.Text;
using static System.Console;

namespace Lab4;

public class Lab7
{
    public static void Main()
    {
        WriteLine("enter real and imaginary part of complex1");
        var r1 = double.Parse(ReadLine());
        var i1 = double.Parse(ReadLine());
        var complex1 = new Complex(r1, i1);
        
        WriteLine("enter real and imaginary part of complex2");
        var r2 = double.Parse(ReadLine());
        var i2 = double.Parse(ReadLine());
        var complex2 = new Complex(r2, i2);

        WriteLine("complex1 = " + complex1);
        WriteLine("complex2 = " + complex2);
        WriteLine("complex1 + complex2 = " + complex1.Add(complex2));
        WriteLine("complex1 - complex2 = " + complex1.Subtract(complex2));
        WriteLine("complex1 * complex2 = " + complex1.Multiply(complex2));
    }
    
}