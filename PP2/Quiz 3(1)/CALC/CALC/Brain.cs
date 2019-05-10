using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALC
{
    enum CalcState
    {
        Zero,
        AccumulateDigits,
        AccumulateDigitsWithDecimal,
        Compute,
        Result,
        Error,
        Off
    }

    public delegate void ShowResultDelegate(string msg);
    class Brain
    {
        ShowResultDelegate resultDelegate;
        CalcState currentState = CalcState.Zero;
        string tempNumber;
        string tempNumber2;
        string resultNumber;
        string operation;
        string operation2;
        public Brain(ShowResultDelegate resultDelegate)
        {
            this.resultDelegate = resultDelegate;
            tempNumber = "";
            tempNumber2 = "";
            operation = "";
            operation2 = "";
            resultDelegate("0");
        }
        public void Process(string msg)
        {
            switch (currentState)
            {
                case CalcState.Zero:
                    Zero(false, msg);
                    break;
                case CalcState.AccumulateDigits:
                    AccumulateDigits(false, msg);
                    break;
                case CalcState.AccumulateDigitsWithDecimal:
                    AccumulateDigitsWithDecimal(false, msg);
                    break;
                case CalcState.Compute:
                    Compute(false, msg);
                    break;
                case CalcState.Result:
                    Result(false, msg);
                    break;
                case CalcState.Error:
                    Error(false, msg);
                    break;
                case CalcState.Off:
                    Off(false, msg);
                    break;
                default:
                    break;
            }
        }

        void Zero(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.Zero;
                resultDelegate("0");
                msg = "";
                tempNumber = "";
                resultNumber = "";
                operation = "";

            }
            else
            {
                if (Rules.IsNonZeroDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsSeparator(msg))
                {
                    tempNumber = "0";
                    AccumulateDigitsWithDecimal(true, msg);
                }
                else if (Rules.IsOff(msg))
                {
                    Off(true, msg);
                }
                else if (Rules.IsOperator(msg) || Rules.IsRootSign(msg) || Rules.IsFactorial(msg) || Rules.IsBin(msg))
                {
                    tempNumber = "0";
                    Compute(true, msg);
                }
                else if (Rules.IsDivisibleSign(msg))
                {
                    Error(true, msg);
                }
            }
        }
        void AccumulateDigits(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.AccumulateDigits;
                tempNumber += msg;
                resultDelegate(tempNumber);
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsOperator(msg) || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg) || Rules.IsXPowerY(msg) || Rules.IsFactorial(msg) || Rules.IsBin(msg) || Rules.IsReBin(msg) || Rules.IsPrime(msg))
                {
                    Compute(true, msg);
                }
                else if (Rules.IsEqualSign(msg) && operation.Length > 0)
                {
                    Result(true, msg);
                }
                else if (Rules.IsSeparator(msg))
                {
                    AccumulateDigitsWithDecimal(true, msg);
                }
                else if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsOff(msg))
                {
                    Off(true, msg);
                }
                else if (Rules.IsDivisibleSign(msg))
                {
                    Error(true, msg);
                }
                else if (Rules.IsPrime(msg))
                {
                    Compute(true, msg);
                }
            }
        }
        void AccumulateDigitsWithDecimal(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.AccumulateDigitsWithDecimal;
                tempNumber += msg;
                resultDelegate(tempNumber);
            }
            else
            {
                if (Rules.IsOperator(msg) || Rules.IsXPowerY(msg) || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg))
                {
                    Compute(true, msg);
                }
                else if (Rules.IsDigit(msg))
                {
                    AccumulateDigitsWithDecimal(true, msg);
                }
                else if (Rules.IsEqualSign(msg))
                {
                    Result(true, msg);
                }
                else if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsOff(msg))
                {
                    Off(true, msg);
                }
                else if (Rules.IsDivisibleSign(msg))
                {
                    Error(true, msg);
                }
            }
        }
        void Compute(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.Compute;
                if (operation.Length > 0 && (Rules.IsRootSign(msg) || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg) || Rules.IsFactorial(msg) || Rules.IsBin(msg) || Rules.IsReBin(msg)))
                {
                    operation2 = msg;
                    Calculate();
                    operation2 = "";
                }
                else if (Rules.IsRootSign(msg) || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg) || Rules.IsFactorial(msg) || Rules.IsBin(msg) || Rules.IsReBin(msg))
                {
                    operation = msg;
                    if (operation.Length > 0)
                    {
                        Calculate();
                        resultDelegate(resultNumber);
                    }
                    tempNumber = resultNumber;
                    operation = "";
                }
                else if ((Rules.IsPercentSign(msg) || Rules.IsXPowerY(msg)) && operation.Length > 0)
                {
                    operation2 = msg;
                    if (tempNumber2.Length == 0)
                    {
                        tempNumber2 = tempNumber;
                        tempNumber = "";
                    }
                    else if (tempNumber.Length > 0 && tempNumber2.Length > 0)
                    {
                        Calculate();
                        resultDelegate(tempNumber);
                    }
                }
                else
                {
                    if (operation.Length > 0)
                    {
                        Calculate();
                        resultDelegate(resultNumber);
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
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsOff(msg))
                {
                    Off(true, msg);
                }
                else if (Rules.IsOperator(msg) || Rules.IsXPowerY(msg) || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg) || Rules.IsFactorial(msg) || Rules.IsBin(msg) || Rules.IsReBin(msg) || Rules.IsPrime(msg))
                {
                    Compute(true, msg);
                }
                else if (Rules.IsDivisibleSign(msg))
                {
                    Error(true, msg);
                }
                else if (Rules.IsEqualSign(msg))
                {
                    Result(true, msg);
                }
            }
        }
        void Result(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.Result;
                Calculate();
                Calculate1();
                resultDelegate(resultNumber);
            }
            else
            {
                if (Rules.IsZero(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsNonZeroDigit(msg))
                {
                    tempNumber = "";
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsOperator(msg) || Rules.IsXPowerY(msg) || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg) || Rules.IsFactorial(msg) || Rules.IsBin(msg) || Rules.IsReBin(msg))
                {
                    operation = "";
                    tempNumber = resultNumber;
                    Compute(true, msg);
                }
                else if (Rules.IsSeparator(msg))
                {
                    operation = "";
                    tempNumber = resultNumber;
                    AccumulateDigitsWithDecimal(true, msg);
                }
                else if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsOff(msg))
                {
                    Off(true, msg);
                }
                else if (Rules.IsEqualSign(msg))
                {
                    Result(true, msg);
                }
                else if (Rules.IsDivisibleSign(msg))
                {
                    Error(true, msg);
                }
            }
        }
        void Off(bool isInput, string msg)
        {
            if (isInput)
            {
                msg = "";
                tempNumber = "";
                resultNumber = "";
                operation = "";
                currentState = CalcState.Off;
                resultDelegate("");
            }
            else
            {
                if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
            }
        }
        void Error(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.Error;
                resultDelegate(msg);
                msg = "";
                resultNumber = "";
                tempNumber = "";
            }
            else
            {
                if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
            }
        }

        void Calculate1()
        {

            int x = int.Parse(resultNumber);
            int y = int.Parse(tempNumber);
            int ans = 0;
            if (x > y)
            {
                for (int i = 1; i <= y; i++)
                {
                    if (x % i == 0 && y % i == 0)
                    {
                        ans = i;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= x; i++)
                {
                    if (x % i == 0 && y % i == 0)
                    {
                        ans = i;
                    }
                }
            }
            resultNumber = ans.ToString();

        }

        void Calculate()
        {
            if (operation == "+" && operation2 == "")
            {
                resultNumber = (double.Parse(resultNumber) + double.Parse(tempNumber)).ToString();
            }
            else if (operation == "-" && operation2 == "")
            {
                resultNumber = (double.Parse(resultNumber) - double.Parse(tempNumber)).ToString();
            }
            else if (operation == "*" && operation2 == "")
            {
                resultNumber = (double.Parse(resultNumber) * double.Parse(tempNumber)).ToString();
            }
            else if (operation == "x^y" && operation2 == "")
            {
                double ans = 1;
                double x = double.Parse(resultNumber);
                double y = double.Parse(tempNumber);
                for (int i = 1; i <= y; i++)
                {
                    ans *= x;
                }
                resultNumber = ans.ToString();
            }
            else if (operation == "%" && operation2 == "")
            {
                resultNumber = ((double.Parse(resultNumber) * double.Parse(tempNumber)) / 100).ToString();
            }
            else if (operation2 == "x^y")
            {
                double ans = 1;
                double x = double.Parse(tempNumber);
                double y = double.Parse(tempNumber2);
                for (int i = 1; i <= x; i++)
                {
                    ans *= y;
                }
                tempNumber = ans.ToString();
            }
            else if (operation == "!" && operation2 == "")
            {
                int ans = 1;
                int x = int.Parse(tempNumber);
                for (int i = 1; i <= x; i++)
                {
                    ans *= i;
                }
                resultNumber = ans.ToString();
            }
            else if (operation2 == "!")
            {
                int ans = 1;
                int x = int.Parse(tempNumber);
                for (int i = 1; i <= x; i++)
                {
                    ans *= i;
                }
                tempNumber = ans.ToString();
            }
            else if (operation2 == "%")
            {
                tempNumber = ((double.Parse(tempNumber) * double.Parse(tempNumber2)) / 100).ToString();
            }
            else if (operation == "/" && operation2 == "")
            {
                if (tempNumber == "0")
                {
                    Error(true, "");
                }
                else
                {
                    resultNumber = (double.Parse(resultNumber) / double.Parse(tempNumber)).ToString();
                }
            }
            else if (operation == "√" && operation2 == "")
            {
                resultNumber = ((Math.Sqrt(double.Parse(tempNumber)))).ToString();
            }
            else if (operation == "x^2" && operation2 == "")
            {
                resultNumber = (double.Parse(tempNumber) * double.Parse(tempNumber)).ToString();
            }
            else if (operation == "BIN" && operation2 == "")
            {
                string ans;
                int x = int.Parse(tempNumber);
                ans = FuncTo2(x);
                resultNumber = ans;
            }
            else if (operation2 == "BIN")
            {
                string ans;
                int x = int.Parse(tempNumber);
                ans = FuncTo2(x);
                tempNumber = ans;
            }
            else if (operation == "REBIN" && operation2 == "")
            {

                resultNumber = BinToDec(tempNumber).ToString();
            }
            else if (operation2 == "REBIN")
            {
                tempNumber = BinToDec(tempNumber).ToString();
            }
            //else if (operation == "P" && operation2 == "")
            //{
            //    int x = int.Parse(resultNumber);
            //    int y = int.Parse(tempNumber);
            //    int ans = 0;
            //    if (x > y)
            //    {
            //        for(int i=1; i<Math.Sqrt(y); i++)
            //        {
            //            if(x % i == 0 && y % i == 0)
            //            {
            //                ans = i;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 1; i < Math.Sqrt(x); i++)
            //        {
            //            if (x % i == 0 && y % i == 0)
            //            {
            //                ans = i;
            //            }
            //        }
            //    }
            //    resultNumber = ans.ToString();
            //}
            else if (operation == "1/x" && operation2 == "")
            {
                double ans = 1 / (double.Parse(tempNumber));
                resultNumber = ans.ToString();
            }
            else if (operation == "(+-)" && operation2 == "")
            {
                double ans = -(double.Parse(tempNumber));
                resultNumber = ans.ToString();
            }
            else if (operation2 == "√")
            {
                tempNumber = ((Math.Sqrt(double.Parse(tempNumber)))).ToString();
            }
            else if (operation2 == "x^2")
            {
                tempNumber = (double.Parse(tempNumber) * double.Parse(tempNumber)).ToString();
            }
            else if (operation2 == "1/x")
            {
                double ans = 1 / (double.Parse(tempNumber));
                tempNumber2 = ans.ToString();
            }
            else if (operation2 == "(+-)")
            {
                tempNumber = (-double.Parse(tempNumber)).ToString();
            }
            else if (operation == "DEL" && operation2 == "")
            {
                if (tempNumber.Length == 1)
                {
                    Zero(true, "");
                }
                else
                {
                    resultNumber = "";
                    for (int i = 0; i < tempNumber.Length - 1; i++)
                    {
                        if (i != tempNumber.Length)
                        {
                            resultNumber += tempNumber[i];
                        }
                    }
                }
            }
        }
        public static string FuncTo2(int chislo)
        {
            if (chislo == 1)
                return "1";
            else
                return FuncTo2(chislo / 2) + (chislo % 2);
        }
        private static double BinToDec(string str)
        {
            double res = 0;
            for (int i = 0; i < str.Length; i++)
            {
                res += double.Parse(str[i].ToString()) * Math.Pow(2, str.Length - 1 - i);
            }
            return res;
        }        
    }
}