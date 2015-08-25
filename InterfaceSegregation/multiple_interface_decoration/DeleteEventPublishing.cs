public class DeleteEventPublishing<T> : IDelete<T> {
	private readonly IDelete<T> _thingToBeDecorated;
	private readonly IEventPublisher _eventPublisher;
	
	public DeleteEventPublishing(IDelete<T> thingToBeDecorated, IEventPublisher eventPublisher) {
		_thingToBeDecorated = thingToBeDecorated;
		_eventPublisher = eventPublisher;
	}
	public void Delete(T entity) {
		_thingToBeDecorated.Delete(entity);
		var entityDeleted = new EntityDeletedEvent<T>(entity);
		_eventPublisher.Publish(entityDeleted);
	}
}