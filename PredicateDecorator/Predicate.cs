public class Predicate : IPredicate {
	public readonly DateTester _dateTester;
	
	public Predicate(DateTester dateTester) {
		_dateTester = dateTester;
	}
	
	public bool IsEvenDay() {
		return _dateTester.TodayIsAnEvenDayOfTheMonth;
	}
}