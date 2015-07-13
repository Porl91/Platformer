using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Platformer.Render;
using Platformer.TileSystem;

namespace Platformer.World.EntitySystem
{
	public enum EntityDirection
	{
		UP,
		DOWN,
		LEFT,
		RIGHT
	}
	
	///<summary>
	/// Base entity class.
	///</summary>
	public abstract class Entity
	{
		public Vector2 Position { get; set; }
		public EntityDirection Direction { get; set; }
		
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
			Direction = EntityDirection.DOWN;
		}

		private Vector2 _halfDimensions { get; set; }

		public Vector2 HalfDimensions
		{
			get
			{
				if (_halfDimensions == null)
				{
					_halfDimensions = new Vector2(Tile.Width >> 1, Tile.Height >> 1);
				}

				return _halfDimensions;
			}

			set
			{
				_halfDimensions = value;
			}
		}

		public abstract void Update(KeyboardState keyboardState);

		public abstract void Render(RenderManager renderManager, int x, int y);

		protected virtual void InitialiseHalfDimensions(Vector2 halfDimensions)
		{
			HalfDimensions = halfDimensions;
		}

		public virtual void Move(Vector2 deltaMovement)
		{
			Position += deltaMovement;
		}
	}
}
