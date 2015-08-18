public class PredicateComponent : IComponent {
	public readonly IComponent _decoratorComponent;
	public readonly IPredicate _predicate;
	public PredicateComponent(IComponent decoratorComponent, IPredicate predicate) {
		_decoratorComponent = decoratorComponent;
		_predicate = predicate;
	}
	
	public void Execute() {
		if (_predicate.IsEvenDay()) {
			_decoratorComponent.Execute();
		}
	}
}