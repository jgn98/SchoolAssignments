using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorClass
    {
        //Opretter 5 public felter der returnerer de 5 matematiske funktioner
        public float Add(float x, float y)
        {
            return x + y;
        }
        public float Multiply(float x, float y) 
        { 
            return x * y; 
        }
        public float Divide(float x, float y)
        {
            return x / y;
        }
        public float Subtract(float x, float y)
        {
            return x - y;
        }
        public float Mod(float x, float y)
        {
            return x % y;
        }
    }
}
