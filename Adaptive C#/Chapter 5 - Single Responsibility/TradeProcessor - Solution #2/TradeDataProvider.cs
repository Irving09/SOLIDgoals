using System.Collections.Generic;
using System.IO;

public class TradeDataProvider : ITradeDataProvider {
	public readonly Stream _stream;
	
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