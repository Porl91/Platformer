using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Platformer.Render;
using Platformer.TileSystem;
using Platformer.World.EntitySystem;

namespace Platformer.World
{
	public class Level
	{
		private Player _player;
		private IList<Entity> _entities;
		private int[] _map;

		private int _mapWidth;
		private int _mapHeight;

		private int _defaultMapWidth = 2048;
		private int _defaultMapHeight = 512;

		public Level(int mapWidth, int mapHeight)
		{
			Initialise(mapWidth, mapHeight);
		}

		public Level()
		{
			Initialise(_defaultMapWidth, _defaultMapHeight);
		}

		private void Initialise(int mapWidth, int mapHeight)
		{
			_player = new Player(this);
			_entities = new List<Entity>();
			_entities.Add(_player);

			_mapWidth = mapWidth;
			_mapHeight = mapHeight;
			_map = new int[_mapWidth * _mapHeight];

			Random rand = new Random();

			for (int y = 0; y < mapHeight; y++)
			{
				for (int x = 0; x < mapWidth; x++)
				{
					_map[y * mapWidth + x] = y < 5 ? 0 : rand.Next(0, 3);
				}
			}
		}

		public void Update(KeyboardState keyboardState)
		{
			if (keyboardState.IsKeyDown(Keys.Q))
				Initialise(_mapWidth, _mapHeight);

			foreach (var entity in _entities)
			{
				entity.Update(keyboardState);
			}
		}

		public void Render(RenderManager renderManager)
		{
			renderManager.ClearScreen(Color.Black);

			int truncPlayerX = (int)_player.Position.X;
			int truncPlayerY = (int)_player.Position.Y;

			int offsetX = truncPlayerX - (renderManager.ViewportWidth >> 1);
			int offsetY = truncPlayerY - (renderManager.ViewportHeight >> 1);

			int tileStartX = offsetX / Tile.Width;
			int tileStartY = offsetY / Tile.Height;

			int horizTiles = renderManager.ViewportWidth / Tile.Width;
			int vertTiles = renderManager.ViewportHeight / Tile.Height;

			for (int y = tileStartY - 1; y < tileStartY + vertTiles + 1; y++)
			{
				for (int x = tileStartX - 1; x < tileStartX + horizTiles + 1; x++)
				{
					GetTile(x, y).Render(renderManager,
						x * Tile.Width - offsetX,
						y * Tile.Height - offsetY
					);
				}
			}

			var camera = new Camera(this, _player.Position + new Vector2(-renderManager.ViewportWidth >> 1, -renderManager.ViewportHeight >> 1));

			foreach(var entity in _entities)
			{
				entity.Render(renderManager, camera);
			}
		}

		public Tile GetTile(int mapX, int mapY)
		{
			if (mapX < 0 
				|| mapY < 0
				|| mapX >= _mapWidth 
				|| mapY >= _mapHeight)
			{
				return TileFactory.Empty;
			}

			int tileID = _map[mapY * _mapWidth + mapX];

			return TileFactory.GetTileByID(tileID);
		}

		public void SetTile(int mapX, int mapY, int tileID)
		{
			if (mapX < 0 
				|| mapY < 0 
				|| mapX >= _mapWidth 
				|| mapY >= _mapHeight
				|| !TileFactory.TileExists(tileID))
			{
				return;
			}

			_map[mapY * _mapWidth + mapX] = tileID;
		}
	}
}
