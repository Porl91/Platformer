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
	
	public abstract class Entity
	{
		public Vector2 Position { get; set; }
		public EntityDirection Direction { get; set; }
		public Level Level { get; set; }
		
		public Entity(Level level, float x, float y)
			: this(level, new Vector2(x, y))
		{
		}

		public Entity(Level level)
			: this(level, new Vector2(0, 0))
		{
		}

		public Entity(Level level, Vector2 position)
		{
			Position = position;
			Direction = EntityDirection.DOWN;
			Level = level;
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

		public abstract void Render(RenderManager renderManager, Camera camera);
	}
}
