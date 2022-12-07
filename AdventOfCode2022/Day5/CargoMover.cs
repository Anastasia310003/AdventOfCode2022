using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day5
{
    public static class CargoMover
    {
        public static void MoveItemByInstruction(int elementsCount, int fromIndex, int toIndex, List<Stack<char>> list)
        {
            for(int i = 0; i < elementsCount; ++i)
            {
                char movedEl = list[fromIndex].Pop();
                list[toIndex].Push(movedEl);
            }
        }

        public static void MoveItemByInstructionSecond(int elementsCount, int fromIndex, int toIndex, List<Stack<char>> list)
        {
            Stack<char> tempStack = new Stack<char>();
            for (int i = 0; i < elementsCount; ++i)
            {
                char movedEl = list[fromIndex].Pop();
                tempStack.Push(movedEl);
            }

            foreach(var item in tempStack)
            {
                list[toIndex].Push(item);
            }
        }
    }
}
