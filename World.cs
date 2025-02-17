using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class World
    {
        public GameObject[] gameObjects;
        public void Update()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Update();
            }
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Render();
            }
        }

    }
}
