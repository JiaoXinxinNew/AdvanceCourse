using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.RedisHelper.Init
{
    public class RedisManager
    {
        /// <summary>
        /// Redis配置信息
        /// </summary>
        private static RedisConfigInfo redisConfigInfo = new RedisConfigInfo();

        /// <summary>
        /// Redis客户端池化管理
        /// </summary>
        private static PooledRedisClientManager prcManager;

        /// <summary>
        /// 静态构造方法，初始化链接池管理对象
        /// </summary>
        static RedisManager()
        {
            CreateManager();
        }

        /// <summary>
        /// 创建链接池管理对象
        /// </summary>
        private static void CreateManager()
        {
            string[] WirteServerConStr = redisConfigInfo.WriteServerList.Split(',');
            string[] ReadServerConStr = redisConfigInfo.ReadServerList.Split(',');
            prcManager = new PooledRedisClientManager(ReadServerConStr, WirteServerConStr, new RedisClientManagerConfig
            {
                MaxWritePoolSize = redisConfigInfo.MaxWritePoolSize,
                MaxReadPoolSize = redisConfigInfo.MaxReadPoolSize,
                AutoStart = redisConfigInfo.AutoStart
            });
        }

        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public static IRedisClient GetClient()
        {
            return prcManager.GetClient();
        }

    }
}
