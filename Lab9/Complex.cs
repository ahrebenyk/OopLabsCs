namespace Lab4;

public class Complex
{
    private double _real;
    private double _imaginary;

    public Complex()
    {
        _real = 0;
        _imaginary = 0;
    }

    public Complex(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }

    public Complex(double real)
    {
        _real = real;
    }

    public Complex(Complex other)
    {
        _real = other._real;
        _imaginary = other._imaginary;
    }

    public Complex Add(Complex other)
    {
        return new Complex(_real + other._real, _imaginary + other._imaginary);
    }

    public Complex Subtract(Complex other)
    {
        return new Complex(_real - other._real, _imaginary - other._imaginary);
        
    }

    public Complex Multiply(Complex other)
    {
        var resReal = _real * other._real - _imaginary * other._imaginary;
        var resImaginary = _real * other._imaginary + _imaginary * other._real;
        return new Complex(resReal, resImaginary);
    }

    public override string ToString()
    {
        var sign = _imaginary >= 0 ? "+" : "-";
        return $"{_real} {sign} {Math.Abs(_imaginary)}i";
    }
}