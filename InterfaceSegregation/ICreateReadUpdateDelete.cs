using System.Collections.Generic;

// you force clients to declare up front which Type of <T> you are dealing with,
// which clarifies its dependencies.
// AntiPattern
public interface ICreateReadUpdateDelete<T> {
	void Create(T newEntity);
	T ReadOne(int identity);
	IEnumerable<T> ReadAll();
	void Update(T entity);
	void Delete(T entity);
}