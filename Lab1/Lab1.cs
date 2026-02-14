using System.Text;
using static System.Console;

namespace OopLabsCs;

class Lab1
{
    private const double VacuumPermittivity = 8.8541878128e-12;
    private const double Pi = 3.141592653589793;

    public static void Main()
    {
        OutputEncoding = Encoding.UTF8;
        WriteLine("Введіть одиниці вимірювання заряду: мкКл, мКл, Кл");
        var chargeUnit = ReadChargeUnit();
        
        WriteLine("Введіть початковий заряд, кінцевий заряд та величину кроку, " + chargeUnit);
        var chargeStart = ReadDouble();
        var chargeEnd = ReadDouble();
        var chargeStep = ReadDouble();

        WriteLine("Введіть початкову відстань, кінцеву відстань та величину кроку, м");
        var distanceStart = ReadDouble();
        var distanceEnd = ReadDouble();
        var distanceStep = ReadDouble();

        WriteLine("Введіть діелектричну проникність середовища");
        var relativePermittivity = ReadDouble();

        WriteLine("Введіть мінімальне та максимальне значення для виділення в таблиці");
        var highlightMin = ReadDouble();
        var highlightMax = ReadDouble();
        
        WriteLine("Введіть точність вимірювання");
        var precision = int.Parse(ReadLine());
        
        var charges = GenerateValues(chargeStart, chargeEnd, chargeStep);
        var distances = GenerateValues(distanceStart, distanceEnd, distanceStep);
        PrintTable(charges, distances, chargeUnit, relativePermittivity, highlightMin, highlightMax, precision);
    }

    private static double ReadDouble()
    {
        return double.Parse(ReadLine());
    }

    private static string ReadChargeUnit()
    {
        var chargeUnit = ReadLine();
        if (chargeUnit is "мкКл" or "мКл")
        {
            return chargeUnit;
        }
        return "Кл";
    }

    private static double[] GenerateValues(double start, double end, double step)
    {
        var size = (int) Math.Floor((end - start) / step) + 1;
        var result = new double[size];
        var current = start;
        for (int i = 0; i < size; i++)
        {
            result[i] = current;
            current += step;
        }
        return result;
    }

    private static void PrintTable(double[] charges, double[] distances, string chargeUnit,
        double relativePermittivity, double highlightMin, double highlightMax, int precision)
    {
        PrintHeader(charges, chargeUnit);

        var factor = GetFactor(chargeUnit);
        foreach (var distance in distances)
        {
            PrintRow(distance, charges, factor, relativePermittivity, highlightMin, highlightMax, precision);
        }
    }

    private static void PrintHeader(double[] charges, string chargeUnit)
    {
        ForegroundColor = ConsoleColor.DarkBlue;
        Write("\t");
        foreach (var c in charges)
        {
            Write(c + chargeUnit + "\t\t");
        }
        WriteLine();
        ResetColor();
    }

    private static void PrintRow(double distance, double[] charges, double factor, double relativePermittivity, double highlightMin, double highlightMax, int precision)
    {
        ForegroundColor = ConsoleColor.DarkBlue;
        Write(distance + "м\t");
        ResetColor();
        
        foreach (var charge in charges)
        {
            var potential = CalculatePotential(distance, charge * factor, relativePermittivity);
            if (potential < highlightMax && potential > highlightMin)
            {
                ForegroundColor = ConsoleColor.DarkRed;
            }
            Write(potential.ToString("E" + precision) + "\t");
            ResetColor();
        }
        WriteLine();
    }

    private static double CalculatePotential(double distance, double charge, double relativePermittivity)
    {
        return charge / (4 * Pi * VacuumPermittivity * relativePermittivity * distance);
    }

    private static double GetFactor(string chargeUnit)
    {
        return chargeUnit switch
        {
            "мкКл" => 0.000001,
            "мКл" => 0.001,
            _ => 1.0
        };
    }
}