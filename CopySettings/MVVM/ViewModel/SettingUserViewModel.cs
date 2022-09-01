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
        private Data _data;
        public Data data { get=>_data; set { _data = value; OnPropertyChanged(); }  }


        public void SetData(Data data_)
        {
            //data = Utils.ConvertDataToDirectory(data_);
            data = data_;
        }
    }
}
