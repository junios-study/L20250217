using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace L20250217
{
    public class PlayerController : Component
    {
        public SpriteRenderer spriteRenderer;
        public CharacterController2D characterController2D;

        public override void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            characterController2D = GetComponent<CharacterController2D>();

        }

        public override void Update()
        {
            if (Input.GetKeyDown(SDL_Keycode.SDLK_w) || Input.GetKeyDown(SDL_Keycode.SDLK_UP))
            {
                characterController2D.Move(0, -1);
                spriteRenderer.spriteIndexY = 2;
            }
            if (Input.GetKeyDown(SDL_Keycode.SDLK_s) || Input.GetKeyDown(SDL_Keycode.SDLK_DOWN))
            {
                characterController2D.Move(0, 1);

                spriteRenderer.spriteIndexY = 3;

            }
            if (Input.GetKeyDown(SDL_Keycode.SDLK_a) || Input.GetKeyDown(SDL_Keycode.SDLK_LEFT))
            {
                characterController2D.Move(-1, 0);
                spriteRenderer.spriteIndexY = 0;
            }
            if (Input.GetKeyDown(SDL_Keycode.SDLK_d) || Input.GetKeyDown(SDL_Keycode.SDLK_RIGHT))
            {
                characterController2D.Move(1, 0);
                spriteRenderer.spriteIndexY = 1;
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Console.WriteLine($"겹침 감지 : {other.gameObject.Name}");
        }
    }
}
