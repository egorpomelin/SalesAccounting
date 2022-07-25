using RabotaWpf.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
