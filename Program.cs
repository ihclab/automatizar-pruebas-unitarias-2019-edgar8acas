using System;
using System.IO;
using System.Collections;

namespace automatizar_pruebas_unitarias_2019_edgar8acas
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList testCases = new ArrayList();
            try
            {
                using(StreamReader sr = new StreamReader("CasosPrueba.txt")) 
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        testCases.Add(line);
                        Console.WriteLine(line);
                    }
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error al leer el archivo: " + e.Message);
            }

            string[] problem1 = splitCase((string) testCases[0]);
            for (int i = 0; i < problem1.Length; i++)
            {
                Console.WriteLine(problem1[i]);
            }
        }
        private static String[] splitCase(String testCase) 
        {
            return testCase.Split(":");
        }

    }
}
