using static System.Console;

namespace Lab4;

public static class EquationTest
{
    public static void Main()
    {
        OutputEncoding = System.Text.Encoding.UTF8;
        Equation equationWithTwoSolutions = new QuadraticEquation(1, 3, -10);
        equationWithTwoSolutions.Solve();
        
        Equation equationWithOneSolution = new QuadraticEquation(1, -4, 4);
        equationWithOneSolution.Solve();
        
        Equation equationWithNoRealSolutions = new QuadraticEquation(1, 3, 3);
        equationWithNoRealSolutions.Solve();
    }
    
}