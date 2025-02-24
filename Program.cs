using System;
using System.Text;

namespace L20250217
{
    public class Program
    {
        //Network에 접속 했지만 비밀번호가 틀리다.

        class CustomException : Exception
        {
            public CustomException() : base("이거 내가 만든 예외")
            {
            }
        }

        class WrongPasswordException : Exception
        {
            public WrongPasswordException() : base("비번 틀림")
            {
            }
        }

        static void Main(string[] args)
        {
            //Engine.Instance.Load("level02.map");
            //Engine.Instance.Run();

            StreamReader sr = null;
            try
            {
                List<string> scene = new List<string>();

                sr = new StreamReader("level02.map");
                while (!sr.EndOfStream)
                {
                    scene.Add(sr.ReadLine());
                    //throw new CustomException();
                }

               // throw new WrongPasswordException();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.FileName);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.Message);
            }
            catch (WrongPasswordException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //network, file 입출력
                Console.WriteLine("finally");
                sr.Close();
            }
        }
    }
}
