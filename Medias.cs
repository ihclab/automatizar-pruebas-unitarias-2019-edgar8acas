﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizarPruebasUnitarias {
    
    class Medias {

        /**
         * Calcula y regresa la media artimética
         */
        public static double mediaAritmetica(params object[] vals) { 
            double suma = 0;
            if(vals.Length == 1 && vals[0] == null)
            {
                return 0;
            }
            for (int i = 0; i < vals.Length; i++)
            {
                if(vals[i] != null)
                    suma += (double) vals[i];
            }
            return suma / vals.Length;
        }

        /**
         * Calcula y regresa la raíz enésima = x^(1/n)
         */
        private static double raizEnesima(double x, int n) { 
            return 0;
        }

        /**
         *  Usa raizEnesima para calcular y regresar la media geométrica
         */
        public static double mediaGeometrica(params object[] vals) { 
            return 0;
        }

        /**
         * Este método no está implementado.
         */
        public static double mediaArmonica(params object[] vals) { 
            return 0;
        }
    }
}