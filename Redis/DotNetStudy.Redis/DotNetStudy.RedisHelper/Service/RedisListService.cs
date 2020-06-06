using DotNetStudy.RedisHelper.Interface;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.RedisHelper.Service
{
   public class RedisListService:RedisBase
    {
        #region 赋值
        /// <summary>
        /// 从左侧向list中添加值
        /// </summary>
        public void LPush(string key, string value)
        {
            base.iClient.PushItemToList(key, value);
        }
        /// <summary>
        /// 从左侧向list中添加值，并设置过期时间
        /// </summary>
        public void LPush(string key, string value, DateTime dt)
        {

            base.iClient.PushItemToList(key, value);
            base.iClient.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 从左侧向list中添加值，设置过期时间
        /// </summary>
        public void LPush(string key, string value, TimeSpan sp)
        {
            base.iClient.PushItemToList(key, value);
            base.iClient.ExpireEntryIn(key, sp);
        }
        /// <summary>
        /// 从右侧向list中添加值,可以用来做队列
        /// </summary>
        public void RPush(string key, string value)
        {
            base.iClient.PrependItemToList(key, value);
        }
        /// <summary>
        /// 从右侧向list中添加值，并设置过期时间
        /// </summary>    
        public void RPush(string key, string value, DateTime dt)
        {
            base.iClient.PrependItemToList(key, value);
            base.iClient.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 从右侧向list中添加值，并设置过期时间
        /// </summary>        
        public void RPush(string key, string value, TimeSpan sp)
        {
            base.iClient.PrependItemToList(key, value);
            base.iClient.ExpireEntryIn(key, sp);
        }
        /// <summary>
        /// 添加key/value
        /// </summary>     
        public void Add(string key, string value)
        {
            base.iClient.AddItemToList(key, value);
        }
        /// <summary>
        /// 添加key/value ,并设置过期时间
        /// </summary>  
        public void Add(string key, string value, DateTime dt)
        {
            base.iClient.AddItemToList(key, value);
            base.iClient.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 添加key/value。并添加过期时间
        /// </summary>  
        public void Add(string key, string value, TimeSpan sp)
        {
            base.iClient.AddItemToList(key, value);
            base.iClient.ExpireEntryIn(key, sp);
        }
        /// <summary>
        /// 为key添加多个值
        /// </summary>  
        public void Add(string key, List<string> values)
        {
            base.iClient.AddRangeToList(key, values);
        }
        /// <summary>
        /// 为key添加多个值，并设置过期时间
        /// </summary>  
        public void Add(string key, List<string> values, DateTime dt)
        {
            base.iClient.AddRangeToList(key, values);
            base.iClient.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 为key添加多个值，并设置过期时间
        /// </summary>  
        public void Add(string key, List<string> values, TimeSpan sp)
        {
            base.iClient.AddRangeToList(key, values);
            base.iClient.ExpireEntryIn(key, sp);
        }
        #endregion

        #region 获取值
        /// <summary>
        /// 获取list中key包含的数据数量
        /// </summary>  
        public long Count(string key)
        {
            return base.iClient.GetListCount(key);
        }

        /// <summary>
        /// 获取key包含的所有数据集合
        /// </summary>  
        public List<string> Get(string key)
        {
            return base.iClient.GetAllItemsFromList(key);
        }

        /// <summary>
        /// 获取key中下标为star到end的值集合 
        /// </summary>  
        public List<string> Get(string key, int star, int end)
        {
            return base.iClient.GetRangeFromList(key, star, end);
        }
        #endregion

        #region 阻塞命令
        /// <summary>
        ///  阻塞命令：从list为key的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingPopItemFromList(string key, TimeSpan? sp)
        {
            return base.iClient.BlockingPopItemFromList(key, sp);
        }
        /// <summary>
        ///  阻塞命令：从多个list中尾部移除一个值,并返回移除的值&key，阻塞时间为sp
        /// </summary>  
        public ItemRef BlockingPopItemFromLists(string[] keys, TimeSpan? sp)
        {
            return base.iClient.BlockingPopItemFromLists(keys, sp);
        }


        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        ///  如果存在这个值，则移除，如果并不存在那么等待sp时间之后再移除
        /// </summary>  
        public string BlockingDequeueItemFromList(string key, TimeSpan? sp)
        {
            return base.iClient.BlockingDequeueItemFromList(key, sp);
        }

        /// <summary>
        /// 阻塞命令：从多个list中尾部移除一个值，并返回移除的值&key，阻塞时间为sp
        /// </summary>  
        public ItemRef BlockingDequeueItemFromLists(string[] keys, TimeSpan? sp)
        {
            return base.iClient.BlockingDequeueItemFromLists(keys, sp);
        }

        /// <summary>
        /// 阻塞命令：从list中一个fromkey的尾部移除一个值，添加到另外一个tokey的头部，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingPopAndPushItemBetweenLists(string fromkey, string tokey, TimeSpan? sp)
        {
            return base.iClient.BlockingPopAndPushItemBetweenLists(fromkey, tokey, sp);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 从尾部移除数据，返回移除的数据
        /// </summary>  
        public string PopItemFromList(string key)
        {
            var sa = base.iClient.CreateSubscription();
            return base.iClient.PopItemFromList(key);
        }
        /// <summary>
        /// 从尾部移除数据，返回移除的数据
        /// </summary>  
        public string DequeueItemFromList(string key)
        {
            return base.iClient.DequeueItemFromList(key);
        }

        /// <summary>
        /// 移除list中，key/value,与参数相同的值，并返回移除的数量
        /// </summary>  
        public long RemoveItemFromList(string key, string value)
        {
            return base.iClient.RemoveItemFromList(key, value);
        }
        /// <summary>
        /// 从list的尾部移除一个数据，返回移除的数据
        /// </summary>  
        public string RemoveEndFromList(string key)
        {
            return base.iClient.RemoveEndFromList(key);
        }
        /// <summary>
        /// 从list的头部移除一个数据，返回移除的值
        /// </summary>  
        public string RemoveStartFromList(string key)
        {
            return base.iClient.RemoveStartFromList(key);
        }
        #endregion

        #region 其它
        /// <summary>
        /// 从一个list的尾部移除一个数据，添加到另外一个list的头部，并返回移动的值
        /// </summary>  
        public string PopAndPushItemBetweenLists(string fromKey, string toKey)
        {
            return base.iClient.PopAndPushItemBetweenLists(fromKey, toKey);
        }

        /// <summary>
        /// 清理数据，保持list长度
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start">起点</param>
        /// <param name="end">终结点</param>
        public void TrimList(string key, int start, int end)
        {
            base.iClient.TrimList(key, start, end);
        }
        #endregion

        #region 发布订阅
        public void Publish(string channel, string message)
        {
            base.iClient.PublishMessage(channel, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel">定于通道Name</param>
        /// <param name="actionOnMessage"></param>
        public void Subscribe(string channel, Action<string, string, IRedisSubscription> actionOnMessage)
        {
            var subscription = base.iClient.CreateSubscription();
            //订阅执行的方法
            subscription.OnSubscribe = c =>
            {
                Console.WriteLine($"订阅频道{c}");
                Console.WriteLine();
            };
            //取消订阅执行的方法
            subscription.OnUnSubscribe = c =>
            {
                Console.WriteLine($"取消订阅 {c}");
                Console.WriteLine();
            };
            //c:订阅通道，s:订阅者
            subscription.OnMessage += (c, s) =>
            {
                Console.WriteLine($"*********{c},{s}");
                actionOnMessage(c, s, subscription);
            };
            Console.WriteLine($"开始启动监听 {channel}");
            subscription.SubscribeToChannels(channel); //blocking
        }

        public void UnSubscribeFromChannels(string channel)
        {
            var subscription = base.iClient.CreateSubscription();
            subscription.UnSubscribeFromChannels(channel);
        }
        #endregion
    }
}
