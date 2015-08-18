namespace SOLID_Principles {
	public class TradeProcessor_Sol2 {
		private readonly ITradeDataProvider _tradeDataProvider;
       	private readonly ITradeParser _tradeParser;
       	private readonly ITradeStorage _tradeStorage;

		public TradeProcessor_Sol2(ITradeDataProvider tradeDataProvider, ITradeParser tradeParser, ITradeStorage tradeStorage) {
			_tradeDataProvider = tradeDataProvider;
           	_tradeParser = tradeParser;
           	_tradeStorage = tradeStorage;
		}
		
		public void ProcessTrades() {
			var lines = _tradeDataProvider.GetTradeData();
           	var trades = _tradeParser.Parse(lines);
           	_tradeStorage.Persist(trades);
		}
	}
}