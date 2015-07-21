using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Platformer.Entensions;
using Platformer.Exceptions;
using Platformer.TileSystem;

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
				if (_velocity == null)
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
			Move(Velocity);
		}

		private void ApplyGravity()
		{
			Velocity += EnvironmentVariables.GRAVITY;
		}

		protected void Jump()
		{
			if (_onGround && Velocity.Y == 0)	// Blegh - needs rethinking
			{
				Velocity += _jumpFactor;
				_onGround = false;
			}
		}

		public virtual void Move(Vector2 deltaMovement)
		{
			if (deltaMovement.X != 0 && deltaMovement.Y != 0)
				throw new MultipleMovementAxisException("Dynamic entities may only move on a single axis at one time");

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

			BindPositionToCollisions(collidedTiles, deltaMovement, newPosition, blocked);
		}

		private void BindPositionToCollisions(List<Vector2> collidedTiles, Vector2 deltaMovement, Vector2 newPosition, bool blocked)
		{
			if (!blocked)
				Position = newPosition;
			else if (collidedTiles.Any())
			{
				var xx = 0;
				var yy = 0;
				var boundToFloor = false;

				if (deltaMovement.X != 0)
				{
					if (deltaMovement.X > 0)
						xx = (int)(collidedTiles.Select(ct => ct.X).Min() * Tile.Width - HalfDimensions.X - 1);
					else
						xx = (int)(collidedTiles.Select(ct => ct.X).Max() * Tile.Width + Tile.Width + HalfDimensions.X + 1);
				}

				if (deltaMovement.Y != 0)
				{
					if (deltaMovement.Y > 0)
					{
						yy = (int)(collidedTiles.Select(ct => ct.Y).Min() * Tile.Height - HalfDimensions.Y - 1);
						boundToFloor = true;
					}
					else
						yy = (int)(collidedTiles.Select(ct => ct.Y).Max() * Tile.Height + Tile.Height + HalfDimensions.Y);
				}

				if (boundToFloor)
				{
					_onGround = true;
					Velocity = new Vector2(Velocity.X, 0);
				}

				if (deltaMovement.X != 0)
					Position = new Vector2(xx, Position.Y);

				if (deltaMovement.Y != 0)
					Position = new Vector2(Position.X, yy);
			}
		}
	}
}
