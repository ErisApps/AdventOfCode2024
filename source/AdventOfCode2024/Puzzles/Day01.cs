using System.Diagnostics;
using System.Runtime.InteropServices;
using AdventOfCode2024.Common;

namespace AdventOfCode2024.Puzzles;

public class Day01 : HappyPuzzleBase
{
	private const int BUFFER_SIZE = 1000;

	public override object SolvePart1(Input input)
	{
		scoped Span<int> left = stackalloc int[BUFFER_SIZE];
		scoped Span<int> right = stackalloc int[BUFFER_SIZE];

		ParseInput(input.Lines, ref left, ref right);

		left.Sort();
		right.Sort();

		var sumDistance = 0;
		for (var i = 0; i < left.Length; i++)
		{
			sumDistance += Math.Abs(right[i] - left[i]);
		}

		return sumDistance;
	}

	public override object SolvePart2(Input input)
	{
		scoped Span<int> left = stackalloc int[BUFFER_SIZE];
		scoped Span<int> right = stackalloc int[BUFFER_SIZE];

		ParseInput(input.Lines, ref left, ref right);

		left.Sort();
		right.Sort();

		var referenceNumber = -1;
		var referenceScore = 0;
		var totalScore = 0;
		var leftIndex = 0;
		var rightIndex = 0;

		do
		{
			var leftNumber = left[leftIndex];
			if (leftNumber != referenceNumber)
			{
				referenceNumber = leftNumber;
				referenceScore = 0;

				do
				{
					var rightNumber = right[rightIndex];
					if (rightNumber == referenceNumber)
					{
						referenceScore++;
					}
					else if (rightNumber > referenceNumber)
					{
						break;
					}

					++rightIndex;
				} while (rightIndex < right.Length);

				referenceScore *= referenceNumber;
			}

			totalScore += referenceScore;

			++leftIndex;
		} while (leftIndex < left.Length);

		return totalScore;
	}

	private static void ParseInput(string[] input, ref Span<int> left, ref Span<int> right)
	{
		for (var lineIndex = 0; lineIndex < input.Length; lineIndex++)
		{
			var line = input[lineIndex];
			var target = left;
			var number = 0;
			for (var characterIndex = 0; characterIndex < line.Length; characterIndex++)
			{
				var c = line[characterIndex];
				if (c is >= '0' and <= '9')
				{
					number *= 10;
					number += c - '0';
				}
				else
				{
					target[lineIndex] = number;
					number = 0;
					characterIndex += 2;
					target = right;
				}
			}

			target[lineIndex] = number;
		}

		left = left.Slice(0, input.Length);
		right = right.Slice(0, input.Length);
	}
}