using System.Collections.Generic;

public class TradeParser {
	ITradeValidator _tradeValidator;
	ITradeMapper _tradeMapper;
	public TradeParser(ITradeValidator tradeValidator, ITradeMapper tradeMapper) {
		_tradeValidator = tradeValidator;
		_tradeMapper = tradeMapper;
	}
	
	public IEnumerable<TradeRecord> Parse(IEnumerable<string> lines) {
		List<TradeRecord> trades = new List<TradeRecord>();
		int lineCount = 1;
		
		foreach (var line in lines) {
			string[] fields = line.Split(new char[] { ',' });
			if (!_tradeValidator.Validate(fields)) {
				continue;
			}
			var trade = _tradeMapper.Map(fields);
			trades.Add(trade);
			lineCount++;
		}
		return trades;
	}
}