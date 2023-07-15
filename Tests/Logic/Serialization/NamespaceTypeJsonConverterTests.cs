using Newtonsoft.Json;
using NUnit.Framework;
using ProceduralLevel.Common.Logic;

namespace ProceduralLevel.Common.Tests
{
	public class NamespaceTypeJsonConverterTests
	{
		[Test]
		public void CustomConverter()
		{
			NamespaceOnlyConverterTarget instance = new NamespaceOnlyConverterTarget();
			instance.Str = "hello";
			string json = JsonConvert.SerializeObject(instance);

			NamespaceOnlyConverterTarget deserialized = (NamespaceOnlyConverterTarget)JsonConvert.DeserializeObject<ANamespaceOnlyConverterTarget>(json);

			Assert.IsTrue(json.Contains(NamespaceTypeConverter.TYPE_FIELD));
			Assert.AreEqual(instance.Str, deserialized.Str);
		}

		[Test]
		public void DefaultConverter()
		{
			NamespaceAndAssemblyConverterTarget instance = new NamespaceAndAssemblyConverterTarget();
			instance.Str = "hello";
			string json = JsonConvert.SerializeObject(instance);
			NamespaceAndAssemblyConverterTarget deserialized = (NamespaceAndAssemblyConverterTarget)JsonConvert.DeserializeObject<ANamespaceAndAssemblyConverterTarget>(json);

			Assert.IsTrue(json.Contains(NamespaceTypeConverter.TYPE_FIELD));
			Assert.AreEqual(instance.Str, deserialized.Str);
		}
	}
}
