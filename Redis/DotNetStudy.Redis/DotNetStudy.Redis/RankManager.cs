using DotNetStudy.RedisHelper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetStudy.Redis
{
    public class RankManager
    {
        private static List<string> UserList = new List<string> { "张三", "李四", "王二", "赵四", "焦鑫鑫" };
        public static void GiveGift()
        {
            
            using (RedisZSetService zSetService = new RedisZSetService())
            {
                zSetService.FlushAll();
                Task.Run(() =>
                {
                    while (true)
                    {
                        
                        foreach (var user in UserList)
                        {
                            Thread.Sleep(10);
                            zSetService.IncrementItemInSortedSet("陈一发儿", user, new Random().Next(1, 100));//表示在原来刷礼物的基础上增加礼物


                        }
                        Thread.Sleep(1 * 1000);
                    }
                });
                Task.Run(() =>
                {
                    while (true)
                    {
                        int i = 1;
                        Thread.Sleep(2 * 1000);
                        var result = zSetService.GetAllWithScoresFromSortedSet("王祖贤");
                        Console.WriteLine("**********************");
                        foreach (var item in result)
                        {
                            Console.WriteLine($"第{i++}名 {item.Key} 分数{item.Value}");
                        }
                       


                    }

                });
                Console.Read();
            }
        }
    }
}
