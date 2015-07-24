using System.Collections.Generic;
using System.Linq;

using Platformer.Exceptions;

namespace Platformer.TileSystem
{
	public static class TileFactory
	{
		private static Dictionary<int, Tile> _tiles = null;

		private static Dictionary<int, Tile> Tiles
		{
			get
			{
				if (_tiles == null)
				{
					_tiles = new Dictionary<int, Tile>();
				}

				return _tiles;
			}
		}

		private static Tile InitialiseTile(int index, Tile t)
		{
			if (Tiles.ContainsKey(index))
			{
				throw new DuplicateTileException("A single tile index has been associated with multiple Tile instances");
			}

			t.Key = index;
			Tiles.Add(index, t);

			return t;
		}

		public static Tile GetTileByID(int id)
		{
			if (!TileExists(id))
			{
				throw new InvalidTileException("This tile doesn't exist");
			}

			KeyValuePair<int, Tile> match = Tiles.ElementAt(id);

			return match.Value;
		}

		public static bool TileExists(int tileID)
		{
			return Tiles.ContainsKey(tileID);
		}

		public static void UpdateTypes()
		{
			foreach (var tile in Tiles)
			{
				tile.Value.UpdateType();
			}
		}

		#region tile declaration + definition

		public static Tile Empty;
		public static Tile Dirt;
		public static Tile Grass;
		public static Tile Water;

		static TileFactory()
		{
			Empty = InitialiseTile(0, new Empty());
			Dirt = InitialiseTile(1, new Dirt());
			Grass = InitialiseTile(2, new Grass());
			Water = InitialiseTile(3, new Water());
		}

		#endregion
	}
}
