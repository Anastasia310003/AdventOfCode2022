using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day5
{
    public static class DataParser
    {
        public static string[] GetStructureInput()
        {
            string text = System.IO.File.ReadAllText(@"D:\AdventOfCode2022\AdventOfCode2022\Inputs\Day5DataStructureInput.txt");
            return text.Split(
                    new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        public static List<Stack<char>> ParseInputReturnListOfStacks(string[] input)
        {
            var resultList = new List<Stack<char>>();
            int stacksCount;
            //The last element is space not the number
            string lastRow = input[input.Length - 1];
            bool res = int.TryParse(lastRow[lastRow.Length - 2].ToString(), out stacksCount);

            for (int i = 0; i < stacksCount; ++i)
                resultList.Add(new Stack<char>());

            if (!res)
            throw new Exception();

            char currChar;
            int currResultListIndex;
            for (int inputIndex = 0; inputIndex < input.Length; ++inputIndex)
            {
                for(int rowIndex = 0; rowIndex < input[inputIndex].Length; ++rowIndex)
                {
                    currChar = input[inputIndex][rowIndex];
                    
                    if (currChar >= 'A' && currChar <= 'Z')
                    {
                        //insert into stack based by position;
                        currResultListIndex = Convert.ToInt32(rowIndex / 4);
                        resultList[currResultListIndex].Push(currChar);
                    }

                    if (rowIndex == 0 && string.IsNullOrWhiteSpace(currChar.ToString()))
                        rowIndex += 4;
                    else if (currChar == '[')
                        continue;
                    else
                        rowIndex += 3;
                }
            }

            //reversing the stack. needs to be refactored
            for(int i = 0; i < resultList.Count; ++i)
            {
                var st = new Stack<char>();
                while(resultList[i].Count != 0)
                    st.Push(resultList[i].Pop());

                resultList[i] = st;
            }

            return resultList;
        }

        public static string[] GetInstructions()
        {
            string text = System.IO.File.ReadAllText(@"D:\AdventOfCode2022\AdventOfCode2022\Inputs\Day5DataInstructionsInput.txt");
            return text.Split(
                    new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        public static int[] ParseInstructions(string inputRow)
        {
            var resultArr = new int[3];
            int resultArrIndex = 0;
            int num;

            for(int i = 0; i < inputRow.Length; ++i)
            {
                if((char.IsDigit(inputRow[i]) && i < inputRow.Length - 1 && char.IsDigit(inputRow[i + 1]))
                    /*|| (char.IsDigit(inputRow[i]) && int.TryParse(inputRow[i].ToString(), out num))*/)
                {
                    string combinedNumber = inputRow[i].ToString() + inputRow[i + 1].ToString();
                    if (int.TryParse(combinedNumber, out num))
                    {
                        resultArr[resultArrIndex] = num;
                        i++;
                        resultArrIndex++;
                    }
                }
                else if(char.IsDigit(inputRow[i]) && int.TryParse(inputRow[i].ToString(), out num))
                {
                    resultArr[resultArrIndex] = num;
                    resultArrIndex++;
                }
            }

            return resultArr;
        }
    }
}
