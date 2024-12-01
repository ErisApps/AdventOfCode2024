using AdventOfCode2024.Common;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2024.Tests.Common;

public abstract class HappyPuzzleTestBase<TPuzzle> where TPuzzle : HappyPuzzleBase, new()
{
	protected abstract string Part1AssetName { get; } // eg: "Day01_Part1.txt"
	protected abstract object Part1ExpectedResult { get; } // eg: 142

	[Fact]
	public void SolvePart1()
	{
		// Arrange
		var sut = new TPuzzle();
		var input = Helpers.GetInput(Part1AssetName);

		// Act
		var result = sut.SolvePart1(input);

		// Assert
		result.Should().Be(Part1ExpectedResult, "because that's the expected result");
	}

	protected abstract string Part2AssetName { get; } // eg: "Day01_Part2.txt"
	protected abstract object Part2ExpectedResult { get; } // eg: 281

	[Fact]
	public void SolvePart2()
	{
		// Arrange
		var sut = new TPuzzle();
		var input = Helpers.GetInput(Part2AssetName);

		// Act
		var result = sut.SolvePart2(input);

		// Assert
		result.Should().Be(Part2ExpectedResult, "because that's the expected result");
	}
}