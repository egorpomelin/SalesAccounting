using GalaSoft.MvvmLight.Command;
using RabotaWpf.ViewModel.Base;
using SalesAccounting.View.ViewPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesAccounting.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        string title = "Sales Accounting";
        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }


        private Page indexPage = new IndexPage();
        private Page settingsPage = new SettingsPage();
        private Page _CurPage = new IndexPage();
        
        public Page CurPage
        {
            get => _CurPage;
            set => Set(ref _CurPage, value);
        }

        public ICommand OpenIndexPage
        {
            get { return new RelayCommand(() => CurPage = indexPage); }
        }

        public ICommand OpenSettingsPage
        {
            get { return new RelayCommand(() => CurPage = settingsPage); }
        }
    }
}
