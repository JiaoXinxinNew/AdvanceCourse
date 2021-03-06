﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.RedisHelper.Interface
{
    public interface IRedisString:IDisposable
    {
        #region 赋值
        /// <summary>
        /// 设置key的value
        /// </summary>
        bool Set<T>(string key, T value);

        /// <summary>
        /// 设置key的value并设置过期时间
        /// </summary>
        bool Set<T>(string key, T value, DateTime dt);

        /// <summary>
        /// 设置key的value并设置过期时间间隔
        /// </summary>
        bool Set<T>(string key, T value, TimeSpan sp);

        /// <summary>
        /// 设置多个key/value
        /// </summary>
        void Set(Dictionary<string, string> dic);
        #endregion

        #region 追加
        /// <summary>
        /// 在原有key的value值之后追加value,没有就新增一项
        /// </summary>
        long Append(string key, string value);
        #endregion

        #region 取值
        /// <summary>
        /// 获取key的value值
        /// </summary>
        string Get(string key);

        /// <summary>
        /// 获取多个key的value值
        /// </summary>
        List<string> Get(List<string> keys);

        /// <summary>
        /// 获取多个key的value值（value为泛型）
        /// </summary>
         List<T> Get<T>(List<string> keys);
        #endregion

        #region 获取旧值赋上新值

        /// <summary>
        /// 获取旧值赋上新值
        /// </summary>
        string GetAndSetValue(string key, string value);
        #endregion

        //#region 辅助方法
        ///// <summary>
        ///// 根据key获取值的长度
        ///// </summary>
        //long GetLength(string key);
        ///// <summary>
        ///// 自增1，返回自增后的值
        ///// </summary>
        // long Incr(string key);
        ///// <summary>
        ///// 自增count，返回自增后的值
        ///// </summary>
        //long IncrBy(string key, int count);
        ///// <summary>
        ///// 自减1，返回自减后的值
        ///// </summary>
        //long Decr(string key);
        ///// <summary>
        ///// 自减count ，返回自减后的值
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="count"></param>
        ///// <returns></returns>
        //long DecrBy(string key, int count);
        //#endregion
    }
}
