namespace Lab13;

public class Complex(double re, double im) : IArithmetic, IComparable
{
    private double Re { get; set; } = re;
    private double Im { get; set; } = im;

    public Complex Add(Complex other)
    {
        return new Complex(Re + other.Re, Im + other.Im);
    }

    public Complex Subtract(Complex other)
    {
        return new Complex(Re - other.Re, Im - other.Im);
    }

    public Complex Multiply(Complex other)
    {
        var resReal = Re * other.Re - Im * other.Im;
        var resImaginary = Re * other.Im + Im * other.Re;
        return new Complex(resReal, resImaginary);
    }

    public int Compare(Complex other)
    {
        var m1 = GetAbsSqr();
        var m2 = other.GetAbsSqr();

        if (m1 > m2) return 1;
        if (m1 < m2) return -1;
        return 0;       
    }

    public Complex Increment()
    {
        var beforeUpdate = new Complex(Re, Im);
        Re++;
        Im++;
        return beforeUpdate;
    }
    
    public bool GreaterThan(Complex other)
    {
        return Compare(other) == 1;
    }
    
    private double GetAbsSqr() => Re * Re + Im * Im;

    public override string ToString()
    {
        var sign = Im >= 0 ? "+" : "-";
        return $"{Re} {sign} {Math.Abs(Im)}i";
    }
}