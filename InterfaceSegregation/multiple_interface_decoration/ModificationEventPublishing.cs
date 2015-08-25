public class ModificationEventPublishing<T> : IDelete<T>, ISave<T> {
	private readonly IDelete<T> _deleteDecorator;
	private readonly ISave<T> _saveDecorator;
	private readonly IEventPublisher _eventPublisher;
	
	public ModificationEventPublishing(IDelete<T> toBeDecorated1,
									   ISave<T> toBeDecorated2,
									   IEventPublisher eventPublisher) {
		_deleteDecorator = toBeDecorated1;
		_saveDecorator = toBeDecorated2;
		_eventPublisher = eventPublisher;
	}
	
	public void Delete(T entity) {
		_deleteDecorator.Delete(entity);
		var entityDeleted = new EntityDeletedEvent<T>(entity);
	    _eventPublisher.Publish(entityDeleted);
	}
	
	public void Save(T entity) {
		_saveDecorator.Save(entity);
		var entitySaved = new EntitySavedEvent<T>(entity);
		_eventPublisher.Publish(entitySaved);
	}
}