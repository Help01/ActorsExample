using Pixeye.Actors;

namespace Source
{
	public class ComponentRotation
	{
		public float speed;
		internal float progress;
	}

	#region HELPERS

	public static partial class Component
	{
		public const string ComponentRotation = "Source.ComponentRotation";
		internal static ref ComponentRotation componentRotation(in this ent entity) =>
			ref Storage<ComponentRotation>.components[entity.id];
	}

	sealed class StorageRotation : Storage<ComponentRotation>
	{
		public override ComponentRotation Create() => new ComponentRotation();

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