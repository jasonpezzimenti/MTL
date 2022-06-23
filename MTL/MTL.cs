using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTL
{
	public class MTL
	{
		public class Token
		{
			public enum TokenTypes
			{
				Type = 0,
				Identifier,
				Value
			}

			public static TokenTypes TokenType { get; set; }
		}

		public static Stack<Token> Tokens = new Stack<Token>();
	}
}
