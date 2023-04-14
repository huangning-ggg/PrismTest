using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public string Value
        {           
            get { return pValue; }
            set 
            { 
                SetProperty(ref pValue, value,()=> 
                {
                    Debug.WriteLine(pValue);

                    this.IsEnable = value != "";
                }); 
            
            }
        }

        private string pValue = "Hello Prism";
        IEventAggregator _ea;
        IDialogService _dialogService;
        public MainWindowViewModel(IEventAggregator ea,IDialogService dialogService)
        {
            _ea = ea;
            _dialogService = dialogService;
            Task.Run(async () =>
            {
                await Task.Delay(2000);
                this.Value = "Hello HN";

                await Task.Delay(2000);
                this.Value = "Hello Ladys";

                await Task.Delay(2000);
                this.Value = "Hello Every Body";
            });
        }

        public ICommand ClickCommand
        {
            get => new DelegateCommand<object>(ButtonClick, CanExecute);
            //get => new DelegateCommand<object>(ButtonClick).ObservesCanExecute(() => IsEnable);
        }

        private bool isEnable;
        public bool IsEnable
        {
            get { return isEnable; }
            set { SetProperty(ref isEnable,value); }
        }

        private void ButtonClick(object obj)
        {
            //this.Value = "";

            _ea.GetEvent<MessageEvent>().Publish(obj.ToString());
            //_dialogService.ShowDialog("SubView");
        }

        private bool CanExecute(object obj)
        {
            return this.Value != "";
        }
    }
}
