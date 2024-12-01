namespace AdventOfCode2024.Common;

public static class HappyPuzzleHelpers
{
	public static IEnumerable<Type> DiscoverPuzzles(bool onlyLast = false)
	{
		var resolvedPuzzles = typeof(HappyPuzzleBase)
			.Assembly
			.GetTypes()
			.Where(x => x.IsAssignableTo(typeof(HappyPuzzleBase)) && x is { IsClass: true, IsAbstract: false })
			.OrderBy(x => x.Name)
			.AsEnumerable();

		if (onlyLast)
		{
			resolvedPuzzles = resolvedPuzzles.TakeLast(1);
		}

		return resolvedPuzzles;
	}
}