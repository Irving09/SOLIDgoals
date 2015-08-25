public class OrderController {
	private readonly IRead<Order> _reader;
	private readonly ISave<Order> _saver;
	private readonly IDelete<Order> _deleter;
	public OrderController(IRead<Order> orderReader,
						   ISave<Order> orderSaver,
						   IDelete<Order> orderDeleter) {
		_reader = orderReader;
		_saver = orderSaver;
		_deleter = orderDeleter;
	}
	public void CreateOrder(Order order) {
		_saver.Save(order);
	}
	public Order GetSingleOrder(int identity) {
		return _reader.ReadOne(identity);
	}
	public void UpdateOrder(Order order) {
		_saver.Save(order);
	}
	public void DeleteOrder(Order order) {
		_deleter.Delete(order);
	}
}