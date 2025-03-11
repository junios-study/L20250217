using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class AIController : Component
    {
        private Random rand = new Random();

        private float elapsedTime = 0;

        public CharacterController2D characterController2D;

        public override void Awake()
        {
            characterController2D = GetComponent<CharacterController2D>();
        }

        public override void Update()
        {
            return;
            if (elapsedTime >= 500.0f)
            {
                int Direction = rand.Next(0, 4);

                if (Direction == 0)
                {
                    characterController2D.Move(0, -1);
                }
                if (Direction == 1)
                {
                    characterController2D.Move(0, 1);
                }
                if (Direction == 2)
                {
                    characterController2D.Move(-1, 0);
                }
                if (Direction == 3)
                {
                    characterController2D.Move(1, 0);
                }
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Console.WriteLine($"겸침 감지 : {other.gameObject.Name}");
        }
    }
}
