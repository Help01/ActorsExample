using Pixeye.Actors;

namespace Source
{
	public class LayerDefault : Layer<LayerDefault>
	{
		// Use to add processors and set up a layer.
		protected override void Setup()
		{
			Add<ProcessorCapsuleMovement>();
		}

		// Use to clean up custom stuff before the layer gets destroyed.
		protected override void OnLayerDestroy() { }
	}
}