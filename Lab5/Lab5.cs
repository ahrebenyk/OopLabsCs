using System.Text;
using static System.Console;

namespace Lab4;

public class Lab5
{
    public static void Main()
    {
        var inputFilePath = "C:/Users/artem/files/input.txt";
        var outputFilePath = "C:/Users/artem/files/output.txt";
        OutputEncoding = Encoding.UTF8;
        var result = GetWordFromFile(inputFilePath);
        WriteLine("Writing to file: " + result);
        WriteToFile(outputFilePath, result);
    }

    static string GetWordFromFile(string fileName)
    {
        using var reader = new StreamReader(fileName);
        var line = reader.ReadLine();
        if (line == null)
        {
            return "";
        }
        StringBuilder result = new StringBuilder();
        line.Split(' ')
            .ToList()
            .ForEach(word => result.Append(word.FirstOrDefault()));
        return result.ToString();
    }
    
    static void WriteToFile(string fileName, string content)
    {
        using var writer = new StreamWriter(fileName, false);
        writer.Write(content);
    }

}