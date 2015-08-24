using System.Collections.Generic;

public class TradeProcessor {
	ITradeDataProvider _tradeDataProvider;
	ITradeParser _tradeParser;
	ITradeStorage _tradeStorage;
	
	
	public void ProcessTrades() {
		IEnumerable<string> lines = _tradeDataProvider.GetTradeData();
		IEnumerable<TradeRecord> trades = _tradeParser.Parse(lines);
		_tradeStorage.Persist(trades);
	}
}