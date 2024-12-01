using AdventOfCode2024.Common;
using AdventOfCode2024.Console;

Console.WriteLine("Hello, World!");

var activatedPuzzleRecords = HappyPuzzleHelpers
	.DiscoverPuzzles()
	.TakeLast(4)
	.Take(1)
	.Select(x => new ActivatorRecord(x.Name, (HappyPuzzleBase) Activator.CreateInstance(x)!))
	.ToList();

foreach (var puzzleRecord in activatedPuzzleRecords)
{
	Console.WriteLine($"=== {puzzleRecord.Name} ".PadRight(80, '='));

	Console.WriteLine($"Reading input");
	var input = Helpers.GetInput(puzzleRecord.ActivatedPuzzle.AssetName);

	Console.WriteLine("Solving part 1...");
	Console.WriteLine(puzzleRecord.ActivatedPuzzle.SolvePart1(input));

	Console.WriteLine("\nSolving part 2...");
	Console.WriteLine(puzzleRecord.ActivatedPuzzle.SolvePart2(input));

	Console.WriteLine();
}