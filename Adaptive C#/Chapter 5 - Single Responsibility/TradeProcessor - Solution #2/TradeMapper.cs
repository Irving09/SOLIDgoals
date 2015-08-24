using AntiPattern;

public class TradeMapper : ITradeMapper {
    public TradeRecord Map(string[] fields) {
        //  using (var connection = new System.Data.SqlClient.SqlConnection("DataSource=(local);Initial Catalog=TradeDatabase;Integrated Security=True"))
        //  {
        //      connection.Open();
        //      using (var transaction = connection.BeginTransaction())
        //      {
        //          foreach (var trade in trades)
        //          {
        //              var command = connection.CreateCommand();
        //              command.Transaction = transaction;
        //              command.CommandType = System.Data.CommandType.StoredProcedure;
        //              command.CommandText = "dbo.insert_trade";
        //              command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
        //              command.Parameters.AddWithValue("@destinationCurrency",
        //              trade.DestinationCurrency);
        //              command.Parameters.AddWithValue("@lots", trade.Lots);
        //              command.Parameters.AddWithValue("@price", trade.Price);
        //              command.ExecuteNonQuery();
        //          }
        //          transaction.Commit();
        //      }
        //      connection.Close();
        //  }
        //  LogMessage("INFO: {0} trades processed", trades.Count());
        return null;
        // TODO Not yet implemented
    } 
}