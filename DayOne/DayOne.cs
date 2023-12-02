namespace Advent.DayOne.DayOne;

public static class DayOne
{
    public static void Run()
    {
        DateTime startTime = DateTime.UtcNow;

        StreamReader sr = new("C:/Users/Zach/Documents/Coding/Advent/DayOne/DayOneInput.txt");
        var line = sr.ReadLine();

        int sum = 0;

        while (line != null)
        {
            // Only used for part two
            line = translateSpelledOutNums(line);

            int firstNum = getFirstNum(line);
            firstNum = firstNum * 10;

            int secondNum = getSecondNum(line);

            int lineSum = firstNum + secondNum;
            sum += lineSum;

            line = sr.ReadLine();
        }

        DateTime endTime = DateTime.UtcNow;
        TimeSpan duration = endTime - startTime;

        Console.WriteLine($"SUM: {sum}");
        Console.WriteLine($"Time: {duration.TotalSeconds}");
    }

    // Only used for part two
    private static string translateSpelledOutNums(string line)
    {
        string[] threeLetterNums = new string[] { "one", "two", "six" };
        string[] fourLetterNums = new string[] { "four", "five", "nine" };
        string[] fiveLetterNums = new string[] { "three", "seven", "eight" };


        int startIndex = 0;

        while (startIndex < line.Length - 2)
        {
            try
            {
                string threeSub = line.Substring(startIndex, 3);
                if (threeLetterNums.Contains(threeSub))
                {
                    line = line.Substring(0, startIndex) + getIntFromLetters(threeSub) + line.Substring(startIndex + 1);
                }

                string fourSub = line.Substring(startIndex, 4);
                if (fourLetterNums.Contains(fourSub))
                {
                    line = line.Substring(0, startIndex) + getIntFromLetters(fourSub) + line.Substring(startIndex + 1);
                }

                string fiveSub = line.Substring(startIndex, 5);
                if (fiveLetterNums.Contains(fiveSub))
                {
                    line = line.Substring(0, startIndex) + getIntFromLetters(fiveSub) + line.Substring(startIndex + 1);
                }
            }
            catch (ArgumentOutOfRangeException ex) { }

            startIndex++;
        }

        return line;
    }

    private static int getIntFromLetters(string letters)
    {
        switch (letters)
        {
            case "one":
                return 1;
            case "two":
                return 2;
            case "three":
                return 3;
            case "four":
                return 4;
            case "five":
                return 5;
            case "six":
                return 6;
            case "seven":
                return 7;
            case "eight":
                return 8;
            case "nine":
                return 9;
        }

        throw new Exception("Number not in list");
    }

    private static int getFirstNum(string line)
    {
        foreach (char c in line)
        {
            if (char.IsDigit(c))
                return int.Parse(c.ToString());
        }
        throw new Exception("Couldn't find first num");
    }

    private static int getSecondNum(string line)
    {
        var reverseLine = line.AsEnumerable().Reverse();

        foreach (char c in reverseLine)
        {
            if (char.IsDigit(c))
                return int.Parse(c.ToString());
        }
        throw new Exception("Couldn't find second num");
    }
}
