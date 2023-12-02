namespace Advent.DayOne.DayOne;

public static class DayOneRefactor
{
    public static void Run()
    {
        DateTime startTime = DateTime.UtcNow;

        StreamReader sr = new("C:/Users/Zach/Documents/Coding/Advent/DayOne/DayOneInput.txt");
        var line = sr.ReadLine();

        int sum = 0;

        while (line != null)
        {
            List<int> numsFromLine = getNumsFromLine(line);

            int firstNum = numsFromLine.First() * 10;
            int secondNum = numsFromLine.Last();
            int lineSum = firstNum + secondNum;

            sum += lineSum;

            line = sr.ReadLine();
        }

        DateTime endTime = DateTime.UtcNow;
        TimeSpan duration = endTime - startTime;

        Console.WriteLine($"SUM: {sum}");
        Console.WriteLine($"Time: {duration.TotalSeconds}");
    }

    private static List<int> getNumsFromLine(string line)
    {
        List<int> nums = new List<int>();

        for (int i = 0; i < line.Length; i++)
        {
            char currentChar = line[i];

            if (char.IsDigit(currentChar))
                nums.Add((int)char.GetNumericValue(currentChar));

            else
            {
                try
                {
                    int potentialNum = getPotentialNum(i, line);

                    if(potentialNum != -1)
                        nums.Add(potentialNum);
                }
                catch (ArgumentOutOfRangeException) { }
            }
        }

        return nums;
    }

    private static int getPotentialNum(int index, string line)
    {
        string threeSub = line.Substring(index, 3);
        switch(threeSub)
        {
            case "one":
                return 1;
            case "two":
                return 2;
            case "six":
                return 6;
        }

        string fourSub = line.Substring(index, 4);
        switch(fourSub)
        {
            case "four":
                return 4;
            case "five":
                return 5;
            case "nine":
                return 9;
        }

        string fiveSub = line.Substring(index, 5);
        switch (fiveSub)
        {
            case "three":
                return 3;
            case "seven":
                return 7;
            case "eight":
                return 8;
        }

        return -1;
    }
}
