using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EContainer
{
    /// <summary>
    /// 泛型缓存，用来取代字典的
    /// 这个性能更高，更吻合目前场景
    /// 可以根据不同的接口产生多个
    /// </summary>
    /// <typeparam name="IT"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class ContainerStore<IT>
    {
        private static Type s_targetType;

        public static void InitType<T>()
        {
            s_targetType = typeof(T);
        }

        public static Type GetType()
        {
            return s_targetType;
        }
    }
}
