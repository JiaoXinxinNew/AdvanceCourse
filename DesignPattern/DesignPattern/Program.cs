using DesignPattern.AbstractFactory;
using DesignPattern.BuilderPattern;
using DesignPattern.ChainOfResponsibility;
using DesignPattern.DecoratorPattern;
using DesignPattern.ObserverPattern;
using DesignPattern.ProxyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShape = DesignPattern.DecoratorPattern.IShape;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 抽象工厂调用
            //AbstractFactorys abstractFactorys = FactoryProducer.GetAbstract("shape");
            //IShape shape = abstractFactorys.GetShape(ShapeType.Square);
            //shape.Draw();
            //Console.Read();
            #endregion
            #region 建造者模式调用
            //MealBuilder mealBuilder = new MealBuilder();

            //Meal vegMeal = mealBuilder.PrepareVegMeal();
            //Console.WriteLine( "Veg Meal");
            //vegMeal.ShowItems();
            //Console.WriteLine("Total Cost: " + vegMeal.GetCost());

            //Meal nonVegMeal = mealBuilder.PrepareNonVegMeal();
            //Console.WriteLine("\n\nNon-Veg Meal");
            //nonVegMeal.ShowItems();
            //Console.WriteLine("Total Cost: " + nonVegMeal.GetCost());
            //Console.Read();
            #endregion
            #region 代理模式
            //{//直接访问
            //    IImage image = new RealImage("fd");
            //    image.Display();
            //}
            //{//代理访问
            //    IImage image = new ProxyImage("fd");
            //}
            #endregion
            #region 装饰模式
            //IShape circle = new Circle();
            //circle = new RedShapeDecorator(circle);
            //circle.Draw();
            #endregion
            #region 观察者模式
            //Subject subject = new Subject();
            ////subject.AddObserver(new Octal());
            ////subject.AddObserver(new Binary());
            ////subject.Excute();
            //subject._ObserverEvent +=new Action( new Octal().Action);
            //subject._ObserverEvent += new Binary().Action;
            //subject.ExcuteEvent();

            #endregion
            #region 责任链模式
            Handler handler = new HandlerOne();
            Handler handler1 = new HandlerTwo();
            handler.SetNextHandler(handler1);
            handler.HandleRequest(19);
            #endregion
        }
    }
    
}
