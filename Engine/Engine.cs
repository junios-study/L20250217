using SDL2;
using System;
using System.Numerics;

namespace L20250217
{
    public class Engine
    {
        private Engine()
        {

        }

        static protected Engine instance;

        //더블 버퍼링
        static public char[,] backBuffer = new char[20, 40];
        static public char[,] frontBuffer = new char[20, 40];

        static public Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }

                return instance;
            }
        }


        protected bool isRunning = true;

        public nint myWindow;
        public nint myRenderer;
        public SDL.SDL_Event myEvent;

        public World world;

        public bool Init()
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                Console.WriteLine("Fail Init.");
                return false;
            }

            myWindow = SDL.SDL_CreateWindow(
                "Game",
                100, 100,
                640, 480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);

            world = new World();

            return true;
        }

        public bool Quit()
        {
            SDL.SDL_DestroyRenderer(myRenderer);
            SDL.SDL_DestroyWindow(myWindow);

            SDL.SDL_Quit();

            return true;
        }


        public void Load(string filename)
        {
            //string tempScene = "";
            //byte[] buffer = new byte[1024];
            //FileStream fs = new FileStream("level01.map", FileMode.Open);

            //fs.Seek(0, SeekOrigin.End);
            //long fileSize = fs.Position;

            //fs.Seek(0, SeekOrigin.Begin);
            //int readCount = fs.Read(buffer, 0, (int)fileSize);
            //tempScene = Encoding.UTF8.GetString(buffer);
            //tempScene = tempScene.Replace("\0", "");
            //string[] scene = tempScene.Split("\r\n");

            List<string> scene = new List<string>();

            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                scene.Add(sr.ReadLine());
            }            
            sr.Close();


            for (int y = 0; y < scene.Count; y++)
            {
                for (int x = 0; x < scene[y].Length; x++)
                {
                    if ( scene[y][x] == '*' )
                    {
                        GameObject wall = new GameObject();
                        wall.Name = "Wall";
                        wall.transform.X = x;
                        wall.transform.Y = y;

                        SpriteRenderer spriteRenderer = wall.AddComponent<SpriteRenderer>();
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("wall.bmp");
                        spriteRenderer.orderLayer = 2;

                        spriteRenderer.Shape = '*';


                        wall.AddComponent<BoxCollider2D>();

                        world.Instanciate(wall);
                    }
                    else if (scene[y][x] == ' ')
                    {
                        //Floor floor = new Floor(x, y, scene[y][x]);
                        //world.Instanciate(floor);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        GameObject player = new GameObject();
                        player.Name = "Player";
                        player.transform.X = x;
                        player.transform.Y = y;

                        player.AddComponent(new PlayerController());
                        SpriteRenderer spriteRenderer = player.AddComponent<SpriteRenderer>();
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 0;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("player.bmp", true);
                        spriteRenderer.processTime = 150.0f;
                        spriteRenderer.maxCellCountX = 5;
                        spriteRenderer.orderLayer = 3;

                        spriteRenderer.Shape = 'P';

                        player.AddComponent<CharacterController2D>();

                        world.Instanciate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        GameObject monster = new GameObject();
                        monster.Name = "Monster";
                        monster.transform.X = x;
                        monster.transform.Y = y;

                        SpriteRenderer spriteRenderer = monster.AddComponent(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("monster.bmp");
                        spriteRenderer.orderLayer = 4;

                        spriteRenderer.Shape = 'M';


                        monster.AddComponent<AIController>(new AIController());
                        CharacterController2D characterController2D = monster.AddComponent<CharacterController2D>();
                        characterController2D.isTrigger = true;




                        world.Instanciate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        GameObject goal = new GameObject();
                        goal.Name = "Goal";
                        goal.transform.X = x;
                        goal.transform.Y = y;

                        SpriteRenderer spriteRenderer = goal.AddComponent(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("goal.bmp");
                        spriteRenderer.orderLayer = 2;


                        spriteRenderer.Shape = 'G';

                        world.Instanciate(goal);
                    }

                    GameObject floor = new GameObject();
                    floor.Name = "Floor";
                    floor.transform.X = x;
                    floor.transform.Y = y;

                    SpriteRenderer spriteRenderer2 = floor.AddComponent(new SpriteRenderer());
                    spriteRenderer2.colorKey.r = 255;
                    spriteRenderer2.colorKey.g = 255;
                    spriteRenderer2.colorKey.b = 255;
                    spriteRenderer2.colorKey.a = 255;
                    spriteRenderer2.LoadBmp("floor.bmp");
                    spriteRenderer2.orderLayer = 1;


                    spriteRenderer2.Shape = ' ';

                    world.Instanciate(floor);

                }
            }

            //loading complete
            //sort
            world.Sort();

            Awake();
        }

        public void ProcessInput()
        {
            Input.Process();
        }


        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            SDL.SDL_SetRenderDrawColor(myRenderer, 0, 0, 0, 0);
            SDL.SDL_RenderClear(myRenderer);

            world.Render();

            for (int Y = 0; Y < 20; ++Y)
            {
                for(int X = 0; X < 40; ++X)
                {
                    if (frontBuffer[Y, X] != backBuffer[Y, X])
                    {
                        frontBuffer[Y, X] = backBuffer[Y, X];
                        Console.SetCursorPosition(X, Y);
                        Console.Write(frontBuffer[Y, X]);
                    }
                }
            }

            SDL.SDL_RenderPresent(myRenderer);

        }

        public void Run()
        {
            Console.CursorVisible = false;


            while (isRunning)
            {
                SDL.SDL_PollEvent(out myEvent);

                Time.Update();

                switch (myEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false;
                        break;
                }

                Update();
                Render();
            }
        }

        public void Awake()
        {
            world.Awake();
        }

        public void SetSortCompare(World.SortCompare inSortCompare)
        {
            world.sortCompare = inSortCompare;
        }
    }
}
