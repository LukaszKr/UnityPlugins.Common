using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace UnityPlugins.Common.Logic
{
	/// <summary>
	/// Purpose of this is to prevent Unity from removing json converters without using link.xml which won't work according to documentation, in packages.
	/// I can't  apply Preserve tags to these converts, are they are in no-unity assembly.
	/// </summary>
	internal static class JsonStrippingPreventer
	{
		[Preserve]
		public static JsonSerializerSettings GetSettings()
		{
			return new JsonSerializerSettings()
			{
				Converters = new List<JsonConverter>()
				{
					new UGuidJsonConverter(),
					new IDJsonConverter(),
					new GridSize2DJsonConverter(),
					new GridSize3DJsonConverter(),
					new GridPoint2DJsonConverter(),
					new GridPoint3DJsonConverter(),
				}
			};
		}
	}
}
