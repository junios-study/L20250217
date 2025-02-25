using System;
using System.Text;

namespace L20250217
{
    public class Program
    {

        static void Main(string[] args)
        {
            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();

            //float elapedTime = 0;
            //while (true)
            //{
            //    Time.Update();
            //    elapedTime += Time.deltaTime;

            //    Console.WriteLine(Time.deltaTime);
            //    if (elapedTime > 500.0f)
            //    {
            //        elapedTime = 0;
            //        Console.WriteLine("Hello World");
            //    }
            //}

        }
    }
}
