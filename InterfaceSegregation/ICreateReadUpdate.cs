using System.Collections.Generic;

public interface ICreateReadUpdate<T> {
	void Create(T entity);
	T ReadOne(int identity);
	IEnumerable<T> ReadAll();
	void Update(T entity);
}