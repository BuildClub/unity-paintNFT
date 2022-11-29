using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using NFTstorage.ERC721;

public class NftMetadataUtils
{
    public async Task<NftMetaData> GetNftMetadataFromUrl(string metadataUrl)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(metadataUrl))
        {
            await webRequest.SendWebRequest();
            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            NftMetaData data = JsonUtility.FromJson<NftMetaData>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
            return data;
        }
    }
}
