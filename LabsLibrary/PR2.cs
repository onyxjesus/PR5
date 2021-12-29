using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabsLibrary
{
    public class Lab2
    {      
        public static double SumProb(int n, int q)
        {
            int m, i, j, msize = 1, size = 6 * n + 1;
            double[] prob = new double[size], pnew = new double[size];
            double vsix = 1D / 6;

            if ((q < n) || (q > 6 * n))
                return 0;

            for (i = 0; i < size; i++)
                pnew[i] = (prob[i] = 0);
            prob[0] = 1D;
            for (m = 0; m < n; m++)
            {
                for (i = m; i <= 6 * m; i++)
                    for (j = 1; j < 7; j++)
                        pnew[i + j] += prob[i];
                msize += 6;
                for (i = 0; i < msize; i++)
                {
                    prob[i] = vsix * pnew[i];
                    pnew[i] = 0;
                }
            }
            return prob[q];
        }
        public string GetResult(string stringN, string stringQ)
        {     
            List<int> Num = new List<int>();
            List<string> Answ = new List<string>();
            var n = Shared.ConvertToInt32(stringN, "n");
            var q = Shared.ConvertToInt32(stringQ, "q");
         
       
            if (n > 500 || q > 3000)
            {
                throw new Exception("Numbers are out of range");
            }
            var ans = SumProb(n, q);
           
            string a = Convert.ToString(ans);
            Answ.Add(a);
            string result = string.Join(";", Answ.ToArray());
            return result;
        }
    }

}

