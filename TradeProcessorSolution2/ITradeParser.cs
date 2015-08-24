using System.Collections.Generic;

public interface ITradeParser {
	IEnumerable<TradeRecord> Parse(IEnumerable<string> lines);
}