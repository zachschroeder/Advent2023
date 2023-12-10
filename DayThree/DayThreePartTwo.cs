namespace Advent.DayThree;

public static class DayThreePartTwo
{
    public static void Run()
    {
        StreamReader sr = new StreamReader("C:/Users/Zach/Documents/Coding/Advent/DayThree/DayThreeInput.txt");

        var topLine = "";
        var currentLine = sr.ReadLine();
        var bottomLine = sr.ReadLine();

        int sum = 0;

        while (currentLine != null)
        {
            for (int i = 0; i < currentLine.Length; i++)
            {
                char currentChar = currentLine[i];

                if (currentChar == '*')
                {
                    // Get potential indices to check
                    var indicesToCheck = Enumerable.Range(i - 1, 3);
                    if (i == 0)
                        indicesToCheck = Enumerable.Range(i, 2);
                    else if (i == currentLine.Length - 1)
                        indicesToCheck = Enumerable.Range(i - 1, 2);

                    List<int> adjacentNumbers = new();

                    // Check left of *
                    if (i > 0 && char.IsDigit(currentLine[i - 1]))
                    {
                        int num = getFullNumber(i - 1, currentLine).Number;
                        adjacentNumbers.Add(num);
                    }

                    // Check right of *
                    if (i < currentLine.Length && char.IsDigit(currentLine[i + 1]))
                    {
                        int num = getFullNumber(i + 1, currentLine).Number;
                        adjacentNumbers.Add(num);
                    }

                    // Check topLine and bottomLine
                    adjacentNumbers.AddRange(getAdjacentLineNumbers(topLine, indicesToCheck));
                    adjacentNumbers.AddRange(getAdjacentLineNumbers(bottomLine, indicesToCheck));

                    if (adjacentNumbers.Count == 2)
                    {
                        sum += (adjacentNumbers[0] * adjacentNumbers[1]);
                    }
                }
            }

            topLine = currentLine;
            currentLine = bottomLine;
            bottomLine = sr.ReadLine();
        }

        Console.WriteLine($"SUM: {sum}");

    }

    private static IEnumerable<int> getAdjacentLineNumbers(string line, IEnumerable<int> indicesToCheck)
    {
        List<int> adjacentNumbers = new();

        List<int> alreadyCheckedIndices = new();

        foreach (var index in indicesToCheck)
        {
            if (char.IsDigit(line[index]) && !alreadyCheckedIndices.Contains(index))
            {
                NumberLocationResult result = getFullNumber(index, line);

                adjacentNumbers.Add(result.Number);
                var justCheckedIndices = Enumerable.Range(result.StartingIndex, result.LengthOfNumber);
                alreadyCheckedIndices.AddRange(justCheckedIndices);
            }
        }

        return adjacentNumbers;
    }

    /// <summary>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="line"></param>
    /// <returns><see cref="NumberLocationResult"/> representing the full number that has a digit in line[index]</returns>
    private static NumberLocationResult getFullNumber(int index, string line)
    {
        int startingIndex = index;
        int endingIndex = index;

        while (startingIndex > 0 && char.IsDigit(line[startingIndex - 1]))
            startingIndex--;
        while (endingIndex < line.Length - 1 && char.IsDigit(line[endingIndex + 1]))
            endingIndex++;

        int lengthOfNumber = endingIndex - startingIndex + 1;
        int num = int.Parse(line.Substring(startingIndex, lengthOfNumber));

        return new NumberLocationResult(num, startingIndex, lengthOfNumber);
    }

    private class NumberLocationResult
    {
        public int Number;
        public int StartingIndex;
        public int LengthOfNumber;

        public NumberLocationResult(int number, int startingIndex, int lengthOfNumber)
        {
            this.Number = number;
            this.StartingIndex = startingIndex;
            this.LengthOfNumber = lengthOfNumber;
        }
    }
}
