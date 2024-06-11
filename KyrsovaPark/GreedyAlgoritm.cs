
namespace KyrsovaPark
{
    public class GreedyAlgoritm
    {
        int m;
        int n;
        int k;
        int[] A;
        int[,] Y;
        public GreedyAlgoritm(int m, int n, int k, int[] park)
        {
            this.m = m;
            this.n = n;
            this.k = k;
            this.A = park;
            Y = new int[m, n];
        }

        public (int[,] X, int S) GetResult()
        {
            var X = new int[m, n];
            int S = 0;
            int currentK = 0;
            for (int c = 9; c >0 ; c--)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (CanPlace(i,j))
                        {
                            if (ShineCount(i, j)==c)
                            {
                                if (currentK<k-1)
                                {
                                    X[i, j] = 1;
                                    S = S + c;
                                    AddShineToMatrix(i, j);
                                    currentK= currentK+1;
                                }
                                else
                                {
                                    X[i, j] = 1;
                                    S = S + c;
                                    return (X, S);
                                }
                            }
                        }
                    }
                }
            }
            return (X, S);
        }



        bool CanPlace(int a, int b)
        {
            return A[a * n + b] == 0 && Y[a, b] == 0;
        }
        void AddShineToMatrix(int a, int b)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (a + i >= 0 && a + i < m && b + j >= 0 && b + j < n)
                    {
                        Y[a + i, b + j] = 1;
                    }
                }
            }
        }

        int ShineCount(int a, int b)
        {
            int shine = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (a + i >= 0 && a + i < m && b + j >= 0 && b + j < n)
                    {
                        if (CanPlace(a + i, b + j))
                        {
                            shine++;
                        }
                    }
                }
            }
            return shine;
        }
    }
}
