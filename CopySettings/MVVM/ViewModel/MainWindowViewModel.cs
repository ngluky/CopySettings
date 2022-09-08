using CopySettings.Hellp;
using CopySettings.Obje;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CopySettings.MVVM.ViewModel
{
    public class MainWindowViewModel : BaseModel
    {

        #region data Bidding
        private bool _AccIsCheck = false;
        public bool AccIsCheck { get => _AccIsCheck; set { _AccIsCheck = value; OnPropertyChanged(); } }

        private ObservableCollection<Account> _Users;
        public ObservableCollection<Account> Users { get => _Users; set { _Users = value; OnPropertyChanged(); } }

        private DataObj _data;
        public DataObj data { get => _data; set { _data = value; OnPropertyChanged(); } }

        public void SetData(Data data_)
        {
            var dataObj = Utils.FillData(data_);
            data = Utils.ConvertDataToDirectory(dataObj);

            Constants.Log.Information($"set data complex:");
        }

        private Dictionary<string, KeyBind> _NameAgerSele;
        public Dictionary<string, KeyBind> NameAgerSele
        {
            get => _NameAgerSele; set
            {
                _NameAgerSele = value;
                OnPropertyChanged();
            }
        }

        public Data GetData()
        {
            try
            {
                return Utils.ConvertDirectorytoData(data);

            }
            catch
            {
                return null;
            }
        }


        #endregion



        public MainWindowViewModel()
        {
            Users = new ObservableCollection<Account>();
        }

        public void SetGuiFile(string Path)
        {
        }
    }
}
