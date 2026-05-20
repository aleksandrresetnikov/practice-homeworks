using System.Globalization;
using System.Text;

namespace Types_Task1;

public sealed class Program
{
    public static void Main(string[] args)
    {
        string result = GetCompoundInterest(1000, 3, 10);
        Console.WriteLine(result);
    }

    public static string GetCompoundInterest(double initialDeposit, int years, double interestRate)
    {
        StringBuilder resultBuilder = new StringBuilder();
        double currentAmount = initialDeposit;

        for (int year = 1; year <= years; year++)
        {
            currentAmount += currentAmount * (interestRate / 100.0);
            
            resultBuilder.AppendLine($"Год {year}: {currentAmount.ToString("F2", CultureInfo.InvariantCulture)} руб.");
        }

        return resultBuilder.ToString().TrimEnd();
    }
}