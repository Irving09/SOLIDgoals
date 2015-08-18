using System;
using System.Collections.Generic;

public class CompositeComponent : IComponent {
	private ICollection<IComponent> children;
	
	public CompositeComponent() {
		children = new List<IComponent>();
	}
	
	public void AddComponent(IComponent component) {
		children.Add(component);
	}
	
	public void RemoveComponent(IComponent component)
	{
		children.Remove(component);
	}
	
	public void Execute() 
	{
		foreach (var item in children)
		{
			item.Execute();
		}
	}
}