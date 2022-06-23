using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTL
{
	public partial class MTL
	{
		public static SortedSet<string> Types = new SortedSet<string>()
		{
			"container",
			"text",
			"list",
			"image",
			"link",
			"separator"
		};
	}
}
