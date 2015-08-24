//  using Microsoft.Build.Framework;

public class TradeValidator : ITradeValidator {
	private readonly ILogger _logger; // TODO Not yet implemented
	
	public TradeValidator(ILogger logger) {
		_logger = logger;
	}
	
	public bool Validate(string[] lines) {
		if (lines.Length != 3)
		{
			_logger.LogWarning("Line malformed. Only {1} field(s) found.", lines.Length);
			return false;
		}
		if (lines[0].Length != 6)
		{
			_logger.LogWarning("Trade currencies malformed: '{1}'", lines[0]);
			return false;
		}
		int tradeAmount;
		if (!int.TryParse(lines[1], out tradeAmount))
		{
			_logger.LogWarning("Trade amount not a valid integer: '{1}'", lines[1]);
			return false;
		}
		decimal tradePrice;
		if (!decimal.TryParse(lines[2], out tradePrice))
		{
			_logger.LogWarning("WARN: Trade price not a valid decimal: '{1}'", lines[2]);
			return false;
		}
		return true;
	}
}