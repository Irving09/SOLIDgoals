using System.Collections.Generic;
using AntiPattern;

public interface ITradeStorage {
	void Persist(IEnumerable<TradeRecord> records);
}