using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Platformer.TileSystem;
using Platformer.Entensions;

namespace Platformer.World.EntitySystem
{
	public abstract class DynamicEntity : Entity
	{
		private Vector2 _velocity = new Vector2(0, 0);
		private Vector2 _jumpFactor = new Vector2(0, -3f);
		private bool _onGround = false;

		public DynamicEntity(Level level)
			: base(level)
		{
		}

		public Vector2 Velocity
		{
			get
			{
				if(_velocity == null)
				{
					_velocity = new Vector2(0, 0);
				}

				return _velocity;
			}

			set
			{
				_velocity = value;
			}
		}

		public override void Update(KeyboardState keyboardState)
		{
			ApplyGravity();
		}

		private void ApplyGravity()
		{
			Velocity += EnvironmentVariables.GRAVITY;
			Move(Velocity);
		}

		protected void Jump()
		{
			if(_onGround)
			{
				Velocity += _jumpFactor;
				_onGround = false;
			}
		}

		public virtual void Move(Vector2 deltaMovement)
		{
			var newPosition = Position + deltaMovement;

			var tileStart = ((newPosition - HalfDimensions) / new Vector2(Tile.Width, Tile.Height)).Floor();
			var tileEnd = ((newPosition + HalfDimensions) / new Vector2(Tile.Width, Tile.Height)).Floor();

			var blocked = false;

			List<Vector2> collidedTiles = new List<Vector2>();

			for (var y = tileStart.Y; y <= tileEnd.Y; y++)
			{
				for (var x = tileStart.X; x <= tileEnd.X; x++)
				{
					var xx = (int)x;
					var yy = (int)y;

					var tile = Level.GetTile(xx, yy);

					if (tile.IsObstructive)
					{
						blocked = true;
						collidedTiles.Add(new Vector2(xx, yy));
					}
				}
			}

			if (!blocked)
				Position = newPosition;
			else if (collidedTiles.Any())
			{
				var xx = 0;
				var yy = 0;

				if (deltaMovement.Y > 0)
					yy = (int)(collidedTiles.Select(ct => ct.Y).Min() * Tile.Height - HalfDimensions.Y - 1);
				else
					yy = (int)(collidedTiles.Select(ct => ct.Y).Max() * Tile.Height + HalfDimensions.Y + 1);

				if (Position.Y != yy)
				{
					_onGround = true;
					Velocity = new Vector2(Velocity.X, 0);
				}
				
				Position = new Vector2(Position.X, yy);
			}
		}
	}
}
