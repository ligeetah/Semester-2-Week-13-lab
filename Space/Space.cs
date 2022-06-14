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
            Point boundary = new Point(this.Width,this. Height);


            g.AddGameObject(Resources.ufoGreen, 200, 200, new HorizentalMove(10, boundary, "left"));
        }




        public void Ongameobjectadded(object sender,EventArgs e)
        {
            this.Controls.Add(sender as PictureBox);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.update();
        }
    }
}
