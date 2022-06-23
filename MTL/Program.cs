namespace MTL
{
	public class Program
	{
		public static string type = "",
			identifier = "",
			previous = "",
			next = "",
			character = "",
			text = "",
			input = "";
		public static bool isInsideString,
			isInsideScope,
			isExpectingType = true,
			isExpectingIdentifier,
			isExpectingString,
			isExpectingScopeStart,
			isExpectingScopeEnd;
		public static int position = 0;

		public static void Main(string[] arguments)
		{
			bool isReady = false;

			// Read the file passed to the application.
			if(arguments.Length >= 1)
			{
				string filePath = arguments[0];

				if(!String.IsNullOrEmpty(filePath))
				{
					using (StreamReader reader = new StreamReader(filePath))
					{
						reader.BaseStream.Position = 0;

						while(!reader.EndOfStream)
						{
							input += reader.ReadToEnd();
						}

						isReady = true;
					}
				}
			}

			if(isReady)
			{
				for(int index = 0; index < input.Length; index++)
				{
					position = index;
					character = input[position].ToString();

					if(isInsideString)
					{
						// If we find a double quote, we should consider this to be the end of the string.
						if(character == MTL.Symbols.DoubleQuote)
						{
							MTL.Tokens.Push(new MTL.Token()
							{
								TokenType = MTL.Token.TokenTypes.Value,
								Value = text
							});

							MTL.Tokens.Push(new MTL.Token()
							{
								TokenType = MTL.Token.TokenTypes.Symbol,
								Value = MTL.Symbols.DoubleQuote
							});

							text = "";

							isInsideString = false;
							isExpectingScopeEnd = true;
							isExpectingType = true;
							isExpectingString = false;
						}
						else
						{
							text += character;
						}
					}
					else
					{
						if (isExpectingType)
						{
							if (character == MTL.Symbols.ClosingBrace)
							{
								MTL.Tokens.Push(new MTL.Token()
								{
									TokenType = MTL.Token.TokenTypes.Symbol,
									Value = MTL.Symbols.ClosingBrace
								});

								isExpectingType = true;
								isExpectingIdentifier = false;
								isExpectingScopeEnd = false;
							}
							else
							{
								if (MTL.Types.Contains(text))
								{
									MTL.Tokens.Push(new MTL.Token()
									{
										TokenType = MTL.Token.TokenTypes.Type,
										Value = text
									});

									if (text == "text")
									{
										isExpectingString = true;
									}

									isExpectingType = false;
									isExpectingIdentifier = true;

									text = "";
								}
								else
								{
									if (character != " " && character != "\t" && character != "\r" && character != "\n")
									{
										text += character;
									}
								}
							}
						}
						else if (isExpectingString)
						{
							if (character == MTL.Symbols.DoubleQuote)
							{
								MTL.Tokens.Push(new MTL.Token()
								{
									TokenType = MTL.Token.TokenTypes.Identifier,
									Value = text
								});

								MTL.Tokens.Push(new MTL.Token()
								{
									TokenType = MTL.Token.TokenTypes.Symbol,
									Value = MTL.Symbols.DoubleQuote
								});

								isExpectingScopeStart = true;
								isExpectingScopeEnd = true;
								isExpectingIdentifier = false;
								isExpectingType = false;
								isExpectingString = false;
								isInsideString = true;

								text = "";
							}
							else
							{

							}
						}
						else if (isExpectingIdentifier)
						{
							if (character == MTL.Symbols.OpeningBrace)
							{
								MTL.Tokens.Push(new MTL.Token()
								{
									TokenType = MTL.Token.TokenTypes.Identifier,
									Value = text
								});

								MTL.Tokens.Push(new MTL.Token()
								{
									TokenType = MTL.Token.TokenTypes.Symbol,
									Value = MTL.Symbols.OpeningBrace
								});

								isInsideScope = true;
								isExpectingScopeStart = false;
								isExpectingScopeEnd = true;
								isExpectingIdentifier = false;
								isExpectingType = true;

								text = "";
							}
							else if (character == MTL.Symbols.DoubleQuote)
							{
								MTL.Tokens.Push(new MTL.Token()
								{
									TokenType = MTL.Token.TokenTypes.Identifier,
									Value = text
								});

								MTL.Tokens.Push(new MTL.Token()
								{
									TokenType = MTL.Token.TokenTypes.Symbol,
									Value = MTL.Symbols.DoubleQuote
								});

								isExpectingScopeStart = true;
								isExpectingScopeEnd = true;
								isExpectingIdentifier = false;
								isExpectingType = false;

								text = "";
							}
							else
							{
								if (character != " " && character != "\t" && character != "\r" && character != "\n")
								{
									text += character;
								}
							}
						}
						else
						{
							if (isExpectingScopeEnd)
							{
								if (character == MTL.Symbols.ClosingBrace)
								{
									MTL.Tokens.Push(new MTL.Token()
									{
										TokenType = MTL.Token.TokenTypes.Symbol,
										Value = MTL.Symbols.ClosingBrace
									});

									isExpectingType = true;
									isExpectingIdentifier = false;
									isExpectingScopeEnd = false;
								}
								else
								{

								}
							}
						}
					}
				}
			}

			foreach (var token in MTL.Tokens.Reverse())
			{
				Console.WriteLine(token.Value);
			}
		}
	}
}