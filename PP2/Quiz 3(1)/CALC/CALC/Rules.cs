using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALC
{
    class Rules
    {
        public static bool IsPercentSign(string msg)
        {
            if (msg == "%")
            {
                return true;
            }
            return false;
        }
        public static bool IsPrime(string msg)
        {
            if (msg == "P")
            {
                return true;
            }
            return false;
        }
        public static bool IsBin(string msg)
        {
            if (msg == "BIN")
            {
                return true;
            }
            return false;
        }
        public static bool IsReBin(string msg)
        {
            if (msg == "REBIN")
            {
                return true;
            }
            return false;
        }
        public static bool IsDivisibleSign(string msg)
        {
            if (msg == "/")
            {
                return true;
            }
            return false;
        }
        public static bool IsXPowerY(string msg)
        {
            if (msg == "x^y")
            {
                return true;
            }
            return false;
        }
        public static bool IsSquareSign(string msg)
        {
            if (msg == "x^2")
            {
                return true;
            }
            return false;
        }
        public static bool IsOneOverXSign(string msg)
        {
            if (msg == "1/x")
            {
                return true;
            }
            return false;
        }
        public static bool IsPlusMinus(string msg)
        {
            if (msg == "(+-)")
            {
                return true;
            }
            return false;
        }
        public static bool IsDEL(string msg)
        {
            if (msg == "DEL")
            {
                return true;
            }
            return false;
        }
        public static bool IsRootSign(string msg)
        {
            if (msg == "√")
            {
                return true;
            }
            return false;
        }
        public static bool IsOperator(string msg)
        {
            char[] arr = { '+', '-', '*', '/', '%', '√' };
            return arr.Contains(msg[0]);
        }
        public static bool IsEqualSign(string msg)
        {
            char[] arr = { '=' };
            return arr.Contains(msg[0]);
        }
        public static bool IsZero(string msg)
        {
            char[] arr = { '0' };
            return arr.Contains(msg[0]);
        }
        public static bool IsDigit(string msg)
        {
            char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return arr.Contains(msg[0]);
        }
        public static bool IsNonZeroDigit(string msg)
        {
            char[] arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return arr.Contains(msg[0]);
        }
        public static bool IsSeparator(string msg)
        {
            char[] arr = { ',' };
            return arr.Contains(msg[0]);
        }
        public static bool IsClearSign(string msg)
        {
            string s = "C";
            if (msg == s)
            {
                return true;
            }
            return false;
        }
        public static bool IsOff(string msg)
        {
            string s = "CE";
            if (msg == s)
            {
                return true;
            }
            return false;
        }
        public static bool IsFactorial(string msg)
        {
            string s = "!";
            if (msg == s)
            {
                return true;
            }
            return false;
        }
    }
}
