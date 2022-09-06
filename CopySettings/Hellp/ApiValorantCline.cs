using CopySettings.Obje;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;





namespace CopySettings.Hellp
{
    public class ApiValorantCline
    {
        public static async Task<Data> GetPlayerSetting(Account u)
        {
            Data data_notFill = await FetchUserSettings(u).ConfigureAwait(false);
            return null;
        }

        public static async Task<Data> FetchUserSettings(Account user)
        {

            FetchResponseData response;

            RestResponse resp = await DoCachedRequestAsync(Method.Get,
                "https://playerpreferences.riotgames.com/playerPref/v3/getPreference/Ares.PlayerSettings", true, user);
            if (!resp.IsSuccessful) return new Data();
            var responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(resp.Content);
            Data settings;
            try
            {
                settings = Utils.Decompress(Convert.ToString(responseData["data"]));
            }
            catch (KeyNotFoundException)
            {
                return new Data();
            }
            return settings;
        }
        public async Task<string> GetPlayerCard(Account user)
        {
            var client = new RestClient($"https://pd.{user.Region}.a.pvp.net/store/v1/entitlements/{user.Ppuuid}/3f296c07-64c3-494c-923b-fe692a4fa1bd");
            var request = new RestRequest();
            request.AddHeader("X-Riot-Entitlements-JWT", user.EntitlementToken);
            request.AddHeader("Authorization", $"Bearer {user.AccessToken}");

            var r = await client.ExecuteGetAsync<ItemReq>(request).ConfigureAwait(false);
            if (r.IsSuccessful)
                return r.Data.Entitlements[0].ToString();
            return null;
        }

        public static async Task<bool> putUserSettings(Account user, Data newData)
        {
            RestClient client = new RestClient(new RestClientOptions() { RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true });
            RestRequest request;
            request = new RestRequest("https://playerpreferences.riotgames.com/playerPref/v3/savePreference", Method.Put);
            request.AddJsonBody(new { type = "Ares.PlayerSettings", data = Utils.Compress(newData) });
            request.AddHeader("X-Riot-Entitlements-JWT", user.EntitlementToken);
            request.AddHeader("Authorization", user.AccessToken);
            request.AddHeader("X-Riot-ClientPlatform",
                "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
            request.AddHeader("X-Riot-ClientVersion", Constants.Version);
            RestResponse response = await (new RestClient().ExecuteAsync(request));

            if (!response.IsSuccessful)
            {
                try
                {
                    return false;
                }
                catch
                {

                }
            }

            Dictionary<string, object> responseDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content);
            if (responseDict.ContainsKey("data")) return true;
            return false;
        }

        public static async Task<RestResponse> DoCachedRequestAsync(Method method, string url, bool addRiotAuth, Account user)
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            if (addRiotAuth)
            {
                request.AddHeader("X-Riot-Entitlements-JWT", user.EntitlementToken);
                request.AddHeader("Authorization", user.AccessToken);
                request.AddHeader("X-Riot-ClientPlatform",
                    "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
                request.AddHeader("X-Riot-ClientVersion", Constants.Version);
            }

            var response = await client.ExecuteAsync(request, method).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                //Constants.Log.Error("Request to {url} Failed: {e}", url, response.ErrorException);
                return response;
            }
            return response;
        }

        public static async Task<string> GetNameAsunc(Guid puuid)
        {
            var options = new RestClientOptions(new Uri($"https://pd.{Constants.Region}.a.pvp.net/name-service/v2/players"))
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            var client = new RestClient(options);
            RestRequest request = new()
            {
                RequestFormat = DataFormat.Json
            };

            string[] body = { puuid.ToString() };
            request.AddJsonBody(body);
            var response = await client.ExecutePutAsync(request).ConfigureAwait(false);
            if (response.IsSuccessful)
                try
                {
                    string incorrectContent = response.Content.Replace("[", string.Empty).Replace("]", string.Empty).Replace("\n", string.Empty);
                    var content = JsonConvert.DeserializeObject<NameServiceResponse>(incorrectContent);
                    return content.GameName + "#" + content.TagLine;
                }
                catch (Exception e)
                {
                    return "";
                }

            return "";
        }
    }
}
