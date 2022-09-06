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

        public List<KeyBind> KeyBind { get; set; }

        public void SetData(Data data_)
        {
            data = Utils.ConvertDataToDirectory(data_);
            //MessageBox.Show("ok");
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
