
namespace KyrsovaPark
{
    public class BrootForceAlgoritm
    {
        int m;
        int n;
        int k;
        int[] A;
        int[,] Y;

        public BrootForceAlgoritm(int m, int n, int k, int[] park)
        {
            this.m = m;
            this.n = n;
            this.k = k;
            this.A = park;
        }

        public (int[,] X, int S) GetResult()
        {
            var X = new int[m, n];
            int S = 0;

            foreach (var currentX in AllCombinations())
            {
                var currentS = GetCombinationShine(currentX);

                if (currentS>S)
                {
                    S = currentS;
                    X = currentX;
                }
            }
            return (X, S);
        }

        IEnumerable<int[,]> AllCombinations()
        {
            int availablePointsCount = 0;

            // Підрахунок доступних точок
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (A[i*n + j] == 0)
                    {
                        availablePointsCount++;
                    }
                }
            }
            int[] G = new int[availablePointsCount];
            int index = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (A[i * n + j] == 0)
                    {
                        G[index] = i * n + j;
                        index++;
                    }
                }
            }
            // Генерація комбінацій
            foreach (var combination in NumCombinations(G, k))
            {
                int[,] transformedCombination = new int[m, n];
                foreach (int pos in combination)
                {
                    int row = pos / n;
                    int col = pos % n;
                    transformedCombination[row, col] = 1;
                }
                yield return transformedCombination;
            }
        }

        IEnumerable<int[]> NumCombinations(int[] arr, int k)
        {
            int n = arr.Length;
            int[] combination = new int[k];

            IEnumerable<int[]> GenerateCombinations(int start, int depth)
            {
                if (depth == k)
                {
                    yield return (int[])combination.Clone();
                    yield break;
                }

                for (int i = start; i <= n - (k - depth); i++)
                {
                    combination[depth] = arr[i];
                    foreach (var nextCombination in GenerateCombinations(i + 1, depth + 1))
                    {
                        yield return nextCombination;
                    }
                }
            }

            return GenerateCombinations(0, 0);
        }

        int GetCombinationShine(int[,] С)
        {
            int Shine = 0;
            Y = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (С[i,j] == 1)
                    {
                        Shine = Shine + ShineCount(i, j);
                        AddShineToMatrix(i, j);
                    }
                }
            }
            return Shine;
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
