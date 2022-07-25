using SalesAccounting.Infrastructure;
using SalesAccounting.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SalesAccounting.ViewModel
{
    internal class SalesAccountingWindowViewModel : ViewModelBase
    {

        public SalesAccountingWindowViewModel()
        {
            AddProductCheque = new command(OnAddProductChequeExecuted, CanAddProductChequeExecuted);
        }

        string title = "Регистрация продаж";
        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }

        int barcode = 0;
        public int Barcode
        {
            get { return barcode; }
            set { Set(ref barcode, value); }
        }

        public ConnectionDB DB = new ConnectionDB();

        public ICommand AddProductCheque { get; }//добавление товара в чек

        private void OnAddProductChequeExecuted(object p)
        {
            
        }

        private bool CanAddProductChequeExecuted(object p) => true;


    }
}
