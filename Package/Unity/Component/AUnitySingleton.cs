using ProceduralLevel.Common.Logic;

namespace ProceduralLevel.Common.Unity.Extended
{
	public abstract class AUnitySingleton<TObject> : ExtendedMonoBehaviour
		where TObject : AUnitySingleton<TObject>
	{
		public static TObject Instance;

		public AUnitySingleton()
		{
			Instance = this as TObject;
		}
	}
}
