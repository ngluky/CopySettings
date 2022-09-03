using CopySettings.Obje;
using CopySettings.Hellp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopySettings.MVVM.ViewModel
{
    public class SettingUserViewModel: BaseModel
    {
        private DataObj _data;
        public DataObj data { get=>_data; set { _data = value; OnPropertyChanged(); }  }


        public void SetData(Data data_)
        {
            data = Utils.ConvertDataToDirectory(data_);

        }

        public Data GetData()
        {
            return Utils.ConvertDirectorytoData(data);
        }


    }
}
