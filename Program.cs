﻿using System;
using System.Text;

namespace L20250217
{
    public class Program
    {

        static void Main(string[] args)
        {
            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();

        }
    }
}
