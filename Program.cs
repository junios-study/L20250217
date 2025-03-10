using System;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace L20250217
{
    public class Program
    {
        class Data
        {
            public void Count()
            {
                Console.WriteLine("Count");
            }

            private void FuncA()
            {
                Console.WriteLine("private FuncA by 태규");
            }

            protected void Sum()
            {
                Console.WriteLine("protected Sum by 명찬");
            }

            public static void StaticFunction()
            {
                Console.WriteLine("StaticFunction");
            }

            public static void Add(int A, int B)
            {
                Console.WriteLine($"{A} + {B} = {A + B}");
            }

            public int Gold = 1;

            protected int Money = -1000;

            private float HP = -10.5f;

            public int MP
            {
                get;
                set;
            }
        }

        static void Main(string[] args)
        {
            Data d = new Data();
            Type classType = d.GetType();

            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public |
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo info in methods)
            {
                //Console.WriteLine($"{info.Name}");
                if (info.Name.CompareTo("Add") == 0)
                {
                    ParameterInfo[] paramInfos = info.GetParameters();
                    foreach (ParameterInfo paramInfo in paramInfos)
                    {
                        Console.WriteLine(paramInfo.Name);
                    }

                    Object[] param = { 3, 5 };
                    info.Invoke(d, param);
                }
            }

            FieldInfo[] fields = classType.GetFields(BindingFlags.Public |
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                Console.WriteLine($"{field.FieldType} {field.Name} {field.GetValue(d)}");
                field.SetValue(d, 10);
                Console.WriteLine($"{field.FieldType} {field.Name} {field.GetValue(d)}");
            }


            PropertyInfo[] propertyInfos = classType.GetProperties(BindingFlags.Public |
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine($"{propertyInfo.Name} {propertyInfo.GetValue(d)}");

            }



            //Engine.Instance.Init();

            //Engine.Instance.Load("level01.map");
            //Engine.Instance.Run();

            //Engine.Instance.Quit();
        }
    }
}
