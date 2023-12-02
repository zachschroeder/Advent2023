namespace Advent.DayOne.DayOne;

public static class DayOneRefactor
{
    public static void Run()
    {
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
            Console.WriteLine($"Running sum: {sum}");

            line = sr.ReadLine();
        }

        Console.WriteLine();
        Console.WriteLine($"SUM: {sum}");
    }

    private static List<int> getNumsFromLine(string line)
    {
        List<int> nums = new List<int>();

        string[] threeLetterNums = new string[] { "one", "two", "six" };
        string[] fourLetterNums = new string[] { "four", "five", "nine" };
        string[] fiveLetterNums = new string[] { "three", "seven", "eight" };

        for (int i = 0; i < line.Length; i++)
        {
            char currentChar = line[i];

            if (char.IsDigit(currentChar))
                nums.Add((int)char.GetNumericValue(currentChar));

            else
            {
                try
                {

                    string threeSub = line.Substring(i, 3);
                    if (threeLetterNums.Contains(threeSub))
                    {
                        nums.Add(getIntFromLetters(threeSub));
                    }

                    string fourSub = line.Substring(i, 4);
                    if (fourLetterNums.Contains(fourSub))
                        nums.Add(getIntFromLetters(fourSub));

                    string fiveSub = line.Substring(i, 5);
                    if (fiveLetterNums.Contains(fiveSub))
                        nums.Add(getIntFromLetters(fiveSub));
                }
                catch (ArgumentOutOfRangeException) { }
            }


        }

        return nums;
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
}
