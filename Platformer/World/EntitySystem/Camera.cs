
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Platformer.Render;

namespace Platformer.World.EntitySystem
{
	public class Camera : Entity
	{
		public Camera(Level level, Vector2 position)
			: base(level)
		{
			this.Position = position;
		}

		public override void Update(KeyboardState keyboardState)
		{
		}

		public override void Render(RenderManager renderManager, Camera camera)
		{
		}
	}
}
