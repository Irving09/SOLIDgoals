//  public class TradeValidator : ITradeValidator {
//  	private readonly ILogger logger;
//  	public TradeValidator(ILogger logger)
//  	{
//  		this.logger = logger;
//  	}
	
//  	public bool Validate(string[] tradeData) {
//  		if (tradeData.Length != 3)
//  		{
//  			logger.LogWarning("Line malformed. Only {1} field(s) found.", tradeData.Length);
//  			return false;
//  		}
//  		if (tradeData[0].Length != 6)
//  		{
//  			logger.LogWarning("Trade currencies malformed: '{1}'", tradeData[0]);
//  			return false;
//  		}
//  		int tradeAmount;
//  		if (!int.TryParse(tradeData[1], out tradeAmount))
//  		{
//  			logger.LogWarning("Trade amount not a valid integer: '{1}'", tradeData[1]);
//  			return false;
//  		}
//  		decimal tradePrice;
//  		if (!decimal.TryParse(tradeData[2], out tradePrice))
//  		{
//  			logger.LogWarning("WARN: Trade price not a valid decimal: '{1}'",
//  			tradeData[2]);
//  			return false;
//  		}
//  		return true;
//  	}
//  }