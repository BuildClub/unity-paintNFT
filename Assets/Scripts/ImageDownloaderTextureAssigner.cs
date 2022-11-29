using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class ImageDownloaderTextureAssigner
{
    public IEnumerator DownloadAndSetImageTexture(string url, UnityAction<Sprite> callback)
    {
        // resolve ipfs if its an ipfs image
        if (url.StartsWith("ipfs"))
        {
            url = IpfsUrlService.ResolveIpfsUrlGateway(url);
        }

        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
        {
            DownloadHandler handle = webRequest.downloadHandler;
            yield return webRequest.SendWebRequest();


            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log(webRequest.error);
                    yield break;

                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log(webRequest.error);
                    yield break;

                case UnityWebRequest.Result.Success:
                    try
                    {
                        Debug.Log("download success");
                        Texture2D texture2d = DownloadHandlerTexture.GetContent(webRequest);

                        Sprite sprite = null;
                        sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), UnityEngine.Vector2.zero);

                        if (sprite != null)
                        {
                            callback.Invoke(sprite);
                        }
                    }
                    catch (Exception e)
                    {
                        yield break;
                    }
                    break;
            }
        }
    }
}
