using Pixeye.Actors;

namespace Source
{
	public class ComponentExcludeExample
	{
		//пустой компонент, просто для примера
	}

	#region HELPERS

	public static partial class Component
	{
		public const string ExcludeExample = "Source.ComponentExcludeExample";
		
		internal static ref ComponentExcludeExample componentExcludeExample(in this ent entity) =>
			ref Storage<ComponentExcludeExample>.components[entity.id];
	}

	sealed class StorageExcludeExample : Storage<ComponentExcludeExample>
	{
		public override ComponentExcludeExample Create() => new ComponentExcludeExample();

		public override void Dispose(indexes disposed)
		{
			foreach (var id in disposed)
			{
				components[id] = default;
			}
		}

	}

	#endregion
}