using System;
using System.IO;
using System.Collections;
using AutomatizarPruebasUnitarias;
using System.Collections.Generic;

namespace automatizar_pruebas_unitarias_2019_edgar8acas
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<String> testCases = new List<String>();
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
        }
        private static String[] splitCase(String testCase) 
        {
            return testCase.Split(":");
        }

        private static object[] convertData(String data)
        {
            string[] separatedData = data.Split(" ");
            object[] convertedData = new object[separatedData.Length]; 
            for (int i = 0; i < separatedData.Length; i++)
            {
                switch (separatedData[i])
                {
                    case "NULL": 
                        convertedData[i] = null;
                    break;

                    case "0":
                        convertedData[i] = 0;
                    break;

                    default:
                        double n = Convert.ToDouble(separatedData[i]);
                        if(n % 1 == 0)
                        {   // convirtiendo enteros
                            convertedData[i] = Convert.ToInt32(n);
                        } 
                        else
                        {   
                            convertedData[i] = n;
                        }
                    break;
                }
            }
            return convertedData;
        }
        private static object test(object[] inputs, String methodToTest)
        {
            switch (methodToTest)
            {
                case "mediaAritmetica":
                    return Medias.mediaAritmetica(inputs);

                case "mediaGeometrica":
                    return Medias.mediaGeometrica(inputs);

                case "mediaArmonica":
                    return Medias.mediaArmonica(inputs);
                
                default:
                    throw new Exception("Unvalid method");
                
            }
            
        }

        private static bool assert(object expected, object resulted)
        {
            return expected == resulted;
        }
    }
}
