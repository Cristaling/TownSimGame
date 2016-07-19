using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TownSimGame
{
    public class GameManager
    {

        Town town;
        Panel board;
        ImageProvider imageProvider;

        int gridSize = 32;

        public GameManager(Panel board)
        {
            this.board = board;
            imageProvider = new ImageProvider();
            town = new Town(gridSize);
        }

        public void handleClick(Point point)
        {
            Location location = new Location(point.X, point.Y);
            Location loc = town.getLocationOnGrid(location);
            while (true) {
                Tile tile = town.getTileAt(loc);
                Entity entity = town.getEntityAt(loc);
                ClickMenu menu = new ClickMenu(town, loc, tile, entity);
                menu.Location = board.PointToScreen(point);
                if (Screen.AllScreens[1].Bounds.Right < menu.Location.X + menu.Width)
                {
                    menu.Location = new Point(menu.Location.X - menu.Width, menu.Location.Y);
                }
                if (Screen.AllScreens[1].Bounds.Bottom < menu.Location.Y + menu.Height)
                {
                    menu.Location = new Point(menu.Location.X, menu.Location.Y - menu.Height);
                }
                menu.ShowDialog();
                if(menu.DialogResult == DialogResult.Cancel){
                    break;
                }
            }
        }

        public void doTick()
        {
            //TODO run Tick
            town.sortEntityList();
        }

        public void drawGame(Graphics boardGr)
        {
            for (int i = 0; i < board.Width; i += gridSize)
            {
                for (int j = 0; j < board.Width; j += gridSize)
                {
                    boardGr.DrawImage(ImageProvider.getTileTexture(TileType.None), new Rectangle(j, i, gridSize, gridSize));
                }
            }
            foreach (Tile tile in town.tiles)
            {
                boardGr.DrawImage(ImageProvider.getTileTexture(tile.type), new Rectangle(tile.getLocation().x, tile.getLocation().y, gridSize, gridSize));
            }
            for (int i = 0; i < board.Width; i += gridSize)
            {
                for (int j = 0; j < board.Width; j += gridSize)
                {
                    boardGr.DrawRectangle(new Pen(Color.Black), new Rectangle(j, i, gridSize, gridSize));
                }
            }
            foreach (Entity entity in town.entities)
            {
                entity.draw(boardGr);
            }
        }

    }
}
