using System.Collections;
using System.Collections.Generic;
using NFTstorage.ERC721;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NftDisplay : MonoBehaviour
{
    public Image nftImage;
    public TMP_InputField imagePath;

    private ImageDownloaderTextureAssigner _imageDownloaderTextureAssigner;
    private List<NftMetaData> _metaDatas;
    private int _currentNftIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        _imageDownloaderTextureAssigner = new ImageDownloaderTextureAssigner();
        EventManager.OnNftsUpdated.AddListener(SetNfts);
        Close();
    }

    public void SetNfts(List<NftMetaData> metaDatas)
    {
        _metaDatas = metaDatas;
        if (_metaDatas.Count > 0)
        {
            _currentNftIndex = 0;
            SetNftImage(_metaDatas[_currentNftIndex].image);
            Show();
        }
    }
    
    public void Show()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Close()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void PreviousImage()
    {
        _currentNftIndex--;
        if (_currentNftIndex < 0)
            _currentNftIndex = _metaDatas.Count - 1;
        SetNftImage(_metaDatas[_currentNftIndex].image);
    }

    public void NextImage()
    {
        _currentNftIndex++;
        if (_currentNftIndex >= _metaDatas.Count)
            _currentNftIndex = 0;
        SetNftImage(_metaDatas[_currentNftIndex].image);
    }
    
    private void SetNftImage(string nftUrl)
    {
        if (string.IsNullOrEmpty(nftUrl))
            return;
        StartCoroutine(_imageDownloaderTextureAssigner.DownloadAndSetImageTexture(nftUrl, AssignSprite));
        imagePath.text = nftUrl;
    }
    
    private void AssignSprite(Sprite sprite)
    {
        nftImage.sprite = sprite;
    }
}
