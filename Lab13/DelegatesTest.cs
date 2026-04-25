using static System.Console;

namespace Lab13;

public class DelegatesTest
{
    delegate Complex UnaryOperation(Complex c);
    delegate Complex BinaryOperation(Complex с1, Complex c2); 
    delegate bool ComparisonOperation(Complex a, Complex b);

    public static void Main()
    {
        var c1 = new Complex(5, 10);
        var c2 = new Complex(20, 10);
        ComparisonOperation comparisonOp = (comp1, comp2) => comp1.GreaterThan(comp2);
        WriteLine("c1 > c2: " + comparisonOp(c1, c2));
        
        BinaryOperation subtractOp = (comp1, comp2) => comp1.Subtract(comp2);
        var subtractResult = subtractOp(new Complex(1, 1), new Complex(2, 2));
        WriteLine("Delegate subtract result: " + subtractResult);

        BinaryOperation addOp = (comp1, comp2) => comp1.Add(comp2);
        var addResult = addOp(new Complex(1, 1), new Complex(2, 2));
        WriteLine("Delegate add result: " + addResult);

        UnaryOperation incOp = (comp1) => comp1.Increment();
        var complex = new Complex(1, 1);
        var incResult = incOp(complex);
        WriteLine("Inc result: " + incResult);
        WriteLine("Complex number after inc: " + complex);

        UnaryOperation groupDel = incOp;
        groupDel += incOp;
        groupDel += incOp;
        var c3 = new Complex(1, 1);
        groupDel(c3);
        WriteLine("Group delegate result: " + c3);
    }
    
}