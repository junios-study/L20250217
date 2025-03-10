using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class GameObject
    {
        List<Component> components = new List<Component>();

        public bool isTrigger = false;
        public bool isCollide = false;

        string Name;

        protected static int gameObjectCount = 0;

        public GameObject()
        {
            Init();
            gameObjectCount++;
            Name = $"GameObject({gameObjectCount})";
        }

        ~GameObject()
        {
            gameObjectCount--;
        }

        public void Init()
        {
            AddComponent<Transform>(new Transform());
        }

        public T AddComponent<T>(T inComponent)  where T : Component
        {
            components.Add(inComponent);

            return inComponent;
        }

        public virtual void Update()
        {
            //모든 컴포넌트의 update 함수 실행해줘.
        }

        public bool PredictCollision(int newX, int newY)
        {
            //for (int i = 0; i < Engine.Instance.world.GetAllGameObjects.Count; ++i)
            //{
            //    if (Engine.Instance.world.GetAllGameObjects[i].isCollide == true &&
            //            Engine.Instance.world.GetAllGameObjects[i].X == newX &&
            //            Engine.Instance.world.GetAllGameObjects[i].Y == newY)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }
    }
}

