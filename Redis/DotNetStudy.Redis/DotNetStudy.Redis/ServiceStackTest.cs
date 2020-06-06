using DotNetStudy.RedisHelper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetStudy.Redis
{
    public  class ServiceStackTest
    {
        public static void Show()
        {
            #region 生产者消费者模式--生产者
            //消费者在DotNetStudy.BackService.Program
            //using (RedisListService service = new RedisListService())
            //{
            //    service.FlushAll();
            //    service.Add("test", "这是一个学生Add1");
            //    service.Add("test", "这是一个学生Add2");
            //    service.Add("test", "这是一个学生Add3");

            //    service.LPush("test", "这是一个学生LPush1");
            //    service.LPush("test", "这是一个学生LPush2");
            //    service.LPush("test", "这是一个学生LPush3");
            //    service.LPush("test", "这是一个学生LPush4");
            //    service.LPush("test", "这是一个学生LPush5");

            //    service.RPush("test", "这是一个学生的RPush1");
            //    service.RPush("test", "这是一个学生的RPush2");
            //    service.RPush("test", "这是一个学生的RPush3");
            //    service.RPush("test", "这是一个学生的RPush4");
            //    service.RPush("test", "这是一个学生的RPush5");

            //    List<string> stringList = new List<string>();
            //    for (int i = 0; i < 10; i++)
            //    {
            //        stringList.Add(string.Format($"放入任务{i}"));
            //    }
            //    service.Add("task", stringList);

            //    Console.WriteLine(service.Count("test"));
            //    Console.WriteLine(service.Count("task"));

            //    Action act = new Action(() =>
            //    {
            //        while (true)
            //        {
            //            Console.WriteLine("*******请输入数据********");
            //            string inputStr = Console.ReadLine();
            //            service.Add("test", inputStr);
            //        }
            //    });
            //    act.EndInvoke(act.BeginInvoke(null, null));

            //}
            #endregion

            #region 发布订阅者模式
            Task.Run(() => {
                using (RedisListService service=new RedisListService())
                {
                    service.Subscribe("焦鑫鑫", (c, message, iRedisSubscription) =>
                    {
                        Console.WriteLine($"注册{1}{c}:{message}，Dosomething else");
                        if (message.Equals("exit"))
                        {
                            //取消订阅
                            iRedisSubscription.UnSubscribeFromChannels("焦鑫鑫");
                        }
                    });
                }
            });
            Task.Run(() => {
                using (RedisListService service = new RedisListService())
                {
                    service.Subscribe("焦鑫鑫", (c, message, iRedisSubscription) =>
                    {
                        Console.WriteLine($"注册{2}{c}:{message}，Dosomething else");
                        if (message.Equals("exit"))
                        {
                            //取消订阅
                            iRedisSubscription.UnSubscribeFromChannels("焦鑫鑫");
                        }
                    });
                }
            });
            using (RedisListService service = new RedisListService())
            {
                Thread.Sleep(1000);
                service.Publish("焦鑫鑫", "发布1");
                service.Publish("焦鑫鑫", "发布2");
                service.Publish("焦鑫鑫", "exit");
                Thread.Sleep(100);
                service.Publish("焦鑫鑫", "发布3");

            }
            #endregion

        }
    }
}
