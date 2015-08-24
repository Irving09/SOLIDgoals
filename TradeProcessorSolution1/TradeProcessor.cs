using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Data;

public class TradeProcessor {
	public void ProcessTrades(Stream stream) {
		var lines = ReadTradeData(stream);
		var trades = ParseTrades(lines);
		StoreTrades(trades);
	}
	
	/*
		When the format of the input data changes, 
		with the addition of an extra field indicating the broker for the transaction.
		
		When you decide not to use a Stream for input but instead read the trades
		from a remote call to a web service.
		
		The database is moved behind a web service that you must call.
		
		When the database changes in some way—perhaps the insert_trade stored
		procedure requires a new parameter for the broker.
		
		The next task is to split each responsibility into different classes
		and place them behind interfaces.

	*/
	public IEnumerable<string> ReadTradeData(Stream stream) {
		var lines = new List<string>();
		using(var reader = new StreamReader(stream))
		{
			string line;
			while((line = reader.ReadLine()) != null)
			{
				lines.Add(line);
			}
		}
		return lines;
	}
	
	public IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines) {
		var trades = new List<TradeRecord>();
		var lineNumber = 1;

		foreach(var line in lines) {
			var fields = line.Split(new char[] { ',' });
			bool isValid = ValidateTradeData(fields, lineNumber);
			if (!isValid) {
				continue;
			}
		    var trade = MapTradeDataToTradeRecord(fields);
           	trades.Add(trade);
            lineNumber++;
		}
		return trades;
	}

	public bool ValidateTradeData(string[] fields, int lineNumber) {
		if(fields.Length != 3)
		{
			Console.WriteLine("WARN: Line {0} malformed. Only {1} field(s) found.", lineNumber, fields.Length);
			return false;
		}
		
		if(fields[0].Length != 6)
		{
			Console.WriteLine("WARN: Trade currencies on line {0} malformed: '{1}'", lineNumber, fields[0]);
			return false;
		}
		
		int tradeAmount;
		if(!int.TryParse(fields[1], out tradeAmount))
		{
			Console.WriteLine("WARN: Trade amount on line {0} not a valid integer: '{1}'", lineNumber, fields[1]);
			return false;
		}
		
		decimal tradePrice;
		if (!decimal.TryParse(fields[2], out tradePrice))
		{
			Console.WriteLine("WARN: Trade price on line {0} not a valid decimal: '{1}'", lineNumber, fields[2]);
			return false;
		}
		
		return true;
	}
	
	public TradeRecord MapTradeDataToTradeRecord(string[] fields) {
		var sourceCurrencyCode = fields[0].Substring(0, 3);
		var destinationCurrencyCode = fields[0].Substring(3, 3);
		var tradeAmount = int.Parse(fields[1]);
		var tradePrice = decimal.Parse(fields[2]);
		
		var tradeRecord = new TradeRecord
        {
			SourceCurrency = sourceCurrencyCode,
			DestinationCurrency = destinationCurrencyCode,
			Lots = tradeAmount / LotSize,
			Price = tradePrice
		};
		return tradeRecord;
	}

	private void StoreTrades(IEnumerable<TradeRecord> trades)
	{
		using (var connection = new SqlConnection("DataSource=(local);Initial Catalog=TradeDatabase;Integrated Security=True"))
		{
			connection.Open();
			using (var transaction = connection.BeginTransaction())
			{
				foreach (var trade in trades)
				{
					var command = connection.CreateCommand();
					command.Transaction = transaction;
					command.CommandType = CommandType.StoredProcedure;
					command.CommandText = "dbo.insert_trade";
					command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
					command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
					command.Parameters.AddWithValue("@lots", trade.Lots);
					command.Parameters.AddWithValue("@price", trade.Price);
					command.ExecuteNonQuery();
				}
				transaction.Commit();
			}
			connection.Close();
		}
		Console.WriteLine("INFO: {0} trades processed", trades.Count());
	}
	
	private static float LotSize = 100000f;
}

public class TradeRecord {
	public string SourceCurrency { get; set; }
	public string DestinationCurrency { get; set; }
	public float Lots { get; set; }
	public decimal Price { get; set; }
}