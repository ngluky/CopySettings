using CopySettings.MVVM.View;
using CopySettings.Obje;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CopySettings.MVVM.ViewModel
{
    public class MainWindowViewModel: BaseModel
    {

        #region data Bidding
        private bool _AccIsCheck = false;
        public bool AccIsCheck { get=> _AccIsCheck; set { _AccIsCheck = value; OnPropertyChanged(); } }

        private ObservableCollection<Account> _Users;
        public ObservableCollection<Account> Users { get => _Users; set { _Users = value; OnPropertyChanged(); } }

        private Data _data;

        public Data data
        {
            get { return _data; }
            set { _data = value; OnPropertyChanged(); }
        }


        private object _currView;
        public object currView { get => _currView; set{ _currView = value; OnPropertyChanged(); } }

        #endregion



        public MainWindowViewModel()
        {
            currView = new SettingUserView();
        }

    }
}
