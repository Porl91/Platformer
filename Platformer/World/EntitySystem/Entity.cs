
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
		public Vector2 Position;
		public EntityDirection Direction;
		public Level Level;

		private Vector2 _halfDimensions;

		#region Constructors
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
		#endregion

		#region Accessor methods
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
		#endregion

		public abstract void Update(KeyboardState keyboardState);

		public abstract void Render(RenderManager renderManager, Camera camera);
	}
}
