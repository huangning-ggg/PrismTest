using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IEventAggregator ea,IInterface @interface)
        {
            InitializeComponent();

            //注册
            ea.GetEvent<MessageEvent>().Subscribe(DoMessage, ThreadOption.BackgroundThread, true, filter => filter.Contains("1"));
        }

        private void DoMessage(string arg)
        {
            //V可以访问VM，VM不能访问V
            MessageBox.Show(arg);

            //this.tb1.Text = arg;

        }
    }
}
