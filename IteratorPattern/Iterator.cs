using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorPattern
{
    public interface Iterator
    {
        /// <summary>
        /// 第一个元素
        /// </summary>
        /// <returns></returns>
        object First();

        /// <summary>
        /// 最后一个元素
        /// </summary>
        /// <returns></returns>
        object Last();

        /// <summary>
        /// 得到当前迭代到元素
        /// </summary>
        object CurrentItem();

        /// <summary>
        /// 是否能继续迭代
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        bool MoveNext();

        /// <summary>
        /// 移动到下一个
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        object Next();
    }

    /// <summary>
    /// 自定义的迭代器
    /// </summary>
    public class CustomerIterator : Iterator
    {
        private readonly List<object> objects;

        private int currentIndex = 0;

        public CustomerIterator(List<object> objects)
        {
            this.objects = objects;
        }

        /// <summary>
        /// 设置索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object this[int index]
        {
            get { return objects[index]; }

            set { objects[index] = value; }
        }

        public object First()
        {
            if (objects.Count > 0)
            {
                return objects[0];
            }

            throw new Exception("数组长度为0");
        }

        public object Last()
        {
            if (objects.Count > 0)
            {
                return objects[objects.Count - 1];
            }

            throw new Exception("数组长度为0");
        }

        public object CurrentItem()
        {
            return objects[currentIndex];
        }

        public bool MoveNext()
        {
            return currentIndex < objects.Count - 1;
        }

        public object Next()
        {
            return objects[++currentIndex];
        }
    }
}
