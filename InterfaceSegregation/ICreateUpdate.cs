public interface ICreateUpdate<T> {
	void Create(T entity);
	void Update(T entity);
}