using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Views;

namespace WpfApp1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 创建一个入口方法
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        { 
            //为了满足对象实例注入
            //通过容器对象来获取需要的窗口对象
            return Container.Resolve<MainWindow>();


        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IInterface, MyClass>();
            containerRegistry.RegisterDialog<SubView>();
        }

    }
}
