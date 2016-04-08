using System;
using System.Linq;

namespace MaxAndMinOfCoins
{
    internal class GetMaxAndMinOfCoins
    {
        private static void Main(string[] args)
        {
            int[] constraints = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int[] V = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int n = constraints[0], S = constraints[1];

            int[] min = new int[S + 1]; //not zero base
            int[] max = new int[S + 1];

            for (int i = 1; i <= S; i++)
            {
                min[i] = S +1;
                max[i] = (S * -1)-1;
            }
            min[0] = max[0] = 0; //when S = V[i],give it a start point

            for (int i = 1; i <= S; i++) //try every combinations between 1 and S
                for (int j = 0; j < n; j++)
                    if (i >= V[j]) //control the range of index
                    {
                        if (min[i] >= (min[i - V[j]] + 1)) //+1 means need one more coin
                            min[i] = min[i - V[j]] + 1;   //record the lowest number of coins
                        if (max[i] <= (max[i - V[j]] + 1))
                            max[i] = max[i - V[j]] + 1;
                    }

            if (max[S] > 0)
                Console.WriteLine(min[S] + " " + max[S]);
            else
                Console.WriteLine("0 0");
        }
    }
}
