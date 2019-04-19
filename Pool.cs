using System.Collections.Generic;

namespace PinGenerator
{
    class Pool
    {
        private int min;
        private int max;
        private const int DIGITS = 4;


        public Pool(int min, int max)
        {
            this.min = min;
            this.max = max;
        }


        public List<string> GetRawNumberPool()
        {
            string number = null;
            List<string> numberList = new List<string>();

            for (int i = min; i <= max; i++)
            {
                number = i.ToString().PadLeft(DIGITS, '0');
                numberList.Add(number);
            }

            return numberList;
        }


        public List<string> GetSortedNumberPool(List<string> numberList)
        {
            bool isRepeated = false;
            bool isIncreasing = false;
            List<string> sortedNumberList = new List<string>();

            for (int i = 0; i < numberList.Count; i++)
            {
                isRepeated = CheckRepeatedDigits(numberList[i]);
                if (!isRepeated)
                {
                    isIncreasing = CheckIncreasingDigits(numberList[i]);
                    if (!isIncreasing)
                        sortedNumberList.Add(numberList[i]);
                }
            }

            return sortedNumberList;
        }


        private bool CheckRepeatedDigits(string number)
        {
            bool flag = false;
            char prevDigit = number[0];

            for (int i = 1; i < number.Length; i++)
            {
                char curDigit = number[i];
                if (prevDigit == curDigit)
                {
                    flag = true;
                    return flag;
                }
                prevDigit = curDigit;
            }

            return flag;
        }


        private bool CheckIncreasingDigits(string number)
        {
            bool flag = false;
            char prevDigit = number[0];

            for (int i = 1; i < number.Length; i++)
            {
                if (i != number.Length - 1)
                {
                    char curDigit = number[i];
                    char nextDigit = number[i + 1];
                    if (curDigit - prevDigit == 1 && nextDigit - curDigit == 1)
                    {
                        flag = true;
                        return flag;
                    }
                    prevDigit = curDigit;
                }
            }

            return flag;
        }
    }
}
