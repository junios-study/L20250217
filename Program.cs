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

        public static void Test1(int a)
        {
            Console.WriteLine($"Test {a}");
        }

        public static int Test2(int a)
        {
            Console.WriteLine($"Test2 {a}");

            return a;
        }

        public delegate void DelegateSample();
        public delegate void DelegateSample1(int a);

        public static void Main(string[] args)
        {
            //클래스 결합도를 낮춘다.
            DelegateSample d = Test;
            DelegateSample1 d1 = Test1;

            Action<int> helloAction = Test1;
            helloAction += Test1;
            helloAction(1);
            Func<int, int> f = Test2;
            f += (int number) =>
            {
                Console.WriteLine($"number {number}");
                return 10;
            };
            Console.WriteLine(f(2));


            //Engine.Instance.Init();
            //Engine.Instance.SetSortCompare(Compare);

            //Engine.Instance.Load("level01.map");
            //Engine.Instance.Run();

            //Engine.Instance.Quit();
        }
    }
}
