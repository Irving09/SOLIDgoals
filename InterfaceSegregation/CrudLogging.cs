using System.Collections.Generic;

/*
The decorators for logging and transaction management are cross-cutting concerns.
Irrespective of the method on the interface and, in many cases,
irrespective of the interface itself, logging and transaction management could be applied.

Thus, to avoid repetitive implementations for multiple interfaces, you can decorate all
implementations by using aspect-oriented programming.
*/
public class CrudLogging<T> : ICreateReadUpdateDelete<T> {
	private readonly ICreateReadUpdateDelete<T> _thingToDecorate;
	private readonly ILog _logger;
	
	public CrudLogging(ICreateReadUpdateDelete<T> thingToDecorate, ILog logger) {
		_thingToDecorate = thingToDecorate;
		_logger = logger;
	}
	
	public void Create(T newEntity) {
		_logger.InfoFormat("Creating entity of type {0}", typeof(T).Name);
		_thingToDecorate.Create(newEntity);
	}
	public T ReadOne(int identity) {
		_logger.InfoFormat("Reading a single entity of type {0}", typeof(T).Name);
		return _thingToDecorate.ReadOne(0);
	}
	public IEnumerable<T> ReadAll() {
		_logger.InfoFormat("Reading all entities of type {0}", typeof(T).Name);
		return _thingToDecorate.ReadAll();
	}
	public void Update(T entity) {
		_logger.InfoFormat("Updating an entity of type {0}", typeof(T).Name);
		_thingToDecorate.Update(entity);
	}
	public void Delete(T entity) {
		_logger.InfoFormat("Deleting an entity of type {0}", typeof(T).Name);
		_thingToDecorate.Delete(entity);		
	}
}