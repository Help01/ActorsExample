using System;
using Pixeye.Actors;
using UnityEngine;

namespace Source
{
	[Serializable]
	public class ComponentCapsuleMovement
	{
		//Радиус вращения окружности
		public float distance;
		//Скорость вращения
		public float speed;
		//Угол поворота окружности относительно центра
		internal float angle;
		//Центр вращения
		internal Vector3 startPosition;
	}

	#region HELPERS

	public static partial class Component
	{
		public const string CapsuleMovement = "Source.ComponentCapsuleMovement";
		internal static ref ComponentCapsuleMovement componentCapsuleMovement(in this ent entity) =>
			ref Storage<ComponentCapsuleMovement>.components[entity.id];
	}

	sealed class StorageCapsuleMovement : Storage<ComponentCapsuleMovement>
	{
		//используется в entity.Set<ComponentCapsuleMovement>()
		public override ComponentCapsuleMovement Create() => new ComponentCapsuleMovement();

		public override void Dispose(indexes disposed)
		{
			foreach (var id in disposed)
			{
				//components[id] = default;
				
				ref var component = ref components[id];
				component.angle = 0;
				component.startPosition = default;
				component.distance = default;
				component.speed = 0;
			}
		}

	}

	#endregion	
}