/*
 Problem 1 – Easter
*/

internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string commands;
        while ((commands = Console.ReadLine()) != "Easter")
        {
            string[] arguments = commands.Split();

            string command = arguments[0];

            switch (arguments[0])
            {
                case "Replace":
                    string substring = arguments[1];
                    string replaceLetter = arguments[2];
                    input = input.Replace(substring, replaceLetter);
                    Console.WriteLine(input);
                    break;
                case "Remove":
                    int startIndex = input.IndexOf(arguments[1]);

                    if (startIndex < 0)
                    {
                        Console.WriteLine(input);
                        continue;
                    }
                    input = input.Remove(startIndex, arguments[1].Length);
                    Console.WriteLine(input);
                    break;
                case "Includes":
                    string wordInclude = arguments[1];
                    bool includes = input.Contains(wordInclude);
                    Console.WriteLine(includes);
                    break;
                case "Change":
                    if (arguments[1] == "Lower")
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                    else if (arguments[1] == "Upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                    break;
                case "Reverse":
                    int start = int.Parse(arguments[1]);
                    int end = int.Parse(arguments[2]);
                    if (start < 0 || end >= input.Length || start > end)
                    {
                        continue;
                    }
                    else
                    {
                        char[] charArray = input.ToCharArray();
                        Array.Reverse(charArray, start, end - start + 1);

                        string reversedString = new string(charArray);
                        string printSubstring = reversedString.Substring(int.Parse(arguments[1]), (int.Parse(arguments[2]) + 1));
                        Console.WriteLine(printSubstring);
                    }
                    break;
            }
        }
    }
}

