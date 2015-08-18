using AntiPattern;
using System.Collections.Generic;

public class TradeParser : ITradeParser {
	private readonly ITradeValidator _tradeValidator;
	
	private readonly ITradeMapper _tradeMapper;

	public TradeParser(ITradeValidator tradeValidator, ITradeMapper tradeMapper)
    {
        _tradeValidator = tradeValidator;
        _tradeMapper = tradeMapper;
    }
    
    public IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData) {
        var trades = new List<TradeRecord>();
        var lineCount = 1;
        foreach (var line in tradeData)
        {
            var fields = line.Split(new char[] { ',' });
            if (!_tradeValidator.Validate(fields)) {
            continue; }
            var trade = _tradeMapper.Map(fields);
            trades.Add(trade);
            lineCount++;
        }
       return trades;
    }
}