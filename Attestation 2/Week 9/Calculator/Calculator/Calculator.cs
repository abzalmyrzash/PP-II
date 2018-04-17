using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        public double firstNum, secondNum, result, memory;
        public string operation;
        public bool memoryHasSmth;
        static public bool rad = false, changeNum = false;
        public List<double> results;

        public Calculator()
        {
            firstNum = 0; secondNum = 0;
            result = 0; memory = 0;
            memoryHasSmth = false;
            operation = "";
        }

        public void Calculate(bool need2args)
        {
            if (need2args)
            {

                switch (operation)
                {
                    case "+":
                        result = firstNum + secondNum;
                        break;
                    case "-":
                        result = firstNum - secondNum;
                        break;
                    case "*":
                        result = firstNum * secondNum;
                        break;
                    case "/":
                        result = firstNum / secondNum;
                        break;
                    case "x^y":
                        result = Math.Pow(firstNum, secondNum);
                        break;
                    case "x^(1/y)":
                        result = Math.Pow(firstNum, 1 / secondNum);
                        break;
                }
            }
        }
    }
}
