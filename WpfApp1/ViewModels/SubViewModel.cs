using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Services.Dialogs;

namespace WpfApp1.ViewModels
{
    public class SubViewModel : IDialogAware
    {
        public string Title => "弹出窗口";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            //是否可以点击关闭按钮
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
