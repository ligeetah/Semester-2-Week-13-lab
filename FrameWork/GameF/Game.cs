using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FrameWork.Movement;
namespace FrameWork.GameF
{
    public class Game
    {
        private List<GameObject> gameobjects;
        public event EventHandler onGameObjectAdded;
        public Game()
        {
            gameobjects = new List<GameObject>();
        }
        public void AddGameObject(Image img,int top,int left,IMovement movement)
        {
            GameObject ob = new GameObject(img,top,left,movement);
            gameobjects.Add(ob);
            onGameObjectAdded?.Invoke(ob.Pb, EventArgs.Empty);
        }
        public void update()
        {
            for (int i = 0; i < gameobjects.Count; i++)
            {
                gameobjects[i].move();
            }
        }
    }

}
