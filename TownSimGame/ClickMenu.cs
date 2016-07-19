using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TownSimGame
{
    public partial class ClickMenu : Form
    {

        public Location location;
        public Tile tile;
        public Entity entity;
        public Town town;

        public ClickMenu(Town town, Location location, Tile tile, Entity entity)
        {
            this.town = town;
            this.location = location;
            this.tile = tile;
            this.entity = entity;
            InitializeComponent();
        }

        private void ClickMenu_Load(object sender, EventArgs e)
        {
            if(tile == null)
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }
            else
            {
                if(tile.type == TileType.Dirt)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                }
                else if (tile.type == TileType.Road)
                {
                    button1.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                }
                else if (tile.type == TileType.Stone)
                {
                    button1.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
            }
            if(entity == null)
            {

            }else
            {
                button6.Enabled = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tile tile = new Tile(location, TileType.Dirt);
            town.tiles.Add(tile);
            safelyClose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tile.type = TileType.Dirt;
            safelyClose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tile.type = TileType.Stone;
            safelyClose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            town.tiles.Remove(tile);
            safelyClose();
        }

        public void safelyClose()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tile.type = TileType.Road;
            safelyClose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try {
                int height = Convert.ToInt32(textBox1.Text);
                Building build = new Building(location, height);
                town.entities.Add(build);
            }catch(Exception ex)
            {
                Console.WriteLine("He tried non numbers...");
            }
            safelyClose();
        }
    }
}
