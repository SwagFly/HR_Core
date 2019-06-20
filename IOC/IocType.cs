using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;//导入引用配置文件的包
using Unity;//工具包，用于IOC容器-----？
using Microsoft.Practices.Unity.Configuration;//?

namespace IOC
{
    /// <summary>
    /// 测试IOC容器层
    /// </summary>
    public class IocType
    {
        /// <summary>
        /// 读取配置文件，并将读取的配置文件节点放入容器IOC,并返回IOC容器
        /// </summary>
        /// <param name="nodeName">子节点名称</param>
        /// <returns>IOC容器</returns>
        private static UnityContainer CreatIoc(string nodeName)
        {
            UnityContainer ioc = new UnityContainer();//生成容器
            ExeConfigurationFileMap fileObject = new ExeConfigurationFileMap();//读取文件对象
            fileObject.ExeConfigFilename = @"D:\Y2Dome\Y_Over\HR_Dome\UI\Unity.config";//Unity配置文件路径  @"D:\Y2Dome\Y_Over\HR_Dome\UI\Unity.config"
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(fileObject, ConfigurationUserLevel.None);//通过路径生成文件
            UnityConfigurationSection cfs = (UnityConfigurationSection)cf.GetSection("unity");
            ioc.LoadConfiguration(cfs, nodeName);
            return ioc;
        }
        /// <summary>
        /// 转换器——》将接口转换成具体的实现类
        /// </summary>
        /// <typeparam name="T">需要的实现类</typeparam>
        /// <param name="nodeName">转换标记名称</param>
        /// <param name="typeName">子节点名</param>
        /// <returns>需要的实现类</returns>
        public static T GetIocType<T>(string nodeName, string typeName)
        {
            IUnityContainer container = CreatIoc(nodeName);
            //
            T newClass = container.Resolve<T>(typeName);
            return newClass;
        }
    }
}
