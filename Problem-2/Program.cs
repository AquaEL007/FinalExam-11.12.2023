/*
 ^(?<name>[A-Z][a-z]{2,}\s[A-Z][a-z]{2,})\#+(?<job>[A-Z][a-z]+(?:&[A-Z][a-z]+){0,2})\d*(?<company>([A-Z][a-z\d]+)\s+(JSC|Ltd\.))
 */
using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        int inputsNumber = int.Parse(Console.ReadLine());
        string pattern = @"^(?<name>[A-Z][a-z]{2,}\s[A-Z][a-z]{2,})\#+(?<job>[A-Z][a-z]+(?:&[A-Z][a-z]+){0,2})\d*(?<company>([A-Z][a-z\d]+)\s+(JSC|Ltd\.))";     

        string input = "";
        for (int i = 0; i < inputsNumber; i++)
        {
            input = Console.ReadLine();

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string employeeName = match.Groups["name"].Value;
                string jobPosition = match.Groups["job"].Value.Replace("&", " ");
                string companyName = match.Groups["company"].Value;

                Console.WriteLine($"{employeeName} is {jobPosition} at {companyName}");
            }
            else
            {
                continue;
            }
            
        }
    }
}

