using GalaSoft.MvvmLight.Command;
using SalesAccounting.Infrastructure;
using SalesAccounting.View;
using SalesAccounting.View.ViewPage;
using SalesAccounting.ViewModel.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesAccounting.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            OpenSalesAccounting = new command(OnOpenSalesAccountingExecuted, CanOpenSalesAccountingExecuted);
        }

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

        public ICommand OpenSalesAccounting { get; }

        private void OnOpenSalesAccountingExecuted(object p)
        {
            Window wd = new SalesAccountingWindow();
            wd.Show();
        }

        private bool CanOpenSalesAccountingExecuted(object p) => true;
    }
}
