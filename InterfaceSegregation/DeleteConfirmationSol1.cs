using System;

public class DeleteConfirmationSol1<T> : IDelete<T> {
	private readonly IDelete<T> _thingToBeDecorated;
	public DeleteConfirmationSol1(IDelete<T> thingToBeDecorated) {
		_thingToBeDecorated = thingToBeDecorated;
	}
	public void Delete(T entity) {
		Console.WriteLine("Are you sure you want to delete the entity? [y/N]");
		string keyInfo = Console.ReadLine();;
		if (keyInfo.ToLower() == "y")
		{
			_thingToBeDecorated.Delete(entity);
		}
	}
}