using System;

public class LoggingStopWatch : IStopWatch {
	public readonly IStopWatch _decoratedStopWatch;
	
	public LoggingStopWatch(IStopWatch decoratedStopWatch) {
		_decoratedStopWatch = decoratedStopWatch;
	}
	
	public void Start() {
		_decoratedStopWatch.Start();
		Console.WriteLine("Stopwatch started...");
	}
	
	public long Stop() {
		var elapsedMilliseconds = _decoratedStopWatch.Stop();
		Console.WriteLine("Stopwatch stopped after {0} seconds",
			TimeSpan.FromMilliseconds(elapsedMilliseconds).TotalSeconds);
		return elapsedMilliseconds;;
	}
}