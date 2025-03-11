using System;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace L20250217
{
    //마우스 누르면 실행 함수 등록해줘.
    public class EventClass
    {
        public delegate void DelegateSample();
        public DelegateSample delegateSample;

        public event DelegateSample EventSample;

        public void Do()
        {
            EventSample?.Invoke();
        }
    }

    public class Program
    {
        public static int Compare(GameObject first, GameObject second)
        {
            SpriteRenderer spriteRenderer1 = first.GetComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer2 = second.GetComponent<SpriteRenderer>();
            if (spriteRenderer1 == null || spriteRenderer2 == null)
            {
                return 0;
            }

            return spriteRenderer1.orderLayer - spriteRenderer2.orderLayer;
        }

        public static void Test()
        {
            Console.WriteLine("Test");
        }

        public static void Main(string[] args)
        {

            EventClass eventClass = new EventClass();

            eventClass.delegateSample = Test;
            eventClass.delegateSample(); //문법적으로 맞지만 논리적으로 틀린


            eventClass.EventSample += Test; //구독
            eventClass.EventSample -= Test; //구독 해지


            //Engine.Instance.Init();
            //Engine.Instance.SetSortCompare(Compare);

            //Engine.Instance.Load("level01.map");
            //Engine.Instance.Run();

            //Engine.Instance.Quit();
        }
    }
}
