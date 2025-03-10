﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class World
    {
        List<GameObject> gameObjects = new List<GameObject>();
        //List<GameObject> visibleList = new List<GameObject>();

        public List<GameObject> GetAllGameObjects
        {
            get
            {
                return gameObjects;
            }
        }

        //[1][0][2][3][5][6][7][8][9]
        //
        //[][][][][][][][][]
        //
        public void Instanciate(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                foreach(Component component in gameObjects[i].components)
                {
                    component.Update();
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                SpriteRenderer spriteRender = gameObjects[i].GetComponent<SpriteRenderer>();
                if (spriteRender != null)
                {
                    spriteRender.Render();
                }

            }
        }

        public void Sort()
        {
            //for (int i = 0; i < gameObjects.Count; i++)
            //{
            //    for (int j = i + 1; j < gameObjects.Count; j++)
            //    {
            //        if (gameObjects[i].orderLayer - gameObjects[j].orderLayer > 0)
            //        {
            //            GameObject temp = gameObjects[i];
            //            gameObjects[i] = gameObjects[j];
            //            gameObjects[j] = temp;
            //        }
            //    }
            //}
        }

    }
}
