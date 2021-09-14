using Pixeye.Actors;

namespace Source
{
	public class ActorCapsule : Actor
	{
		public ComponentCapsuleMovement CapsuleMovement;
		public float RotationSpeed;
		public bool Exclude;

		protected override void Setup()
		{
			entity.Set(CapsuleMovement);
			if (!Exclude)
				entity.Set<ComponentExcludeExample>();
			
			//Достаем из пула или создаем 
			var rotation = entity.Set<ComponentRotation>();
			rotation.speed = RotationSpeed;
		}
	}
}