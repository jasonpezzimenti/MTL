using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTL
{
	public partial class MTL
	{
		public class Token
		{
			public enum TokenTypes
			{
				Type = 0,
				Identifier,
				Symbol,
				Value
			}

			public TokenTypes TokenType { get; set; }

			public string Value { get; set; }
		}

		public static Stack<Token> Tokens = new Stack<Token>();
	}
}
