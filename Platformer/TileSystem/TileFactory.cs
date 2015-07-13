using System.Collections.Generic;
using System.Linq;

using Platformer.Exceptions;

namespace Platformer.TileSystem
{
	public static class TileFactory
	{
		private static Dictionary<int, Tile> _tiles = null;

		public static Dictionary<int, Tile> Tiles
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
			if (!Tiles.ContainsKey(id))
			{
				throw new InvalidTileException("This tile doesn't exist");
			}

			KeyValuePair<int, Tile> match = Tiles.ElementAt(id);

			return match.Value;
		}

		#region tile declaration + definition

		public static Tile Empty;
		public static Tile Dirt;
		public static Tile Grass;

		static TileFactory()
		{
			Empty = InitialiseTile(0, new Empty());
			Dirt = InitialiseTile(1, new Dirt());
			Grass = InitialiseTile(2, new Grass());
		}

		#endregion
	}
}
