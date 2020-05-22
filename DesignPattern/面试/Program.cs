using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面试
{
    class Program
    {
        static void Main(string[] args)
        {
            //	集合{1,1,20,60,2,-10,60,99,50}，请将集合从小到大重新排列并输出元素2在集合中的索引
            int[] nums = new int[] { 1, 1, 20, 60, 2, -10, 60, 99, 50 };
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]==2)
                {
                    Console.WriteLine(i);
                }
            }
        }

    }
}

