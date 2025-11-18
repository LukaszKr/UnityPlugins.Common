namespace UnityPlugins.Common.Logic
{
	public interface IValueConstraint<TValue>
	{
		TValue Evaluate(TValue value);
	}
}
