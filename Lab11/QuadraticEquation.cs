namespace Lab4;
using static Console;
using static Math;

public class QuadraticEquation : Equation
{
    private double A { get; }
    private double B { get; }
    private double C { get; }
    
    public QuadraticEquation(double a, double b, double c) : base("QuadraticEquation")
    {
        A = a;
        B = b;
        C = c;
    }

    public override void Solve()
    {
        if (A == 0)
        {
            WriteLine("A не може дорівнювати 0");
            return;
        }

        var discriminant = Pow(B, 2) - 4 * A * C;
        WriteLine($"Дискримінант = {discriminant}");

        switch (discriminant)
        {
            case > 0:
            {
                var x1 = (-B + Sqrt(discriminant)) / (2 * A);
                var x2 = (-B - Sqrt(discriminant)) / (2 * A);
                WriteLine($"Рівняння має два корені: x1 = {x1}, x2 = {x2}");
                break;
            }
            case 0:
            {
                var x = -B / (2 * A);
                WriteLine($"Рівняння має один корінь: x = {x}");
                break;
            }
            default:
                WriteLine("Рівняння не має дійсних коренів.");
                break;
        }
    }    
}