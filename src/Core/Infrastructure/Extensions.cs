using System.Collections.Generic;
using System.Linq;

namespace Rogue.Core.UI.Infrastructure
{
	public static class Extensions
	{
		public static IEnumerable<IEnumerable<T>> InGroupsOf<T>(this IEnumerable<T> self, int groupSize)
		{
			int i = 1;
			int groupNum = 0;
			return self.GroupBy(item =>
				{
					if (i % (groupSize + 1) == 0)
					{
						i = 1;
						groupNum++;
					}
					{
						i++;
					}

					return groupNum;
				}).Select(s => s);
		}
	}
}
