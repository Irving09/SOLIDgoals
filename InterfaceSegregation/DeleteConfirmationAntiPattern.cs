using System.Collections.Generic;
using System;

public class DeleteConfirmationAntiPattern<T> {
	private readonly ICreateReadUpdateDelete<T> _thingToDecorate;
	private readonly ILog _logger;
	
	public DeleteConfirmationAntiPattern(ICreateReadUpdateDelete<T> thingToDecorate, ILog logger) {
		_thingToDecorate = thingToDecorate;
		_logger = logger;
	}

	//pass-through delegation
	//NOTE: in order to maintain unit test cover- age and ensure that they are delegating properly,
	//test methods should still be written to verify that their behavior is correct.
	public void Create(T newEntity) {
		_thingToDecorate.Create(newEntity);
	}
	//pass-through delegation 
	//NOTE: in order to maintain unit test cover- age and ensure that they are delegating properly,
	//test methods should still be written to verify that their behavior is correct.
	public T ReadOne(int identity) {
		return _thingToDecorate.ReadOne(0);
	}
	//pass-through delegation 
	//NOTE: in order to maintain unit test cover- age and ensure that they are delegating properly,
	//test methods should still be written to verify that their behavior is correct.
	public IEnumerable<T> ReadAll() {
		return _thingToDecorate.ReadAll();
	}
	//pass-through delegation 
	//NOTE: in order to maintain unit test cover- age and ensure that they are delegating properly,
	//test methods should still be written to verify that their behavior is correct.
	public void Update(T entity) {
		_thingToDecorate.Update(entity);
	}
	public void Delete(T entity) {
		Console.WriteLine("Are you sure you want to delete the entity? [y/N]");
           string keyInfo = Console.ReadLine();;
           if (keyInfo.ToLower() == "y")
           {
               _thingToDecorate.Delete(entity);
           }
	}
}