using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EContainer
{
    /// <summary>
    /// 容器对象
    /// 三种依赖注入实现：构造对象时，需要把依赖的东西初始化好
    /// 构造函数注入：还去掉了特性依赖，那么service层就不需要引用容器
    /// </summary>
    public class Container
    {
        private static Dictionary<string, object> s_containerDictionary = new Dictionary<string, object>();
        /// <summary>
        /// 注册类型
        /// </summary>
        /// <typeparam name="IT">抽象类型</typeparam>
        /// <typeparam name="T">业务类型</typeparam>
        public void RegisterType<IT, T>()
        {
            s_containerDictionary.Add($"{typeof(IT).FullName}", typeof(T));
            //ContainerStore<IT>.InitType<T>();
        }

        /// <summary>
        /// 生成实例：根据上面注册信息，生成对象
        /// </summary>
        /// <typeparam name="IT"></typeparam>
        /// <returns></returns>
        public IT Resolve<IT>()
        {
            string key = typeof(IT).FullName;

            //Type type = ContainerStore<IT>.GetType();
            //return (IT)Activator.CreateInstance(type);

            if (s_containerDictionary.ContainsKey(key))
            {
                Type type = (Type)s_containerDictionary[key];

                //// 构造函数注入
                return (IT)CreateObject(type);
                //foreach (var ctor in type.GetConstructors().Where(c => c.IsDefined
                //    (typeof(EInjectionConstructionAttribute), true))) // 必须写了特性才用
                //{
                //    var paraArray = ctor.GetParameters();
                //    if (paraArray.Length == 0)
                //    {
                //        return (IT)Activator.CreateInstance(type);
                //    }

                //    List<object> listPara = new List<object>();
                //    foreach (var para in paraArray)
                //    {
                //        Type paraType = para.ParameterType; //参数类型
                //        string paraKey = paraType.FullName;
                //        Type paraTargetType = (Type)s_containerDictionary[paraKey];
                //        object oPara = Activator.CreateInstance(paraTargetType);
                //        listPara.Add(oPara);
                //    }

                //    return (IT)Activator.CreateInstance(type, listPara.ToArray());
                //}

                //return (IT)Activator.CreateInstance(type);
            }
            else
            {
                throw new Exception();
            }

            




            

            //if (s_containerDictionary.ContainsKey(key))
            //{
            //    Type type = (Type)s_containerDictionary[key];
            //    return (IT)Activator.CreateInstance(type);
            //}
            //else
            //{
            //    throw new Exception();
            //}
        }

        private object CreateObject(Type type)
        {
            // 构造函数注入
            // 优先标记特性的，没有的话选参数最多的
            var ctorArray = type.GetConstructors();
            System.Reflection.ConstructorInfo ctor = null;
            if (ctorArray.Count(c => c.IsDefined(typeof(EInjectionConstructionAttribute), true)) > 0)
            {
                ctor = ctorArray.FirstOrDefault(c => c.IsDefined(typeof(EInjectionConstructionAttribute), true));
            }
            else
            {
                ctor = ctorArray.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
            }

            var paraArray = ctor.GetParameters();
            if (paraArray.Length == 0)
            {
                return Activator.CreateInstance(type);
            }

            List<object> listPara = new List<object>();
            foreach (var para in paraArray)
            {
                Type paraType = para.ParameterType; //参数类型
                string paraKey = paraType.FullName;
                Type paraTargetType = (Type)s_containerDictionary[paraKey];
                object oPara = CreateObject(paraTargetType); // 这里递归
                listPara.Add(oPara);
            }

            return Activator.CreateInstance(type, listPara.ToArray());

        }
    }
}
