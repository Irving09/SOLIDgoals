public class GenericController<T> {
	private readonly IRead<T> _reader;
	private readonly ISave<T> _saver;
	private readonly IDelete<T> _deleter;
	public GenericController(IRead<T> orderReader,
						   ISave<T> orderSaver,
						   IDelete<T> orderDeleter) {
		_reader = orderReader;
		_saver = orderSaver;
		_deleter = orderDeleter;
	}
	public void CreateOrder(T order) {
		_saver.Save(order);
	}
	public T GetSingleOrder(int identity) {
		return _reader.ReadOne(identity);
	}
	public void UpdateOrder(T order) {
		_saver.Save(order);
	}
	public void DeleteOrder(T order) {
		_deleter.Delete(order);
	}
}