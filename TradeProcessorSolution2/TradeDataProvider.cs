using System.IO;
using System.Collections.Generic;

public class TradeDataProvider : ITradeDataProvider {
	private Stream _stream;
	
	public TradeDataProvider(Stream stream) {
		_stream = stream;
	}
	
	public IEnumerable<string> GetTradeData() {
		var tradeData = new List<string>();
		using (var reader = new StreamReader(_stream))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				tradeData.Add(line);
			}
		}
		return tradeData;
	}	
}