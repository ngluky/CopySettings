using CopySettings.Obje;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CopySettings.Hellp;
using System.IO;
using System.Windows.Markup;

namespace CopySettings.Hellp
{
    public static class AthLogin
    {
        public static async Task<Account> LoginUserPass(string User, string Pass)
        {

            #region cmd
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            string com = $".\\Ath\\Ath.exe login \"{User}\" \"{Pass}\" .\\Ath\\cookie\\{Convert.ToBase64String(Encoding.UTF8.GetBytes(User))}";
            cmd.StandardInput.WriteLine(com);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            await cmd.WaitForExitAsync();
            string v = await cmd.StandardOutput.ReadToEndAsync().ConfigureAwait(false);
            string[] line = v.Split("\n");
            #endregion
            AthJson data = null;

              Account user = new();

            foreach (var l in line)
            {
                if (l.StartsWith("{\"isSu\""))
                {
                    data = JsonConvert.DeserializeObject<AthJson>(l);
                    break;
                }
            }

            if (data == null || data.data == null) return null;
            
            RestClient client = new RestClient("https://auth.riotgames.com/userinfo");

            RestRequest request = new();
            foreach (var kv in data.data)
            {
                request.AddHeader(kv.Key, kv.Value);
                if (kv.Key == "Authorization") user.AccessToken = kv.Value;
                if (kv.Key == "X-Riot-Entitlements-JWT") user.EntitlementToken = kv.Value;
            }
            

            var res = await client.ExecutePostAsync<Userinfo>(request);

            user.Ppuuid = res.Data.puuid;
            user.DisplayName = await ApiValorantCline.GetNameAsunc(res.Data.puuid).ConfigureAwait(false);
            user.Region = Constants.Region;
            user.IsLocal = false;

            cmd.Close();
            return user;
        }

        public static async Task<List<Account>> LoginCookie(string pathCookie)
        {
            DirectoryInfo d = new DirectoryInfo(pathCookie); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles();

            var them = new List<Task>();
            var themdata = new List<Task<Account>>();
            var dataReturn = new List<Account>();
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            foreach (FileInfo file in Files)
            {
                async Task get()
                {


                    string com = $".\\Ath\\Ath.exe get \"{file.FullName}\"";
                    cmd.StandardInput.WriteLine(com);
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    await cmd.WaitForExitAsync().ConfigureAwait(false);
                }

                them.Add(get());

            }

            await Task.WhenAll(them).ConfigureAwait(false);
            string v = await cmd.StandardOutput.ReadToEndAsync().ConfigureAwait(false);
            cmd.Close();
            string[] line = v.Split("\n");

            foreach (var l in line)
            {
                if (l.StartsWith("{\"isSu\""))
                {
                    async Task<Account> getUser()
                    {
                        var data = JsonConvert.DeserializeObject<AthJson>(l);
                        Account user = new();
                        RestClient client = new RestClient("https://auth.riotgames.com/userinfo");

                        RestRequest request = new();
                        foreach (var kv in data.data)
                        {
                            request.AddHeader(kv.Key, kv.Value);
                            if (kv.Key == "Authorization") user.AccessToken = kv.Value;
                            if (kv.Key == "X-Riot-Entitlements-JWT") user.EntitlementToken = kv.Value;
                        }


                        var res = await client.ExecutePostAsync<Userinfo>(request);

                        user.Ppuuid = res.Data.puuid;
                        user.DisplayName = await ApiValorantCline.GetNameAsunc(res.Data.puuid).ConfigureAwait(false);
                        user.Region = Constants.Region;
                        user.IsLocal = false;
                        return user;
                    }

                    themdata.Add(getUser());
                }
            }
            dataReturn.AddRange(await Task.WhenAll(themdata).ConfigureAwait(false));
            return dataReturn; 
        }
    }
}
