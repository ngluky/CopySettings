using CopySettings.Obje;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopySettings.Hellp
{
    public class Utils
    {
        public static Data Decompress(string value)
        {
            byte[] byteArray = Convert.FromBase64String(value);
            byte[] decompressed;
            using (MemoryStream outputStream = new MemoryStream())
            {
                using (DeflateStream deflateStream = new DeflateStream(new MemoryStream(byteArray), CompressionMode.Decompress))
                {
                    deflateStream.CopyTo(outputStream);
                }
                decompressed = (byte[])outputStream.ToArray().Clone();
            }
            return JsonConvert.DeserializeObject<Data>(Encoding.UTF8.GetString(decompressed));
        }
        public static string Compress(Object data)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
            byte[] compressed;
            using (MemoryStream output = new MemoryStream())
            {
                //Create stream from bytes of the json data and copy it to deflateStream as it only has write access
                try
                {
                    using (MemoryStream memoryStream = new MemoryStream(byteArray))
                    {
                        using (DeflateStream deflateStream = new DeflateStream(output, CompressionMode.Compress))
                        {
                            memoryStream.CopyTo(deflateStream);
                        }
                    }
                }
                catch (Exception e)
                {

                }
                compressed = (byte[])output.ToArray().Clone();
            }
            return Convert.ToBase64String(compressed);
        }

        public static DataObj ConvertDataToDirectory(Data data)
        {
            var dataOutput = new DataObj();
            dataOutput.actionMappings = data.actionMappings;
            dataOutput.axisMappings = data.axisMappings;
            foreach (var i in data.boolSettings)
            {
                dataOutput.boolSettings.Add(i.settingEnum.Replace("EAresBoolSettingName::" , string.Empty), i.value);
            }

            foreach (var i in data.floatSettings)
            {
                dataOutput.floatSettings.Add(i.settingEnum.Replace("EAresFloatSettingName::", string.Empty), i.value);
            }

            foreach (var i in data.intSettings)
            {
                dataOutput.intSettings.Add(i.settingEnum.Replace("EAresIntSettingName::", string.Empty), i.value);
            }

            foreach (var i in data.stringSettings)
            {
                dataOutput.stringSettings.Add(i.settingEnum.Replace("EAresStringSettingName::", string.Empty), i.value);
            }

            dataOutput.roamingSetttingsVersion = data.roamingSetttingsVersion;

            dataOutput.settingsProfiles = data.settingsProfiles;


            return dataOutput;
        }

        public static Data ConvertDirectorytoData(DataObj data)
        {
            var dataOutput = new Data();
            dataOutput.actionMappings = data.actionMappings;
            dataOutput.axisMappings = data.axisMappings;

            foreach (var i in data.boolSettings)
            {
                dataOutput.boolSettings.Add(new Boolsetting() { settingEnum = "EAresBoolSettingName::" + i.Key, value = i.Value });
            }

            foreach (var i in data.floatSettings)
            {
                dataOutput.floatSettings.Add(new Floatsetting() { settingEnum = "EAresFloatSettingName::" + i.Key, value = i.Value });
            }

            foreach (var i in data.intSettings)
            {
                dataOutput.intSettings.Add(new Intsetting() { settingEnum = "EAresIntSettingName::" + i.Key, value = i.Value });
            }

            foreach (var i in data.stringSettings)
            {
                dataOutput.stringSettings.Add(new Stringsetting() { settingEnum = "EAresStringSettingName::" + i.Key, value = i.Value });
            }

            dataOutput.roamingSetttingsVersion = data.roamingSetttingsVersion;

            dataOutput.settingsProfiles = data.settingsProfiles;


            return dataOutput;

        }

    }
}
