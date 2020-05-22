using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.Framework.IOCDI
{
    public interface ICustomDIContainer
    {
        void RegistType<TFrom, TTO>(LifeTimeType lifeTimeType);
        TType Resolve<TType>();
    }
    public class CustomDIContainer : ICustomDIContainer
    {
        /// <summary>
        /// 用于存入注册的类型
        /// </summary>
        private Dictionary<string, RegisterInfo> _DIContainer = new Dictionary<string, RegisterInfo>();

        private Dictionary<Type, object> _TypeObjectDictionary = new Dictionary<Type, object>();
        /// <summary>
        /// 注册类型
        /// </summary>
        /// <typeparam name="TFrom">父类、接口、抽象类</typeparam>
        /// <typeparam name="TTO">实现类</typeparam>
        public void RegistType<TFrom, TTO>(LifeTimeType lifeTimeType)
        {
            _DIContainer.Add(typeof(TFrom).FullName, new RegisterInfo()
            {
                LifeTimeType = lifeTimeType,
                TargetType = typeof(TTO)
            });
        }

        /// <summary>
        /// 解析类型
        /// </summary>
        /// <typeparam name="TType">解析父类或接口类型</typeparam>
        /// <returns></returns>
        public TType Resolve<TType>()
        {
            var registerInfo = _DIContainer[typeof(TType).FullName];
            TType result = default(TType);
            switch (registerInfo.LifeTimeType)
            {
                case LifeTimeType.Transient:
                    result = (TType)CreateObject(registerInfo.TargetType);
                    break;
                case LifeTimeType.SingleTon:
                    if (_TypeObjectDictionary.Keys.Contains(registerInfo.TargetType))
                    {
                        result = (TType)_TypeObjectDictionary[registerInfo.TargetType];
                    }
                    else
                    {
                        result = (TType)CreateObject(registerInfo.TargetType);
                        this._TypeObjectDictionary.Add(registerInfo.TargetType, result);
                    }
                    break;
                case LifeTimeType.PerThread:
                    object threadInstance = CallContext.GetData(registerInfo.TargetType.FullName);
                    if (threadInstance != null)
                    {
                        result = (TType)threadInstance;
                    }
                    else
                    {
                        result = (TType)this.CreateObject(registerInfo.TargetType);
                        CallContext.SetData(registerInfo.TargetType.FullName, result);
                    }
                    break;

            }
            return result;
        }

        /// <summary>
        /// 利用递归实例化所有构造函数的参数类型
        /// </summary>
        /// <param name="type">解析的父类或接口类型</param>
        /// <returns></returns>
        private object CreateObject(Type type)
        {
            #region 获取接口类型，有特性标签或者构造函数参数最多的
            var constructors = type.GetConstructors();
            ConstructorInfo constructorInfo = null;
            if (constructors.Where(c => c.IsDefined(typeof(CustomDIContrucotrAttribute), true)).Count() > 0)
            {
                constructorInfo = constructors.Where(c => c.IsDefined(typeof(CustomDIContrucotrAttribute), true)).FirstOrDefault();
            }
            else
            {
                constructorInfo = constructors.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
            }
            #endregion

            #region 利用递归获取构造函数的参数
            List<object> parameters = new List<object>();
            foreach (var parameter in constructorInfo.GetParameters())
            {
                Type parameterType = parameter.ParameterType;//获取参数类型
                RegisterInfo registerInfo = _DIContainer[parameterType.FullName];//获取注册的对应类型
                object parameterInstance = null;
                switch (registerInfo.LifeTimeType)
                {
                    case LifeTimeType.Transient:
                        parameterInstance = this.CreateObject(registerInfo.TargetType);
                        break;
                    case LifeTimeType.SingleTon:
                        if (_TypeObjectDictionary.ContainsKey(registerInfo.TargetType))
                        {
                            parameterInstance = _TypeObjectDictionary[registerInfo.TargetType];
                        }
                        else
                        {
                            parameterInstance = CreateObject(registerInfo.TargetType);
                            this._TypeObjectDictionary.Add(registerInfo.TargetType, parameterInstance);
                        }
                        break;
                    case LifeTimeType.PerThread:
                        object threadInstance = CallContext.GetData(registerInfo.TargetType.FullName);
                        if (threadInstance != null)
                        {
                            parameterInstance = threadInstance;
                        }
                        else
                        {
                            parameterInstance = this.CreateObject(registerInfo.TargetType);
                            CallContext.SetData(registerInfo.TargetType.FullName, parameterInstance);
                        }
                        break;

                }
                parameters.Add(parameterInstance);//创建类型后，加入参数
            }
            #endregion
            return Activator.CreateInstance(type, parameters.ToArray());

        }
    }
}
