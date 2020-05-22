using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Course08Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People()
            {
                Id = 1,
            };
            ExpressionGenericMapper<People, PeopleCopy>.Trans(people);
            //ParameterExpression paraLeft = Expression.Parameter(typeof(int), "a");//左边
            //ParameterExpression paraRight = Expression.Parameter(typeof(int), "b");//右边
            //BinaryExpression binaryExpression= Expression.Multiply(paraLeft, paraRight);//a*b
            //ConstantExpression constantExpression = Expression.Constant(2, typeof(int));//定义常量2
            //BinaryExpression binaryExpression2 = Expression.Add(binaryExpression, constantExpression);//a*b+2
            //Expression<Func<int, int, int>> lambda = Expression.Lambda<Func<int, int, int>>(binaryExpression2, paraLeft, paraRight);//表达式目录树拼装
            //Func<int, int, int> func = lambda.Compile();//表达式目录树生成委托
            //int result = func(3, 4);//委托调用


        }

        /// <summary>
        /// 类型字段和属性转换
        /// </summary>
        /// <typeparam name="Tin">输入类型</typeparam>
        /// <typeparam name="TOut">输出类型</typeparam>
        /// <param name="tIn">输入类型的参数</param>
        /// <param name="tOut">输出类型的参数</param>
        /// <returns></returns>
        public static TOut Trans<Tin, TOut>(Tin tIn, TOut tOut)
        {
            TOut tOutCreater = Activator.CreateInstance<TOut>();
            foreach (var inPropety in tIn.GetType().GetProperties())
            {
                foreach (var outPropety in tOut.GetType().GetProperties())
                {
                    if (inPropety.Name.Equals(outPropety))
                    {
                        outPropety.SetValue(tOutCreater, inPropety.GetValue(tIn));
                    }
                }
            }
            foreach (var inField in tIn.GetType().GetFields())
            {
                foreach (var outField in tOut.GetType().GetFields())
                {
                    if (inField.Name.Equals(outField))
                    {
                        outField.SetValue(tOutCreater, inField.GetValue(tIn));
                    }
                }
            }
            return tOutCreater;
        }

      

    }

    /// <summary>
    /// 表达式泛型类型转换
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public class ExpressionGenericMapper<TIn,TOut>
    {
        /// <summary>
        /// 静态字段用于泛型缓存委托
        /// </summary>
        private static Func<TIn, TOut> _func = null;

        /// <summary>
        /// 静态构造方法，使用表达式生成lambda，编译后生成委托
        /// </summary>
        static ExpressionGenericMapper()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            foreach (var item in typeof(TOut).GetProperties())
            {
                MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }
            foreach (var item in typeof(TOut).GetFields())
            {
                MemberExpression property = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }
            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[]
            {
                    parameterExpression
            });
            _func = lambda.Compile();//将动态生成的表达树编译生成方法，并缓存
        }
        /// <summary>
        /// 类型转换。使用泛型缓存的静态委托。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static   TOut Trans(TIn t)
        {
            return _func(t);
        }
    }

    public class People
    {
        public int Id { get; set; }
    }

    public class PeopleCopy
    {
        public int Id { get; set; }
    }
}
