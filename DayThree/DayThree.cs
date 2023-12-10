using System.Globalization;

namespace Advent.DayThree;

public static class DayThree
{
    public static void Run()
    {
        StreamReader sr = new StreamReader("C:/Users/Zach/Documents/Coding/Advent/DayThree/DayThreeInput.txt");

        var topLine = "";
        var currentLine = sr.ReadLine();
        var bottomLine = sr.ReadLine();

        int sum = 0;

        // ISSUE: NOT READING FIRST LINE
        // Otherwise, perfect on sample data

        while (currentLine != null)
        {
            for (int i = 0; i < currentLine.Length; i++)
            {
                char currentChar = currentLine[i];

                if (char.IsDigit(currentChar))
                {
                    // Get whole valid number
                    int indexOfLastDigit = getLastDigitIndex(currentLine, i);
                    int lengthOfNumber = indexOfLastDigit - i + 1;
                    string numberString = currentLine.Substring(i, lengthOfNumber);

                    int validNum = int.Parse(numberString);

                    bool isPartNumber = checkPartNumber(currentLine, topLine, bottomLine, i, indexOfLastDigit);

                    if (isPartNumber)
                    {
                        sum += validNum;
                        Console.WriteLine($"ADDED {numberString}");
                    }

                    i = indexOfLastDigit;
                }
            }

            topLine = currentLine;
            currentLine = bottomLine;
            bottomLine = sr.ReadLine();
        }

        Console.WriteLine($"SUM: {sum}");

    }

    private static bool checkPartNumber(string currentLine, string topLine, string bottomLine, int indexOfFirstDigit, int indexOfLastDigit)
    {
        // Check left on current line
        if (indexOfFirstDigit > 0 && isValidSymbol(currentLine[indexOfFirstDigit - 1]))
        {
            return true;
        }
        // Check right on current line
        else if (indexOfLastDigit + 1 < currentLine.Length && isValidSymbol(currentLine[indexOfLastDigit + 1]))
        {
            return true;
        }
        // Check top and bottom line
        else
        {
            int lengthOfNumber = indexOfLastDigit - indexOfFirstDigit + 1;
            var validAdjacentLineIndices = Enumerable.Range(indexOfFirstDigit - 1, lengthOfNumber + 2);

            return checkAdjacentLine(validAdjacentLineIndices, topLine) || checkAdjacentLine(validAdjacentLineIndices, bottomLine);
        }
    }

    // Returns true if any of adjacentLine[index] char is a valid symbol
    private static bool checkAdjacentLine(IEnumerable<int> validAdjacentLineIndices, string adjacentLine)
    {
        if (string.IsNullOrEmpty(adjacentLine))
            return false;

        foreach (var index in validAdjacentLineIndices)
        {
            if (index > 0 && index < adjacentLine.Length && isValidSymbol(adjacentLine[index]))
                return true;
        }

        return false;
    }

    private static int getLastDigitIndex(string line, int i)
    {
        while (i < line.Length && char.IsDigit(line[i]))
            i++;

        return i-1;
    }

    private static bool isValidSymbol(char c)
    {
        switch (c)
        {
            case '+': return true;
            case '-': return true;
            case '*': return true;
            case '/': return true;
            case '%': return true;
            case '=': return true;
            case '$': return true;
            case '&': return true;
            case '#': return true;
            case '@': return true;
        }

        return false;
    }
}
