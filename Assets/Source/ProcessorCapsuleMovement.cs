using Pixeye.Actors;
using UnityEngine;

namespace Source
{
	sealed class ProcessorCapsuleMovement : Processor, ITick
	{
		[ExcludeBy(Component.ExcludeExample)]
		Group<ComponentRotation, ComponentCapsuleMovement> _rotatedCapsules;
		static readonly float Pi2 = 2 * Mathf.PI;
		public override void HandleEcsEvents()
		{
			//Срабатывает когда сущность добавляется в группу
			foreach (var capsule in _rotatedCapsules.added)
			{
				var cCapsuleMovement = capsule.componentCapsuleMovement();
				cCapsuleMovement.startPosition = capsule.transform.position;
			}
		}

		public void Tick(float delta)
		{
			foreach (var capsule in _rotatedCapsules)
			{
				//capsule.Has<ComponentExcludeExample>() - альтернативный способ узнать наличие компонента
				//capsule.TryGet(out ComponentExcludeExample component) - получить компонент, если он есть
				//capsule.Get<ComponentExcludeExample>() - получить или добавить компонент
				//capsule.exist - возвращает жива ли текущая сущность
				//capsule.Remove<ComponentRotation>(); - удаляет компонент с сущности
				//capsule.GetMono<Rigidbody>() - возвращает unity-компонент (никакого кеша нет, аналогично вызову GetComponentInChildren)
				//capsule.Release() - уничтожает сущность
				
				var cRotation = capsule.componentRotation();
				var cCapsuleMovement = capsule.componentCapsuleMovement();
				float angle = cCapsuleMovement.angle;
				float rotationProgress = cRotation.progress;
				var vector = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
				capsule.transform.rotation = Quaternion.AngleAxis(360 * rotationProgress, Vector3.up) * Quaternion.LookRotation(-vector);
				capsule.transform.position = cCapsuleMovement.startPosition + vector * cCapsuleMovement.distance;

				if ((rotationProgress += cRotation.speed * delta) > 1)
					rotationProgress = 0;
				cRotation.progress = rotationProgress;
				
				if ((angle += cCapsuleMovement.speed * delta) > Pi2)
					angle = 0;
				cCapsuleMovement.angle = angle;
			}
		}
	}
}