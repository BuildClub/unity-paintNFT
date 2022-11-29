using System.Collections;
using System.Collections.Generic;
using NFTstorage.ERC721;
using UnityEngine;
using UnityEngine.Events;

public class UploadEvent : UnityEvent<string> { }

public class NftEvent : UnityEvent<List<NftMetaData>> { }

public class EventManager
{
    public static UploadEvent OnImageUploaded = new UploadEvent();
    public static UploadEvent OnMetadataUploaded = new UploadEvent();
    public static NftEvent OnNftsUpdated = new NftEvent();
}
