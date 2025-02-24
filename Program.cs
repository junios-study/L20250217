namespace L20250217
{
    public class Program
    {

        static void Main(string[] args)
        {
            Engine.Instance.Load();
            Engine.Instance.Run();
            //1 --> 10  ; 올림차순, ascending
            //10 --> 1  ; 내림차순, descending
            int[] numbers = { 1, 5, 2, 3, 1, 7, 8, 10, 9 };

            //Big O n^2
            for(int i = 0; i < numbers.Length; ++i)
            {
                for (int j = i + 1 ; j < numbers.Length; ++j)
                {
                    if (numbers[i] - numbers[j] > 0)
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            for (int i = 0; i < numbers.Length; ++i)
            {
                Console.Write(numbers[i] + ", ");
            }


                //engine.Stop();
            }
    }
}
