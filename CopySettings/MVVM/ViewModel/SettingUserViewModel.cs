using CopySettings.Obje;
using CopySettings.Hellp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CopySettings.MVVM.ViewModel
{
    public class SettingUserViewModel: BaseModel
    {
        private DataObj _data;
        public DataObj data { get => _data; set { _data = value; OnPropertyChanged(); } }

        public List<Actionmapping> KeyBind { get; set; }

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



    }
}
