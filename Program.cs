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
                    }
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error al leer el archivo: " + e.Message);
            }

            foreach (var testCase in testCases)
            {
                String[] splittedData = splitCase(testCase);
                object[] inputs = convertData(splittedData[2]);
                object expected = convertData(splittedData[3]);
                Console.WriteLine(assert(expected, inputs, splittedData[1]));    
            }
        }
        private static String[] splitCase(String testCase) 
        {
            return testCase.Split(":");
        }

        private static object convertData(String data)
        {
            object convertedData;
            switch (data)
            {
                case "NULL": 
                    convertedData = null;
                break;

                case "Exception":
                    convertedData = data;
                break;

                default:
                    convertedData = Convert.ToDouble(data);
                break;
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

        private static bool assert(object expected, object[] inputs, String methodToTest, ref object result)
        {
            //object[] expectedData = expected as object[];
            try
            {
                result = (double) test(inputs, methodToTest);
                if ((double) expected == (double) result)
                    return true;
                return false;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                if((string) expected == "Exception")
                {
                    result = "Exception";
                    return true;     
                }
                return false;
            }
        }
    }
}
