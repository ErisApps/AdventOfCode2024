namespace AdventOfCode2024.Common;

public static class Helpers
{
	public static Input GetInput(string inputFilename)
	{
		var path = Path.Combine("Assets", inputFilename);
		var inputText = File.ReadAllText(path);
		var inputLines = File.ReadAllLines(path);
		var inputEnumerable = inputLines.AsEnumerable();
		return new(inputText, inputLines, inputEnumerable);
	}
}