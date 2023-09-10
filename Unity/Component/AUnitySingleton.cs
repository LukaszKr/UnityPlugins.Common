using ProceduralLevel.Common.Assertion;

namespace ProceduralLevel.Common.Unity.Extended
{
	public abstract class AUnitySingleton<TObject> : ExtendedMonoBehaviour
		where TObject : AUnitySingleton<TObject>
	{
		public static TObject Instance;

		public AUnitySingleton()
		{
			GameAssert.IsNull(Instance);
			Instance = this as TObject;
		}
	}
}
