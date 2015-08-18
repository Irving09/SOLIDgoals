public class DecoratorComponent {
	public readonly IComponent _decoratedComponent;

	public DecoratorComponent(IComponent decoratedComponent) {
		_decoratedComponent = decoratedComponent;
	}
	
	public void HelloWorld() {
		_decoratedComponent.HelloWorld();
	}
}