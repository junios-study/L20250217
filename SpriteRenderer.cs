using SDL2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class SpriteRenderer : Component
    {
        public int orderLayer;

        public char Shape; //Mesh, Spirte
        public SDL.SDL_Color color;
        public int spriteSize = 30;

        protected bool isAnimaion = false;
        protected IntPtr myTexture;
        protected IntPtr mySurface;

        protected int spriteIndexX = 0;
        protected int spriteIndexY = 0;

        protected SDL.SDL_Color colorKey;

        protected string filename;

        private float elapsedTime = 0;


        public SpriteRenderer()
        {

        }

        public SpriteRenderer(string inFilename, bool inIsAnimation = false)
        {
            LoadBmp(inFilename);
            isAnimaion = inIsAnimation;
        }

        public override void Update()
        {
        }

        public virtual void Render()
        {
            int X = 0;
            int Y = 0;

            Engine.backBuffer[Y, X] = Shape;
            SDL.SDL_Rect myRect;
            myRect.x = X * spriteSize;
            myRect.y = Y * spriteSize;
            myRect.w = spriteSize;
            myRect.h = spriteSize;

            unsafe
            {
                //이미지 정보 가져와서 할일이 있음
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);

                SDL.SDL_Rect sourceRect; //이미지

                if (isAnimaion)
                {
                    if (elapsedTime >= 100.0f)
                    {
                        spriteIndexX++;
                        spriteIndexX = spriteIndexX % 5;
                        elapsedTime = 0;
                    }
                    else
                    {
                        elapsedTime += Time.deltaTime;
                    }


                    int cellSizeX = surface->w / 5;
                    int cellSizeY = surface->h / 5;
                    sourceRect.x = cellSizeX * spriteIndexX;
                    sourceRect.y = cellSizeY * spriteIndexY;
                    sourceRect.w = cellSizeX;
                    sourceRect.h = cellSizeY;
                }
                else
                {
                    sourceRect.x = 0;
                    sourceRect.y = 0;
                    sourceRect.w = surface->w;
                    sourceRect.h = surface->h;
                }

                SDL.SDL_RenderCopy(Engine.Instance.myRenderer,
                    myTexture,
                    ref sourceRect,
                    ref myRect);
            }
        }

        public void LoadBmp(string filename)
        {
            //SDL C, 접근 할 수 있는게 없어서
            mySurface = SDL.SDL_LoadBMP(filename);
            unsafe
            {
                //이미지 정보 가져와서 할일이 있음
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);
                SDL.SDL_SetColorKey(mySurface, 1, SDL.SDL_MapRGB(surface->format,
                    colorKey.r, colorKey.g, colorKey.b));
            }

            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myRenderer, mySurface);

        }
    }
}
