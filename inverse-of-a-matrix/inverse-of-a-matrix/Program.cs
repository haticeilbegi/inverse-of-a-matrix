using System;
using System.IO;

namespace inverse_of_a_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            const int X1 = 5, Y1 = 5;
            var mat1 = new double[X1, Y1]
            {
                {   311111.111111   ,   0.000000    ,   0.000000    ,   -311111.111111  ,   0.000000    }   ,
                {   0.000000    ,   153.635117  ,   311111.111111   ,   0.000000    ,   311111.111111   }   ,
                {   0.000000    ,   311111.111111   ,   840000000.000000    ,   0.000000    ,   420000000.000000    }   ,
                {   -311111.111111  ,   0.000000    ,   0.000000    ,   420311.111111   ,   0.000000    }   ,
                {   0.000000    ,   311111.111111   ,   420000000.000000    ,   0.000000    ,   1134840000.000000   }
            };

            const int X2 = 5, Y2 = 1;
            var mat2 = new double[X2, Y2]
            {
                {   311111.111111   }   ,
                {   0.000000    }   ,
                {   0.000000    }   ,
                {   -311111.111111  }   ,
                {   0.000000    }
            };

            var resultMatrix = new double[X2, Y2];

            for (int i = 0; i < X1; i++)
            {
                double sum = 0;
                for (int j = 0; j < Y1; j++)
                {
                    sum += mat1[i, j] * mat2[j, 0];
                }

                resultMatrix[i, 0] = sum;
            }

            for (int i = 0; i < X2; i++)
            {
                for (int j = 0; j < Y2; j++)
                {
                    Console.WriteLine(resultMatrix[i, j].ToString("0.000") + "\t");
                }
                Console.WriteLine();
            }

            Console.Write("\n\nSonuç matrisini kaydetmek istiyor musunuz (y/n): ");
            var save = Console.ReadLine();
            if (save.ToLower() == "y")
            {
                var fileName = @"D:\matris";
                using (StreamWriter file = new StreamWriter($"{fileName}.xls"))
                {
                    for (int i = 0; i < X2; i++)
                    {
                        for (int j = 0; j < Y2; j++)
                        {
                            file.Write($"{resultMatrix[i, j].ToString("0.000")}\t");
                        }
                        file.Write(Environment.NewLine);
                    }
                }

                Console.WriteLine($"\n\nKG matrisi \"{fileName}.xls\" kaydedildi.\n\n");
            }

            Console.WriteLine("Kapatmak için bir tuşa bas");

            Console.ReadKey();
        }
    }
}
