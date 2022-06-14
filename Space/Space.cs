using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameWork.GameF;
using FrameWork.Movement;
using FrameWork.ENUM;
using FrameWork.Collision;
using Space.Properties;
namespace Space
{
    public partial class Space : Form
    {
        Game g;
        public Space()
        {
            InitializeComponent();
        }

        private void Space_Load(object sender, EventArgs e)
        {
            g = new Game();
            g.onGameObjectAdded += new EventHandler(Ongameobjectadded);
            g.onPlayerDie += new EventHandler(removePlayer);
            Point boundary = new Point(this.Width,this. Height);


            g.AddGameObject(Resources.ufoGreen,ObjectTypes.player, 200, 0, new HorizentalMove(10, boundary, "left"));
            //g.AddGameObject(Resources.playerShip3_red, ObjectTypes.player, 200, 800, new HorizentalMove(10, boundary, "left"));
            g.AddGameObject(Resources.playerShip3_red, ObjectTypes.otherobjects, 200, 600, new HorizentalMove(10, boundary, "right"));

            CollisionClass c = new CollisionClass(ObjectTypes.player, ObjectTypes.otherobjects, new PlayerCollision());
            g.addCollision(c);
        }




        public void Ongameobjectadded(object sender,EventArgs e)
        {
            this.Controls.Add(sender as PictureBox);
        }
        public void removePlayer(object sender ,EventArgs e)
        {
            this.Controls.Remove(sender as PictureBox);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.update();
        }
    }
}
