using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CKLLib;

namespace WPFTraining
{
	public delegate void TimeIntervalAction(TimeInterval interval);
	public delegate void TimeIntervalWithDeltaAction(TimeInterval interval, double delta);
	public delegate void ObjectsWithTimeIntervalAction(List<object> objs, TimeInterval interval);
}