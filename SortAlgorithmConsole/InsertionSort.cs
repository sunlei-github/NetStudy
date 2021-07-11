using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithmConsole
{
    /// <summary>
    /// 插入排序的平均时间复杂度是O(n2) （n的平方）
    /// 将第一待排序序列第一个元素看做一个有序序列，把第二个元素到最后一个元素当成是未排序序列。
    ///从头到尾依次扫描未排序序列，将扫描到的每个元素插入有序序列的适当位置。
    ///（如果待插入的元素与有序序列中的某个元素相等，则将待插入元素插入到相等元素的后面。）
    /// </summary>
    public class InsertionSort
    {
        public static List<int> Sort(List<int> arr)
        {
            for (int i = 1; i < arr.Count; i++)
            {
                int value = arr[i];

                int index = i - 1;
                //在已经排好序的数组中去查找位置 
                for (; 0 <= index; index--)  
                {
                    if (value < arr[index])  //从小到大排序 如果目前的值 一直是小于当前循环的值 ，那么就一直往后移动当前的值
                    {
                        arr[index + 1] = arr[index];
                    }
                    else
                    {
                        break;   //找到不再小于自己的值后 对应的index+1就是自己的位置
                    }
                }

                arr[index + 1] = value;
            }

            return arr;
        }
    }
}
