using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomCache
{
    /// <summary>
    /// 如果缓存的数据量较大 使用一个线程安全的字典（使用lock的字典）性能可能达不到预期的效果
    /// 可以通过获取服务器的 核数 每个核创建一个对应的字典来轮流读取 存放缓存的数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheManager<T>
    {
        /// <summary>
        /// 线程安全字典 保证多线程操作数据的安全性
        /// </summary>
        private static ConcurrentDictionary<string, CacheModel<T>> cacheDictionary = new ConcurrentDictionary<string, CacheModel<T>>();

        /// <summary>
        /// 进行缓存的过期处理
        /// </summary>
        static CacheManager()
        {
            //启动线程一直检查缓存是否过期
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    foreach (string key in cacheDictionary.Keys)
                    {
                        CacheModel<T> cacheModel = null;
                        cacheDictionary.TryGetValue(key, out cacheModel);
                        if (cacheModel != null)
                        {
                            if (cacheModel.ExpiredTime < DateTime.Now)
                            {
                                cacheDictionary.TryRemove(key, out cacheModel);
                            }
                        }
                    }
                }
            });
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cacheObject"></param>
        /// <param name="timeSpan"></param>
        public void AddCache(string key, T cacheObject, double? expiredMinutes)
        {
            if (!ExistKey(key))
            {
                cacheDictionary.TryAdd(key, CreateCacheModel(cacheObject, DateTime.Now, expiredMinutes));
            }
        }

        public void UpdateCache(string key, T cacheObject, double? expiredMinutes)
        {
            if (ExistKey(key))
            {
                UpdateCacheModel(key, cacheObject, expiredMinutes);
            }
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetCache(string key)
        {
            var result = CacheManager<T>.cacheDictionary.GetValueOrDefault(key);
            if (result == null)
            {
                return default(T);
            }

            return result.CacheObject;
        }

        public List<T> ShowCache()
        {
            List<T> ts = new List<T>();
            foreach (var key in CacheManager<T>.cacheDictionary.Keys)
            {
                CacheModel<T> model = CacheManager<T>.cacheDictionary[key];
                ts.Add(model.CacheObject);
            }

            return ts;
        }

        public List<string> ShowKeys()
        {
            return CacheManager<T>.cacheDictionary.Keys.ToList();
        }

        /// <summary>
        /// 获取过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void GetExpiredTime(string key)
        {
            CacheModel<T> cacheModel = null;
            CacheManager<T>.cacheDictionary.TryGetValue(key, out cacheModel);
            Console.WriteLine($"过期时间{cacheModel.ExpiredTime}");
        }

        /// <summary>
        /// 判断Key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ExistKey(string key)
        {
            return CacheManager<T>.cacheDictionary.Keys.Contains(key);
        }

        /// <summary>
        /// 创建缓存的内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheObject"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        private CacheModel<T> CreateCacheModel(T cacheObject, DateTime cacheTime, double? expiredMinutes)
        {
            CacheModel<T> cacheModel = new CacheModel<T>
            {
                CacheObject = cacheObject
            };

            if (expiredMinutes.HasValue)
            {
                cacheModel.ExpiredTime = cacheTime.AddMinutes(expiredMinutes.Value)
;
            }

            return cacheModel;
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="newCacheObject"></param>
        /// <param name="newTimeSpan"></param>
        private void UpdateCacheModel(string key, T newCacheObject, double? expiredMinutes)
        {
            if (ExistKey(key))
            {
                CacheModel<T> oldCacheModel = null;
                CacheManager<T>.cacheDictionary.TryGetValue(key, out oldCacheModel);

                //支持滑动过期
                CacheModel<T> updateCacheModel = CreateCacheModel(newCacheObject, oldCacheModel.ExpiredTime, expiredMinutes);

                CacheManager<T>.cacheDictionary.TryUpdate(key, updateCacheModel, oldCacheModel);
            }
        }
    }

    internal class CacheModel<T>
    {
        /// <summary>
        /// 缓存内容
        /// </summary>
        public T CacheObject { set; get; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpiredTime { set; get; }
    }
}
