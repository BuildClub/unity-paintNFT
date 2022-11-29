using System;
using Models;
using UnityEngine;

namespace Web3Unity.Scripts.Prefabs.Minter
{
    public class MintWeb3Wallet721 : MonoBehaviour
    {

        private string chain = "ethereum";
        private string network = "goerli"; // mainnet ropsten kovan rinkeby goerli
        private string account;
        private string to;
        private string cid721 = "bafkzvzacdlxhaqsig3fboo3kjzshfb6rltxivrbnrqwy2euje7sq";
        private string chainId = "5";
        private string type721 = "721";
        string contract = "0x741C3F3146304Aaf5200317cbEc0265aB728FE07";
        
        public void Awake()
        {
            account = PlayerPrefs.GetString("Account");
            to = PlayerPrefs.GetString("Account");
        }

        // Start is called before the first frame update
        public async void MintNft721()
        {
            CreateMintModel.Response nftResponse = await EVM.CreateMint(chain, network, account, to, cid721, type721);
            Debug.Log("NFT Response: " + nftResponse);
            // connects to user's browser wallet (metamask) to send a transaction
            try
            {
                if (nftResponse == null)
                {
                    Debug.LogError("nftResponse is null");
                    return;
                }

                if (nftResponse.tx == null)
                {
                    Debug.LogError("nftResponse.tx is null");
                    return;
                }

                Debug.Log($"tx.to = {nftResponse.tx.to}");
                Debug.Log($"tx.value = {nftResponse.tx.value}");
                Debug.Log($"tx.data = {nftResponse.tx.data}");
                Debug.Log($"tx.gasLimit = {nftResponse.tx.gasLimit}");
                Debug.Log($"tx.gasPrice = {nftResponse.tx.gasPrice}");

                string response = await Web3Wallet.SendTransaction(chainId, nftResponse.tx.to, nftResponse.tx.value, nftResponse.tx.data, nftResponse.tx.gasLimit, nftResponse.tx.gasPrice);
                print(response);
                Debug.Log(response);
            } catch (Exception e) {
                Debug.LogException(e, this);
            }
        }

        public async void VoucherMintNft721()
        {
            // validates the account that sent the voucher, you can change this if you like to fit your system
            if (PlayerPrefs.GetString("Web3Voucher721") == "0x1372199B632bd6090581A0588b2f4F08985ba2d4"){
                CreateMintModel.Response nftResponse = await EVM.CreateMint(chain, network, account, to, cid721, type721);
                Debug.Log("NFT Response: " + nftResponse);
                // connects to user's browser wallet (metamask) to send a transaction
                try
                {
                    Debug.Log($"tx.to = {nftResponse.tx.to}");
                    Debug.Log($"tx.value = {nftResponse.tx.value}");
                    Debug.Log($"tx.data = {nftResponse.tx.data}");
                    Debug.Log($"tx.gasLimit = {nftResponse.tx.gasLimit}");
                    Debug.Log($"tx.gasPrice = {nftResponse.tx.gasPrice}");

                    string response = await Web3Wallet.SendTransaction(chainId, nftResponse.tx.to, nftResponse.tx.value, nftResponse.tx.data, 2100000.ToString(), 8000000000.ToString());
                    print(response);
                    Debug.Log(response);
                } catch (Exception e) {
                    Debug.LogException(e, this);
                }
            }
            else
            {
                Debug.Log("Voucher Invalid");
            }
        }
    }
}
