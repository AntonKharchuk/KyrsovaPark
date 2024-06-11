namespace KyrsovaPark
{
    public class FileVisualizer
    {
        int m;
        int n;
        int k;
        StreamWriter Writer;
        public FileVisualizer(int m, int n, int k, StreamWriter streamWriter)
        {
            this.m = m;
            this.n = n;
            this.k = k;
            Writer  = streamWriter;
        }
        public void ShowParkWithNumbers()
        {
            Writer.WriteLine("Park M x N");

            Writer.Write($" ");

            for (int i = 0; i < m; i++)
            {
                Writer.Write($"\t{i + 1}");
            }
            Writer.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Writer.Write(i + 1);
                for (int j = 0; j < m; j++)
                {   
                    Writer.Write($"\t{i * m + j + 1}");
                }
                Writer.WriteLine();

            }
            Writer.WriteLine();

        }
        public void ShowPark(int[] park)
        {
            Writer.WriteLine("Park M x N");

            Writer.Write($" ");

            for (int i = 0; i < m; i++)
            {
                Writer.Write($"\t{i + 1}");
            }
            Writer.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Writer.Write(i + 1);
                for (int j = 0; j < m; j++)
                {
                        if (park[j * n + i] == 1)

                        {
                            Writer.Write($"\tg");
                    }
                    else
                    {
                        Writer.Write($"\t-");
                    }
                }
                Writer.WriteLine();

            }
            Writer.WriteLine();
        }

        public void ShowLamps(int[] park, int[,] X)
        {
            Writer.WriteLine("Lamps M x N");

            Writer.Write($" ");

            var diagonalX = new int[n, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    diagonalX[j, i] = X[i, j];
                }
            }

            for (int i = 0; i < m; i++)
            {
                Writer.Write($"\t{i + 1}");
            }
            Writer.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Writer.Write(i + 1);
                for (int j = 0; j < m; j++)
                {
                    if (diagonalX[i, j] == 1)
                    {
                        Writer.Write($"\t0");
                    }
                    else if (park[j * n + i] == 1)
                    {
                        Writer.Write($"\tg");
                    }
                    else
                    {
                        Writer.Write($"\t-");
                    }
                }
                Writer.WriteLine();

            }
            Writer.WriteLine();

        }
    }
}
