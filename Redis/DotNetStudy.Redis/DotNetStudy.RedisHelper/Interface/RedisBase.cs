using DotNetStudy.RedisHelper.Init;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.RedisHelper.Interface
{
    /// <summary>
    /// RedisBase类，是redis操作的基类，继承自IDisposable接口，主要用于释放内存
    /// </summary>
    public class RedisBase : IDisposable
    {
        public IRedisClient iClient { get; private set; }

        /// <summary>
        /// 构造时完成链接的打开
        /// </summary>
        public RedisBase()
        {
            iClient = RedisManager.GetClient();
        }

        private bool _disposed = false;//自己处于未释放的状态

        /// <summary>
        /// 重写释放，手动释放RedisClient（客户端缓存操作对象）
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)//判断是否自己被释放
            {
                if (disposing)
                {
                    iClient.Dispose();
                    iClient = null;
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// 手动释放RedisClient（客户端缓存操作对象）
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);//通知垃圾回收机制不再调用终结器（析构器）
        }

        /////暂时不知道是干什么的
        //public void Transcation()
        //{
        //    using (IRedisTransaction irt = this.iClient.CreateTransaction())
        //    {
        //        try
        //        {
        //            irt.QueueCommand(r => r.Set("key", 20));
        //            irt.QueueCommand(r => r.Increment("key", 1));
        //            irt.Commit(); // 提交事务
        //        }
        //        catch (Exception ex)
        //        {
        //            irt.Rollback();
        //            throw ex;
        //        }
        //    }
        //}

        /// <summary>
        /// 清除全部数据 请小心
        /// </summary>
        public virtual void FlushAll()
        {
            iClient.FlushAll();
        }

        /// <summary>
        /// 保存数据DB文件到硬盘
        /// </summary>
        public void Save()
        {
            iClient.Save();//阻塞式save
        }

        /// <summary>
        /// 异步保存数据DB文件到硬盘
        /// </summary>
        public void SaveAsync()
        {
            iClient.SaveAsync();//异步save
        }
    }
}
