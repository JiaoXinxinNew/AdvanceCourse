using DesignPattern.AbstractFactory;
using DesignPattern.Common;
using DesignPattern.Decorator;
using DesignPattern.Model;
using DesignPattern.Model.Customers;
using DesignPattern.Model.Dish;
using DesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            //DishMenu dishMenu = DishMenu.CreateDishMenu();
            //if (dishMenu.DishModels != null)
            //{
            //    foreach (DishModel dishModel in dishMenu.DishModels)
            //    {
            //        Console.WriteLine($"菜肴编号：{dishModel.DishId.ToString().PadLeft(2)}   菜名：{dishModel.DishName.PadLeft(8)}   价格：{dishModel.Price.ToString().PadLeft(5)}");
            //    }
            //}
            //int dishId = Convert.ToInt32(Console.ReadLine());
            //DishModel selectishModel = dishMenu.DishModels.FirstOrDefault(c => c.DishId == dishId);
            //Console.WriteLine($"您选择的菜为：{selectishModel.DishName},价格为：{selectishModel.Price},综合评分为：{selectishModel.DishSorce}");
            //AbstractDish abstractDish = AbstractFactory.CreateDishByRefAndConfig<AbstractDish>(selectishModel.SimpleFactory);
            //abstractDish.Cook();
            //abstractDish.Tast();
            DishMenu dishMenu = DishMenu.CreateDishMenu();
            List<Customer> customers = new List<Customer>()
            {
                new Customer{Name="甲"},
                new Customer{Name="已"},
                new Customer{Name="丙"}
            };
            List<Task> tasks = new List<Task>();
            List<Dictionary<AbstractDish, int>> customerMostSorce = new List<Dictionary<AbstractDish, int>>();
            foreach (var item in customers)
            {
                customerMostSorce.Add(new Dictionary<AbstractDish, int>());
            }
            int k = 0;
            ScoreObserver scoreObserver = new ScoreObserver();
            scoreObserver.FullMarkAction += new Client().Suprice;
            scoreObserver.FullMarkAction += new Masses().Suprice;
            scoreObserver.FullMarkAction += new Media().Suprice;
            foreach (var customer in customers)
            {
                tasks.Add(Task.Run(() =>
                {
                    Dictionary<AbstractDish, int> keyValuePairs = customerMostSorce[k++];
                    foreach (var dish in dishMenu.DishModels)
                    {
                        AbstractDish dishInstance = AbstractFactory.CreateDishByRefAndConfig<AbstractDish>(dish.SimpleFactory);
                        ConsoleWrite.ConsoleWriteLock($"{customer.Name}开始点菜，菜名为：{dish.DishName}");
                        dishInstance.Cook();
                        dishInstance.Tast();
                        dishInstance.DishBaseInfo = new DishBaseInfo() { DishSorce = dishInstance.Evaluate() };
                        keyValuePairs.Add(dishInstance, dishInstance.DishBaseInfo.DishSorce);
                    }
                    foreach (var maxCustume in keyValuePairs.Where(d => d.Value == keyValuePairs.Values.Max()))
                    {
                        ConsoleWrite.ConsoleWriteLock($"{customer.Name}给{maxCustume.Key.DishBaseInfo.DishName}的最高分为：{maxCustume.Value}");
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("************************************");
            int maxSorce = customerMostSorce.Max(d => d.Values.Max());
            for (int i = 0; i < customers.Count; i++)
            {
                foreach (var item in customerMostSorce[i].Where(d => d.Value == maxSorce))
                {
                    ConsoleWrite.ConsoleWriteLock($"{customers[i].Name}给{item.Key.DishBaseInfo.DishName}出的最高分为{item.Key.DishBaseInfo.DishSorce}");
                    scoreObserver.FunllMarkTrigger (item.Key.DishBaseInfo.DishSorce);

                }
            }
            //AbstractDish abstractDish = AbstractFactory.CreateDishByNormal(DishName.Bean);
            //abstractDish = new DishDecoratorBuy(abstractDish);
            //abstractDish = new DishDecoratorWash(abstractDish);
            //abstractDish = new DishDecoratorCut(abstractDish);
            //abstractDish = new DishDecoratorPut(abstractDish);
            //abstractDish = new DishDecoratorGive(abstractDish);
            //abstractDish.Cook();


             Console.Read();
        }
    }
}
