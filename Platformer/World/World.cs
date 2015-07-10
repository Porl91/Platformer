using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Platformer.World.Entity;

namespace Platformer.World
{
	public class World
	{
		private Player _player;
		private IList<Entity.Entity> _entities;

		public World()
		{
			_player = new Player();
			_entities = new List<Entity.Entity>();
			_entities.Add(_player);
		}

		public void Update()
		{
			foreach(var entity in _entities)
			{
				entity.Update();
			}
		}

		public void Render(RenderManager renderManager)
		{
			renderManager.ClearScreen(Color.Black);

			foreach (var entity in _entities)
			{
				entity.Render(renderManager, 0, 0);
			}
		}
	}
}
