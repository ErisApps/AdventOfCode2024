using AdventOfCode2024.Common;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode2024.Benchmarks;

[MemoryDiagnoser(true)]
[CategoriesColumn, AllStatisticsColumn, BaselineColumn, MinColumn, Q1Column, MeanColumn, Q3Column, MaxColumn, MedianColumn]
public class HappyPuzzleBaseBenchmark<TPuzzle> where TPuzzle : HappyPuzzleBase, new()
{
	private readonly TPuzzle _sub;
	private readonly Input _input;

	public HappyPuzzleBaseBenchmark()
	{
		_sub = new TPuzzle();
		_input = Helpers.GetInput(_sub.AssetName);
	}

	[Benchmark]
	[BenchmarkCategory(Constants.PART1)]
	public object SolvePart1() => _sub.SolvePart1(_input);

	[Benchmark]
	[BenchmarkCategory(Constants.PART2)]
	public object SolvePart2() => _sub.SolvePart2(_input);
}