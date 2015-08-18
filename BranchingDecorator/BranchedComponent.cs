public class BranchedComponent : IComponent {
	public readonly IComponent _component1;
	public readonly IComponent _component2;
	public readonly IPredicate _predicate; 
	public BranchedComponent(IComponent c1, IComponent c2, IPredicate predicate) {
		_component1 = c1;
		_component2 = c2;
		_predicate = predicate;
	}
	public void Execute() {
		if (_predicate.IsEvenDay()) {
			_component1.Execute();
		} else {
			_component2.Execute();
		}
	}
}