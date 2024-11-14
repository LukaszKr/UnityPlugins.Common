namespace UnityPlugins.Common.Logic
{
	public class TypeMapConverter : ATypeMapConverter
	{
		public static readonly TypeMap TypeMap = new TypeMap();

		protected override TypeMap GetTypeMap()
		{
			return TypeMap;
		}
	}
}
