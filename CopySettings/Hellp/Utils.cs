using CopySettings.Obje;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

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
            dataOutput.axisMappings = data.axisMappings;
            dataOutput.actionMappings = new();
            foreach (var i in data.boolSettings)
            {
                dataOutput.boolSettings.Add(i.settingEnum.Replace("EAresBoolSettingName::", string.Empty), i.value);
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

            foreach (var i in data.actionMappings)
            {
                if (!dataOutput.actionMappings.ContainsKey(i.characterName))
                {

                    dataOutput.actionMappings.Add(i.characterName, new Dictionary<string, KeyBind>());
                    dataOutput.actionMappings[i.characterName].Add(i.name, new KeyBind());
                    KeyBind key = dataOutput.actionMappings[i.characterName][i.name];
                    if (i.bindIndex == 0)
                    {
                        key.KeyIndex1 = i.key;
                        key.keyList.Add(i);
                    }

                    else
                    {
                        key.KeyIndex2 = i.key;
                        key.keyList.Add(i);
                    }

                }

                else
                {

                    if (!dataOutput.actionMappings[i.characterName].ContainsKey(i.name))
                    {
                        dataOutput.actionMappings[i.characterName].Add(i.name, new KeyBind());
                        KeyBind key = dataOutput.actionMappings[i.characterName][i.name];
                        if (i.bindIndex == 0)
                        {
                            key.KeyIndex1 = i.key;
                            key.keyList.Add(i);
                        }

                        else
                        {
                            key.KeyIndex2 = i.key;
                            key.keyList.Add(i);
                        }
                    }
                    else
                    {
                        KeyBind key = dataOutput.actionMappings[i.characterName][i.name];

                        if (i.bindIndex == 0)
                        {
                            key.KeyIndex1 = i.key;
                            key.keyList.Add(i);
                        }

                        else
                        {
                            key.KeyIndex2 = i.key;
                            key.keyList.Add(i);
                        }
                    }
                }
            }

            dataOutput.roamingSetttingsVersion = data.roamingSetttingsVersion;

            dataOutput.settingsProfiles = data.settingsProfiles;


            return dataOutput;
        }
        public static Data ConvertDirectorytoData(DataObj data)
        {
            var dataOutput = new Data();
            dataOutput.boolSettings = new();
            dataOutput.intSettings = new();
            dataOutput.floatSettings = new();
            dataOutput.stringSettings = new();
            dataOutput.actionMappings = new();
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

            foreach (var i in data.actionMappings)
            {
                foreach (var j in i.Value)
                {
                    foreach (var k in j.Value.keyList)
                    {
                        dataOutput.actionMappings.Add(k);

                    }
                }
            }
            //foreach (var i in data)

            dataOutput.roamingSetttingsVersion = data.roamingSetttingsVersion;

            dataOutput.settingsProfiles = data.settingsProfiles;


            return dataOutput;

        }
        public static Data FillData(Data d)
        {
            Data NewData = new();
            NewData = Constants.GetNewData();

            foreach (var i in d.boolSettings)
            {
                var item = NewData.boolSettings.FirstOrDefault(x => x.settingEnum == i.settingEnum);
                if (item != null) item.value = i.value;
                else { Constants.Log.Error($"data default {i.settingEnum} not have"); }
            }

            foreach (var i in d.axisMappings)
            {
                var item = NewData.axisMappings.FirstOrDefault(x =>
                (
                    x.bindIndex == i.bindIndex &&
                    x.name == i.name &&
                    x.characterName == i.characterName &&
                    x.scale == i.scale
                ));
                if (item == null)
                {
                    NewData.axisMappings.Add(i);
                    continue;
                }
                else
                {
                    item.key = i.key;
                    continue;

                }

                Constants.Log.Error($"axisMappings fail {i.characterName}");
            }

            foreach (var i in d.actionMappings)
            {
                var item = NewData.actionMappings.Find(x =>
                (x.characterName == i.characterName && x.bindIndex == i.bindIndex && x.name == i.name));

                if (item == null)
                {
                    NewData.actionMappings.Add(i);
                }
                else
                {
                    item.key = i.key;
                    item.ctrl = i.ctrl;
                    item.cmd = i.cmd;
                    item.shift = i.shift;
                    item.alt = i.alt;
                }
            }

            foreach (var i in d.intSettings)
            {

                var item = NewData.intSettings.Find(x => (x.settingEnum == i.settingEnum));
                if (item != null) item.value = i.value;
                else Constants.Log.Error($"intSettings {i.settingEnum}");

            }

            foreach (var i in d.floatSettings)
            {
                var item = NewData.floatSettings.Find(x => (x.settingEnum == i.settingEnum));
                if (item != null) item.value = i.value;
                else Constants.Log.Error($"floatSettings {i.settingEnum}");
            }

            NewData.roamingSetttingsVersion = d.roamingSetttingsVersion;
            NewData.stringSettings = d.stringSettings;

            NewData.settingsProfiles = d.settingsProfiles;
            return NewData;
        }
    }
}
