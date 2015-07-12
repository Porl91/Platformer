using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Platformer.World.EntitySystem
{
	public enum PlayerDirection
	{
		UP, 
		DOWN, 
		LEFT,
		RIGHT
	}

	public abstract class Entity
	{
		public Vector2 Position { get; set; }
		public PlayerDirection Direction { get; set; }

		public Entity(float x, float y)
			: this(new Vector2(x, y))
		{
		}

		public Entity()
			: this(new Vector2(0, 0))
		{
		}

		public Entity(Vector2 position)
		{
			Position = position;
			Direction = PlayerDirection.DOWN;
		}

		public abstract void Update(KeyboardState keyboardState);

		public abstract void Render(RenderManager renderManager, int x, int y);

		public void Move(Vector2 deltaMovement)
		{
			Position += deltaMovement;
		}
	}
}
