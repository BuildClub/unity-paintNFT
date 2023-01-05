using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NFTstorage.ERC721;

namespace Web3Unity.Scripts.Prefabs.Minter
{
    public class GodwokenMinter : MonoBehaviour
    {
        // Godwoken Testnet Info
        private string contractAddress = "0x6efb80b573c18a1c12d331835d523670c93525c9";
        private string chain = "Godwoken Testnet v1";
        private string network = "Godwoken/PolyJuice Testnet";
        private string rpc = "https://v1.testnet.godwoken.io/rpc";
        private string chainId = "71401";
        private string abi =
            "[{\"inputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"constructor\"},{\"anonymous\": false,\"inputs\": [{\"indexed\": true,\"internalType\": \"address\",\"name\": \"owner\",\"type\": \"address\"},{\"indexed\": true,\"internalType\": \"address\",\"name\": \"approved\",\"type\": \"address\"},{\"indexed\": true,\"internalType\": \"uint256\",\"name\": \"tokenId\",\"type\": \"uint256\"}],\"name\": \"Approval\",\"type\": \"event\"},{\"anonymous\": false,\"inputs\": [{\"indexed\": true,\"internalType\": \"address\",\"name\": \"owner\",\"type\": \"address\"},{\"indexed\": true,\"internalType\": \"address\",\"name\": \"operator\",\"type\": \"address\"},{\"indexed\": false,\"internalType\": \"bool\",\"name\": \"approved\",\"type\": \"bool\"}],\"name\": \"ApprovalForAll\",\"type\": \"event\"},{\"anonymous\": false,\"inputs\": [{\"indexed\": true,\"internalType\": \"address\",\"name\": \"previousOwner\",\"type\": \"address\"},{\"indexed\": true,\"internalType\": \"address\",\"name\": \"newOwner\",\"type\": \"address\"}],\"name\": \"OwnershipTransferred\",\"type\": \"event\"},{\"anonymous\": false,\"inputs\": [{\"indexed\": false,\"internalType\": \"address\",\"name\": \"account\",\"type\": \"address\"}],\"name\": \"Paused\",\"type\": \"event\"},{\"anonymous\": false,\"inputs\": [{\"indexed\": true,\"internalType\": \"address\",\"name\": \"from\",\"type\": \"address\"},{\"indexed\": true,\"internalType\": \"address\",\"name\": \"to\",\"type\": \"address\"},{\"indexed\": true,\"internalType\": \"uint256\",\"name\": \"tokenId\",\"type\": \"uint256\"}],\"name\": \"Transfer\",\"type\": \"event\"},{\"anonymous\": false,\"inputs\": [{\"indexed\": false,\"internalType\": \"address\",\"name\": \"account\",\"type\": \"address\"}],\"name\": \"Unpaused\",\"type\": \"event\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"to\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"tokenId\",\"type\": \"uint256\"}],\"name\": \"approve\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"owner\",\"type\": \"address\"}],\"name\": \"balanceOf\",\"outputs\": [{\"internalType\": \"uint256\",\"name\": \"\",\"type\": \"uint256\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"uint256\",\"name\": \"tokenId\",\"type\": \"uint256\"}],\"name\": \"burn\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"uint256\",\"name\": \"tokenId\",\"type\": \"uint256\"}],\"name\": \"getApproved\",\"outputs\": [{\"internalType\": \"address\",\"name\": \"\",\"type\": \"address\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"owner\",\"type\": \"address\"},{\"internalType\": \"address\",\"name\": \"operator\",\"type\": \"address\"}],\"name\": \"isApprovedForAll\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"name\",\"outputs\": [{\"internalType\": \"string\",\"name\": \"\",\"type\": \"string\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"owner\",\"outputs\": [{\"internalType\": \"address\",\"name\": \"\",\"type\": \"address\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"uint256\",\"name\": \"tokenId\",\"type\": \"uint256\"}],\"name\": \"ownerOf\",\"outputs\": [{\"internalType\": \"address\",\"name\": \"\",\"type\": \"address\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"pause\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"paused\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"renounceOwnership\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"to\",\"type\": \"address\"},{\"internalType\": \"string\",\"name\": \"uri\",\"type\": \"string\"}],\"name\": \"safeMint\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"from\",\"type\": \"address\"},{\"internalType\": \"address\",\"name\": \"to\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"tokenId\",\"type\": \"uint256\"}],\"name\": \"safeTransferFrom\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"from\",\"type\": \"address\"},{\"internalType\": \"address\",\"name\": \"to\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"tokenId\",\"type\": \"uint256\"},{\"internalType\": \"bytes\",\"name\": \"data\",\"type\": \"bytes\"}],\"name\": \"safeTransferFrom\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"operator\",\"type\": \"address\"},{\"internalType\": \"bool\",\"name\": \"approved\",\"type\": \"bool\"}],\"name\": \"setApprovalForAll\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"bytes4\",\"name\": \"interfaceId\",\"type\": \"bytes4\"}],\"name\": \"supportsInterface\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"symbol\",\"outputs\": [{\"internalType\": \"string\",\"name\": \"\",\"type\": \"string\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"uint256\",\"name\": \"index\",\"type\": \"uint256\"}],\"name\": \"tokenByIndex\",\"outputs\": [{\"internalType\": \"uint256\",\"name\": \"\",\"type\": \"uint256\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"owner\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"index\",\"type\": \"uint256\"}],\"name\": \"tokenOfOwnerByIndex\",\"outputs\": [{\"internalType\": \"uint256\",\"name\": \"\",\"type\": \"uint256\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"uint256\",\"name\": \"tokenId\",\"type\": \"uint256\"}],\"name\": \"tokenURI\",\"outputs\": [{\"internalType\": \"string\",\"name\": \"\",\"type\": \"string\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"totalSupply\",\"outputs\": [{\"internalType\": \"uint256\",\"name\": \"\",\"type\": \"uint256\"}],\"stateMutability\": \"view\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"from\",\"type\": \"address\"},{\"internalType\": \"address\",\"name\": \"to\",\"type\": \"address\"},{\"internalType\": \"uint256\",\"name\": \"tokenId\",\"type\": \"uint256\"}],\"name\": \"transferFrom\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [{\"internalType\": \"address\",\"name\": \"newOwner\",\"type\": \"address\"}],\"name\": \"transferOwnership\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [],\"name\": \"unpause\",\"outputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"function\"}]";

