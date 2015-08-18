using AntiPattern;

public interface ITradeMapper {
	TradeRecord Map(string[] fields);
}