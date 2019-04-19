using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    enum CalcState
    {
        Zero,
        AccumulateDigits,
        Compute,
        AccumulateDigitsWithDecimal,
        Result,
        Error
    }

    public delegate void ChangeTextDelegate(string text);

    class Brain
    {
        ChangeTextDelegate changeTextDelegate;
        CalcState calcState = CalcState.Zero;
        string tempNumber = "";
        string resultNumber = "";
        string operation = "";

        public Brain(ChangeTextDelegate changeTextDelegate)
        {
            this.changeTextDelegate = changeTextDelegate;
        }

        public void Process(string msg)
        {
            switch (calcState)
            {
                case CalcState.Zero:
                    Zero(msg, false);
                    break;
                case CalcState.AccumulateDigits:
                    AccumulateDigits(msg, false);
                    break;
                case CalcState.Compute:
                    Compute(msg, false);
                    break;
                case CalcState.AccumulateDigitsWithDecimal:
                    AccumulateDigitsWithDecimal(msg, false);
                    break;
                case CalcState.Result:
                    Result(msg, false);
                    break;
                case CalcState.Error:
                    Error(msg, false);
                    break;
                default:
                    break;
            }
        }

        void Zero(string msg, bool isInput)
        {
            if (isInput)
            {
                calcState = CalcState.Zero;
                tempNumber = "";
                msg = "";
                resultNumber = "";
                operation = "";
                changeTextDelegate("0");
            }
            else
            {
                if (Rules.IsNonZeroDigit(msg))
                {
                    AccumulateDigits(msg, true);
                }   
                else if (Rules.IsSeparator(msg))
                {
                    AccumulateDigitsWithDecimal(msg, true);
                }
                else if (Rules.IsOperation(msg) || Rules.IsOneOperation(msg) || Rules.IsPlusMinus(msg) || Rules.IsDelete(msg))
                {
                    tempNumber = "0";
                    Compute(msg, true);
                }
            }
        }

        void AccumulateDigits(string msg, bool isInput)
        {
            if (isInput)
            {
                calcState = CalcState.AccumulateDigits;
                tempNumber += msg;
                changeTextDelegate.Invoke(tempNumber);
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(msg, true);
                }
                else if (Rules.IsOperation(msg) || Rules.IsOneOperation(msg) || Rules.IsPlusMinus(msg) || Rules.IsDelete(msg))
                {
                    Compute(msg, true);
                }
                else if (Rules.IsEqualSign(msg) && operation.Length!=0)
                {
                    Result(msg, true);
                }
                else if (Rules.IsSeparator(msg))
                {
                    AccumulateDigitsWithDecimal(msg, true);
                }
                else if (Rules.IsC(msg))
                {
                    Zero(msg, true);
                }
                else if (Rules.IsCE(msg))
                {
                    tempNumber = "";
                    AccumulateDigits(tempNumber, true);
                }
            }
        }

        void AccumulateDigitsWithDecimal(string msg, bool isInput)
        {
            if (isInput)
            {
                calcState = CalcState.AccumulateDigitsWithDecimal;
                tempNumber += msg;
                changeTextDelegate.Invoke(tempNumber);
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigitsWithDecimal(msg, true);
                }
                else if (Rules.IsOperation(msg) || Rules.IsOneOperation(msg) || Rules.IsPlusMinus(msg) || Rules.IsDelete(msg))
                {
                    Compute(msg, true);
                }
                else if (Rules.IsEqualSign(msg))
                {
                    Result(msg, true);
                }
                else if (Rules.IsC(msg))
                {
                    Zero(msg, true);
                }
                else if (Rules.IsCE(msg))
                {
                    tempNumber = "";
                    AccumulateDigits(tempNumber, true);
                }
            }
        }

        void Compute(string msg, bool isInput)
        {
            if (isInput)
            {
                calcState = CalcState.Compute;
                if (Rules.IsOneOperation(msg) || Rules.IsPlusMinus(msg) || Rules.IsDelete(msg))
                {
                    operation = msg;
                    if (operation.Length > 0)
                    {
                        if (Rules.IsOneOperation(msg))
                        {
                            OneOperation();
                        }
                        if (Rules.IsPlusMinus(msg))
                        {
                            PlusMinus();
                        }
                        if (Rules.IsDelete(msg))
                        {
                            Delete();
                        }
                        changeTextDelegate(resultNumber);
                    }
                    resultNumber = tempNumber;
                    operation = "";
                }
                else
                {
                    if (operation.Length > 0)
                    {
                        if (Rules.IsOperation(msg))
                        {
                            Operation();
                            changeTextDelegate(resultNumber);
                        }
                    }
                    else
                    {
                        resultNumber = tempNumber;
                    }
                    operation = msg;
                    tempNumber = "";
                }                
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(msg, true);
                }
                else if (Rules.IsC(msg))
                {
                    Zero(msg, true);
                }
                else if (Rules.IsCE(msg))
                {
                    tempNumber = "";
                    AccumulateDigits(tempNumber, true);
                }
                //else if (Rules.IsOperation(msg) || Rules.IsOneOperation(msg) || Rules.IsPlusMinus(msg) || Rules.IsDelete(msg))
                //{
                //    Compute(msg, true);
                //}
            }
        }

        void Result(string msg, bool isInput)
        {
            if (isInput)
            {
                calcState = CalcState.Result;
                if (Rules.IsOperation(operation))
                {
                    Operation();
                }
                if (Rules.IsOneOperation(operation))
                {
                    OneOperation();
                }
                if (Rules.IsPlusMinus(operation))
                {
                    PlusMinus();
                }
                if (Rules.IsDelete(operation))
                {
                    Delete();
                }
                operation = "";
                changeTextDelegate.Invoke(resultNumber);                
            }
            else
            {
                if (Rules.IsOperation(msg) || Rules.IsOneOperation(msg) || Rules.IsPlusMinus(msg) || Rules.IsDelete(msg))
                {
                    Compute(msg, true);
                }
                else if (Rules.IsNonZeroDigit(msg))
                {
                    tempNumber = "";
                    AccumulateDigits(msg, true);
                }
                else if (Rules.IsZero(msg))
                {
                    Zero(msg, true);
                }
                else if (Rules.IsSeparator(msg))
                {
                    operation = "";
                    tempNumber = resultNumber;
                    AccumulateDigitsWithDecimal(msg, true);
                }
                else if (Rules.IsC(msg))
                {
                    Zero(msg, true);
                }
                else if (Rules.IsCE(msg))
                {
                    tempNumber = "";
                    AccumulateDigits(tempNumber, true);
                }
            }
        }

        void Error(string msg, bool isInput)
        {
            if (isInput)
            {
                calcState = CalcState.Error;
                msg = "";
                resultNumber = "";
                tempNumber = "ERROR";
                changeTextDelegate(tempNumber);
            }
            else
            {
                if (Rules.IsC(msg))
                {
                    Zero(msg, true);
                }
            }
        }

        void  Operation()
        {
            if (operation == "+")
            {
                resultNumber = (double.Parse(resultNumber) + double.Parse(tempNumber)).ToString();
            }
            if (operation == "-")
            {
                resultNumber = (double.Parse(resultNumber) - double.Parse(tempNumber)).ToString();
            }
            if (operation == "*")
            {
                resultNumber = (double.Parse(resultNumber) * double.Parse(tempNumber)).ToString();
            }
            if (operation == "/")
            {
                if (Rules.IsZero(tempNumber))
                {
                    Error("ERROR", true);
                }
                else
                {
                    resultNumber = (double.Parse(resultNumber) / double.Parse(tempNumber)).ToString();
                }
            }
            if (operation == "%")
            {
                resultNumber = (double.Parse(resultNumber) * double.Parse(tempNumber)/100).ToString();
            }
            if (operation == "x^y")
            {
                double result = 1;
                double resNumber = double.Parse(resultNumber);
                double tNumber = double.Parse(tempNumber);
                for(int i=0; i<tNumber; i++)
                {
                    result *= resNumber;
                }
                resultNumber = result.ToString();
            }
        }

        void OneOperation()
        {
            if (operation == "1/x")
            {
                resultNumber = (float.Parse("1") / double.Parse(tempNumber)).ToString();
            }
            if (operation == "x^2")
            {
                resultNumber = (float.Parse(tempNumber) * double.Parse(tempNumber)).ToString();
            }
            if(operation== "√")
            {
                if (double.Parse(tempNumber) < 0)
                {
                    Error("ERROR", true);
                }
                else
                {
                    resultNumber = (Math.Sqrt(double.Parse(tempNumber))).ToString();
                }
            }
            if (operation == "!")
            {
                if (double.Parse(tempNumber) < 0)
                {
                    Error("ERROR", true);
                }
                else
                {
                    double res = 1;
                    double a = double.Parse(tempNumber);
                    if (a == 1 || a == 0)
                    {
                        res = 1;
                    }
                    else
                    {
                        for (int i = 1; i <= a; i++)
                        {
                            res *= i;
                        }
                    }
                    resultNumber = res.ToString();
                }                
            }
        }

        void PlusMinus()
        {
            if (operation == "±")
            {
                resultNumber = (-double.Parse(tempNumber)).ToString();
            }
        }

        void Delete()
        {
            if (operation == "DEL")
            {
                if (tempNumber.Length == 1)
                {
                    Zero("", true);
                }
                else
                {
                    resultNumber = "";
                    for(int i=0; i<tempNumber.Length-1; i++)
                    {
                        if (i != tempNumber.Length)
                        {
                            resultNumber += tempNumber[i];
                        }
                    }
                }
            }
        }
    }
}
