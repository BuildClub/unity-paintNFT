using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SetMetaData : MonoBehaviour
{
    // Start is called before the first frame update
    public NFTstorage.ERC721.NftMetaData NftMetaData;

    public void Send(string cid)
    {
        NftMetaData.SetIPFS(cid);
        var bytes = NFTstorage.Helper.ERC721MetaDataToBytes(NftMetaData);
        StartCoroutine(NFTstorage.NetworkManager.UploadObject(CallBackOnUpload, bytes));
    }

    private void CallBackOnUpload(NFTstorage.DataResponse obj)
    {
        if (obj.Success)
        {
            if (obj.Values != null && obj.Values.Count > 0)
            {
                var cid = obj.Values[0].cid;
                //Debug.Log("Metadata set to: " + cid);
                var path = NFTstorage.Helper.GenerateGatewayPath(cid, NFTstorage.Constants.GatewaysSubdomain[0], true);
                EventManager.OnMetadataUploaded.Invoke(path);
                Debug.Log("Metadata is set to " + path);
            }
        }
        else
        {
            Debug.Log("Error " + obj.Error.message);
        }
    }
}