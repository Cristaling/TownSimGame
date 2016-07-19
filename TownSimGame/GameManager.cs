using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TownSimGame
{
    class GameManager
    {

        Town town;
        Size size;
        ImageProvider imageProvider;

        int gridSize = 32;

        public GameManager(Size size)
        {
            this.size = size;
            imageProvider = new ImageProvider();
            town = new Town(gridSize);
        }

        public void handleClick(Point point)
        {
            Location location = new Location(point.X, point.Y);
            Location loc = town.getLocationOnGrid(location);
            Tile tile = town.getTileAt(loc);
            Entity entity = town.getEntityAt(loc);

        }

        public void doTick()
        {

            town.sortEntityList();
        }

        public void drawGame(Graphics board)
        {
            for(int i = 0; i < size.Width; i += gridSize)
            {
                for(int j = 0; j < size.Width; j += gridSize)
                {
                    board.DrawImage(ImageProvider.getTileTexture(TileType.None), j, i);
                    board.DrawRectangle(new Pen(Color.Black), new Rectangle(j, i, gridSize, gridSize));
                }
            }
            foreach (Tile tile in town.getTiles())
            {
                board.DrawImage(ImageProvider.getTileTexture(tile.type), tile.getLocation().x, tile.getLocation().y);
            }
            foreach(Entity entity in town.getEntities())
            {
                entity.draw(board);
            }
        }

    }
}
