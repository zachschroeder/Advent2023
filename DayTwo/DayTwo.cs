namespace Advent.DayTwo;

public static class DayTwo
{
    public static void Run()
    {
        StreamReader sr = new StreamReader("C:/Users/Zach/Documents/Coding/Advent/DayTwo/DayTwoInput.txt");

        int gameIdSum = 0;

        var line = sr.ReadLine();

        while (line != null)
        {
            var sets = line.Split(";");

            var gameIdAndFirstSet = sets[0].Split(":");
            var gameIdString = gameIdAndFirstSet[0].Trim().Split(" ")[1];
            var gameId = int.Parse(gameIdString);

            sets[0] = gameIdAndFirstSet[1].Trim();

            if (isGameValid(sets))
                gameIdSum += gameId;

            line = sr.ReadLine();
        }

        Console.WriteLine($"SUM: {gameIdSum}");
    }

    private static bool isGameValid(string[] sets)
    {
        foreach(var set in sets )
        {
            if (!isSetValid(set.Trim()))
                return false;
        }

        return true;
    }

    private static bool isSetValid(string set)
    {
        int validRedNum = 12;
        int validGreenNum = 13;
        int validBlueNum = 14;

        int currentRed = 0;
        int currentGreen = 0;
        int currentBlue = 0;

        var handfuls = set.Split(",");

        foreach (var item in handfuls)
        {
            string cubeString = item.Trim().Split(" ")[0];
            int cubeNum = int.Parse(cubeString);

            if (item.Contains("red"))
                currentRed += cubeNum;
            else if (item.Contains("green"))
                currentGreen += cubeNum;
            else if (item.Contains("blue"))
                currentBlue += cubeNum;
            else
                throw new Exception("Color not found");
        }

        if (currentRed <= validRedNum &&
            currentGreen <= validGreenNum &&
            currentBlue <= validBlueNum)
            return true;

        return false;
    }
}
