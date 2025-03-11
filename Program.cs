using System;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace L20250217
{

    public class Sample
    {
        public delegate int Command(int a, int b);

        public Command command;

        public void Sort()
        {
            if (command(1, 2) > 0)
            {
                //교환
            }
        }
    }

    public class Program
    {
        static int Add(int A, int B)
        {
            return A + B;
        }

        static int Sub(int A, int B)
        {
            return A - B;
        }

        int Mul(int A, int B)
        {
            return A* B;
        }

        static void Main(string[] args)
        {
            Sample.Command command = new Sample.Command((int A, int B) => {
                return A * B;
            });
            Console.WriteLine(command(33, 33));

            //Sample sample = new Sample();
            //sample.command = Add;
            //sample.Sort();

            //Engine.Instance.Init();

            //Engine.Instance.Load("level01.map");
            //Engine.Instance.Run();

            //Engine.Instance.Quit();
        }
    }
}
