
namespace KyrsovaPark
{
    public class Generator
    {
        int m;
        int n;
        int k;
        int numOfGreenFields;
        public Generator(int m, int n, int k, int numOfGreenFields) 
        { 
            this.m = m;
            this.n = n;
            this.k = k;
            this.numOfGreenFields = numOfGreenFields;
        }  

        public int[] GeneratePark()
        {
            var park = new int[m*n]; 
            
            var random = new Random();

            var greenZonesSet = 0;
            while (greenZonesSet!= numOfGreenFields) 
            { 
                var randomPoint = random.Next(0, park.Length);
                if (park[randomPoint] == 0)
                {
                    park[randomPoint] = 1;
                    greenZonesSet++;
                }
            }
            return park;
        }
    }
}
