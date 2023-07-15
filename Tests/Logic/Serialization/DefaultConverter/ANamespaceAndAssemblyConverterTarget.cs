using Newtonsoft.Json;
using ProceduralLevel.Common.Logic;

namespace ProceduralLevel.Common.Tests
{
	[JsonConverter(typeof(NamespaceTypeConverter), "ProceduralLevel.Common.Tests", "ProceduralLEvel.Common.Tests")]
	public abstract class ANamespaceAndAssemblyConverterTarget
	{
		public bool BoolValue;
	}
}
