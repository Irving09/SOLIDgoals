public class StopWatchAdapter : IStopWatch {
	public readonly StopWatch _stopwatch;
	public StopWatchAdapter(StopWatch stopWatch) {
		_stopwatch = stopWatch;
	}
	public void Start() {
		_stopwatch.start();
	}
	public long Stop() {
		_stopwatch.Stop();
		var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
		_stopwatch.Reset();
		return elapsedMilliseconds;
	}
}