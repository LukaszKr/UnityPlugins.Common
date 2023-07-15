using Newtonsoft.Json;

namespace ProceduralLevel.Common.Tests
{
	[JsonConverter(typeof(EditorTestsJsonConverter))]
	public abstract class ANamespaceOnlyConverterTarget
	{
		public bool BoolValue;
	}
}
