public class EntityDeletedEvent<T> : IEvent {
	public string Name { get; set; }
	
	public EntityDeletedEvent(T entity) {
		// do something with enity here and assign Name;
	}
}