using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpfsUrlService
{
    public static string DefaultIpfsGateway = "https://cloudflare-ipfs.com/ipfs/"; 

    public static string ResolveIpfsUrlGateway(string url)
    {
        if (url.StartsWith("ipfs:"))
        {
            url = url.Replace("ipfs://", IpfsUrlService.DefaultIpfsGateway);
        }

        return url;
    }
}
