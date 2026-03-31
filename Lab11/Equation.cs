namespace Lab4;

public abstract class Equation
{
    public string Name { get; set; }
    protected Equation(string name)
    {
        Name = name;
    }

    public abstract void Solve();

}