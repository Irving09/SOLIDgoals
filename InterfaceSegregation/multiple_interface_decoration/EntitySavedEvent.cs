public class EntitySavedEvent<T> : IEvent {
	public string Name { get; set; }
	
	public EntitySavedEvent(T entity) {
		// do something with enity here and assign Name;
	}
}