        // info from login
        private string account;
        private string to;
        
        // helper to download the metadata
        private NftMetadataUtils metadataHelper;
        
        // Start is called before the first frame update
        void Start()
        {
            account = PlayerPrefs.GetString("Account");
            to = PlayerPrefs.GetString("Account");
            metadataHelper = new NftMetadataUtils();
            
            // Get a new list of NFTs whenever a new metadata file has been uploaded from camera capture
            EventManager.OnMetadataUploaded.AddListener(MintNewNft);
        }

        public async void MintNewNft(string uri)
        {
            string formattedURI = "https://" + uri;
            print("Mint Nft: " + formattedURI);
            // 'safeMint' creates a new NFT with the given URI
            string methodName = "safeMint";
            
            // args
            string[] obj = {to, formattedURI};
            string args = JsonConvert.SerializeObject(obj);
            

#if UNITY_WEBGL && !UNITY_EDITOR
            // sign/send transaction
            string response = await Web3GL.SendContract(methodName, abi, contractAddress, args, "0", "", "");
#else
            // create data for contract interaction
            string data = await EVM.CreateContractData(abi, methodName, args);
            string response = await Web3Wallet.SendTransaction(chainId, contractAddress, "0", data, "", "");
#endif
            print(response);
        }

        public async Task<int> GetNumberOfNfts()
        {
            // 'balanceOf' returns the number of NFTs of the given owner
            string methodName = "balanceOf";
            
            // args
            string owner = account;
            string[] obj = {owner};
            string args = JsonConvert.SerializeObject(obj);
            
            // call (not a transaction so we pay no gas)
            string response = await EVM.Call(chain, network, contractAddress, abi, methodName, args, rpc);

            // convert response to int
            int numberOfNFTs = 0;
            if (int.TryParse(response, out numberOfNFTs))
                return numberOfNFTs;
            return 0;
        }

        public async Task<List<int>> GetTokenIds()
        {
            // get the number of nfts owned
            int numberOfNFTs = await GetNumberOfNfts();
            if (numberOfNFTs == 0)
            {
                return null;
            }
            
            string methodName = "tokenOfOwnerByIndex";
            
            // for every nft get the id
            List<int> tokenIds = new List<int>();
            for (int index = 0; index < numberOfNFTs; index++)
            {
                // args
                string owner = account;
                string[] obj = {owner, index.ToString()};
                string args = JsonConvert.SerializeObject(obj);
                
                // call (not a transaction so we pay no gas)
                string response = await EVM.Call(chain, network, contractAddress, abi, methodName, args, rpc);
                int tokenId;
                if (int.TryParse(response, out tokenId))
                {
                    tokenIds.Add(tokenId);
                }
            }

            return tokenIds;
        }

        public async void GetNfts()
        {
            // get the number of nfts owned
            int numberOfNFTs = await GetNumberOfNfts();
            if (numberOfNFTs == 0)
            {
                return;
            }

            List<int> tokenIds = await GetTokenIds();
            
            // for every id get the uri
            string methodName = "tokenURI";
            List<string> uris = new List<string>();
            foreach (int tokenId in tokenIds)
            {
                // args
                int[] obj = {tokenId};
                string args = JsonConvert.SerializeObject(obj);
                
                // call (not a transaction so we pay no gas)
                string response = await EVM.Call(chain, network, contractAddress, abi, methodName, args, rpc);
                uris.Add(response);
            }
            
            // for every URI, get the metadata
            List<NftMetaData> nftMetadatas = new List<NftMetaData>();
            foreach (string uri in uris)
            {
                var metadata = await metadataHelper.GetNftMetadataFromUrl(uri);
                nftMetadatas.Add(metadata);
            }
            
            // reverse list of metadatas to get the most recent first
            nftMetadatas.Reverse();
            
            // trigger the 'NFT Updated' event with our full list of nft metadata objects
            // anything in our game can subscribe to this event and update when we have new NFTs
            EventManager.OnNftsUpdated.Invoke(nftMetadatas);
        }
    }
}
