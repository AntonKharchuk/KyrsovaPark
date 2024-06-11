
namespace KyrsovaPark
{
    public class Visualizer
    {
        int m;
        int n;
        int k;
        public Visualizer(int m, int n, int k)
        {
            this.m = m;
            this.n = n;
            this.k = k;
        }
        public void ShowParkWithNumbers()
        {
            Console.WriteLine("Park M x N");

            Console.Write($" ");

            for (int i = 0; i < m; i++)
            {
                Console.Write($"\t{i + 1}");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(i+1);
                for (int j = 0; j < m; j++)
                {
                        Console.Write($"\t{i * m + j+1}");
                }
                Console.WriteLine();

            }
            Console.WriteLine();

        }
        public void ShowPark(int[] park)
        {
            Console.WriteLine("Park M x N");

            Console.Write($" ");

            for (int i = 0; i < m; i++)
            {
                Console.Write($"\t{i+1}");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(i+1);
                for (int j = 0; j < m; j++)
                {
                    if (park[i*m + j] == 1)
                    {
                        Console.Write($"\tg");
                    }
                    else
                    {
                        Console.Write($"\t-");
                    }
                }
                Console.WriteLine();

            }
            Console.WriteLine();
        }

        public void ShowLamps(int[] park, int[,] X)
        {
            Console.WriteLine("Lamps M x N");

            Console.Write($" ");

            for (int i = 0; i < m; i++)
            {
                Console.Write($"\t{i + 1}");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < m; j++)
                {
                    if (park[i * m + j] == 1)
                    {
                        Console.Write($"\tg");
                    }
                    else if (X[j,i] == 1)
                    {
                        Console.Write($"\t0");
                    }
                    else
                    {
                        Console.Write($"\t-");
                    }
                }
                Console.WriteLine();

            }
            Console.WriteLine();
        }
    }
}
