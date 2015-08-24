public class ReadCaching<T> : IRead<T> {
	private T _cachedEntity;
	private readonly IRead<T> _thingToBeDecorated;
	public ReadCaching(IRead<T> thingToBeDecorated) {
		_thingToBeDecorated = thingToBeDecorated;
	}
	public T ReadOne(int identity) {
		if(_cachedEntity == null)
		{
			_cachedEntity = _thingToBeDecorated.ReadOne(identity);
		}
		return _cachedEntity;
	}
}