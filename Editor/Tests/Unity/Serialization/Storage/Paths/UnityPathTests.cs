using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Unity.Serialization.Storage.Paths
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class UnityPathTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<UnityPath>
		{
			public EqualsTest(bool areEqual, UnityPath a, UnityPath b)
				: base(areEqual, a, b)
			{
			}

			public override void Run()
			{
				base.Run();

				Assert.AreEqual(AreEqual, A == B);
				Assert.AreNotEqual(AreEqual, A != B);
			}
		}

		private static readonly EqualsTest[] m_EqualsTests = new EqualsTest[]
		{
			new EqualsTest(true, default, default),
			new EqualsTest(true, new UnityPath(EUnityPathType.Absolute, "C:/"), new UnityPath(EUnityPathType.Absolute, "C:/")),

		};

		[Test, TestCaseSource(nameof(m_EqualsTests))]
		public void Equals(EqualsTest test)
		{
			test.Run();
		}
		#endregion

		#region Constructor
		public class ConstructorTest
		{
			public readonly string InputPath;
			public readonly string ExpectedPath;

			public ConstructorTest(string inputPath, string expectedPath)
			{
				InputPath = inputPath;
				ExpectedPath = expectedPath;
			}

			public void Run()
			{
				UnityPath path = new UnityPath(EUnityPathType.Absolute, InputPath);
				Assert.AreEqual(ExpectedPath, path.ToString());
			}

			public override string ToString()
			{
				return $"'{InputPath} -> '{ExpectedPath}'";
			}
		}

		private readonly static ConstructorTest[] m_UnityPathConstructorTests = new ConstructorTest[]
		{
			new ConstructorTest("C:/Folder/", "C:/Folder/"),
			new ConstructorTest("C:/Folder", "C:/Folder"),
			new ConstructorTest("C:/Folder/File.ext", "C:/Folder/File.ext"),
		};

		[Test, TestCaseSource(nameof(m_UnityPathConstructorTests))]
		public void Constructor(ConstructorTest test)
		{
			test.Run();
		}
		#endregion

		#region GetDirectory
		public class GetDirectoryTest
		{
			public readonly string Input;
			public readonly string ExpectedDirectory;

			public GetDirectoryTest(string input, string expectedDirectory)
			{
				Input = input;
				ExpectedDirectory = expectedDirectory;
			}

			public void Run()
			{
				UnityPath path = new UnityPath(EUnityPathType.Absolute, Input);
				Assert.AreEqual(ExpectedDirectory, path.GetDirectory());
			}

			public override string ToString()
			{
				return $"'{Input}' -> '{ExpectedDirectory}'";
			}
		}

		private static readonly GetDirectoryTest[] m_GetDirectoryTests = new GetDirectoryTest[]
		{
			new GetDirectoryTest("C:/Folder/", "C:\\Folder\\"),
			new GetDirectoryTest("C:/Folder", "C:\\Folder"),
			new GetDirectoryTest("C:/Folder/File.ext", "C:\\Folder"),
			new GetDirectoryTest("C:/Folder/File", "C:\\Folder\\File"),
		};

		[Test, TestCaseSource(nameof(m_GetDirectoryTests))]
		public void GetDirectory(GetDirectoryTest test)
		{
			test.Run();
		}
		#endregion

		#region Append
		public class AppendTest
		{
			public readonly UnityPath Path;
			public readonly string Sufix;
			public readonly UnityPath Expected;

			public AppendTest(string path, string sufix, string expected)
			{
				Path = new UnityPath(EUnityPathType.Absolute, path);
				Sufix = sufix;
				Expected = new UnityPath(EUnityPathType.Absolute, expected);
			}

			public AppendTest(UnityPath path, string sufix, UnityPath expected)
			{
				Path = path;
				Sufix = sufix;
				Expected = expected;
			}

			public void Run()
			{
				UnityPath newPath = Path.Append(Sufix);
				Assert.AreEqual(Expected, newPath);
			}

			public override string ToString()
			{
				return $"'{Path}' + '{Sufix}' -> '{Expected}'";
			}
		}

		private static readonly AppendTest[] m_AppendTests = new AppendTest[]
		{
			new AppendTest("C:/", "Test", "C:/Test"),
			new AppendTest("C:/", "Test/", "C:/Test/"),
			new AppendTest("C:/SubFolder/", "Test/", "C:/SubFolder/Test/"),
			new AppendTest("C:/SubFolder/", "Test.ext", "C:/SubFolder/Test.ext"),
		};

		[Test, TestCaseSource(nameof(m_AppendTests))]
		public void Append(AppendTest test)
		{
			test.Run();
		}
		#endregion
	}
}
