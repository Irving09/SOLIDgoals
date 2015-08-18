using System.Collections.Generic;
using AntiPattern;

public interface ITradeParser {
	IEnumerable<TradeRecord> Parse(IEnumerable<string> lines);
}