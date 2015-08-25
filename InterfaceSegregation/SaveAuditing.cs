using System;
using System.Threading;

public class SaveAuditing<T> : ISave<T> {
	private readonly ISave<T> _thingToBeDecorated1;
	private readonly ISave<AuditInfo> _thingToBeDecorated2;

	public SaveAuditing(ISave<T> thingToDecorate, ISave<AuditInfo> auditSave) {
		_thingToBeDecorated1 = thingToDecorate;
		_thingToBeDecorated2 = auditSave;
	}
	
	public void Save(T entity) {
		//string test = Thread.CurrentPrincipal.Identity.Name;
		_thingToBeDecorated1.Save(entity);
		AuditInfo auditInfo = new AuditInfo {
			UserName = "Thread.CurrentPrincipal.Identity.Name",
			TimeStamp = DateTime.Now
		};
		_thingToBeDecorated2.Save(auditInfo);
	}
}

public class AuditInfo {
	public string UserName { get; set; }
	public DateTime? TimeStamp { get; set; }
}

public class AuditSave<T> : ISave<T> {
	public void Save(T entity) {
		// its own implementation of save is here
	}
}