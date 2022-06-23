namespace MTL
{
	public class Program
	{
		public static string type = "",
			identifier = "",
			previous = "",
			next = "",
			character = "",
			input = "";
		public static bool isInsideString,
			isInsideScope,
			isExpectingType,
			isExpectingIdentifier,
			isExpectingString,
			isExpectingScopeStart,
			isExpectingScopeEnd;

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
							input += reader.Read();
						}

						isReady = true;
					}
				}
			}

			if(isReady)
			{

			}
		}
	}
}