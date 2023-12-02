namespace Advent.DayTwo;

public static class DayTwoPartTwo
{
    public static void Run()
    {
        StreamReader sr = new StreamReader("C:/Users/Zach/Documents/Coding/Advent/DayTwo/DayTwoInput.txt");

        int powerSum = 0;

        var line = sr.ReadLine();

        while (line != null)
        {
            var sets = line.Split(";");

            var gameIdAndFirstSet = sets[0].Split(":");
            sets[0] = gameIdAndFirstSet[1];

            var minColorNums = getMinColorNums(sets);

            var powerOfSet = minColorNums[0] * minColorNums[1] * minColorNums[2];
            powerSum += powerOfSet;

            line = sr.ReadLine();
        }

        Console.WriteLine($"SUM: {powerSum}");
    }

    private static int[] getMinColorNums(string[] sets)
    {
        int minRedNum = 0;
        int minGreenNum = 0;
        int minBlueNum = 0;

        foreach (var set in sets )
        {
            var currentColorNums = getColorNums(set);

            minRedNum = Math.Max(minRedNum, currentColorNums[0]);
            minGreenNum = Math.Max(minGreenNum, currentColorNums[1]);
            minBlueNum = Math.Max(minBlueNum, currentColorNums[2]);
        }

        return new int[3] { minRedNum, minGreenNum, minBlueNum };
    }

    private static int[] getColorNums(string set)
    {
        int currentRed = 0;
        int currentGreen = 0;
        int currentBlue = 0;

        var handfuls = set.Split(",");

        foreach (var item in handfuls)
        {
            string cubeString = item.Trim().Split(" ")[0];
            int cubeNum = int.Parse(cubeString);

            if (item.Contains("red"))
                currentRed = cubeNum;
            else if (item.Contains("green"))
                currentGreen = cubeNum;
            else if (item.Contains("blue"))
                currentBlue = cubeNum;
            else
                throw new Exception("Color not found");
        }

        return new int[3] { currentRed, currentGreen, currentBlue };
    }
}
