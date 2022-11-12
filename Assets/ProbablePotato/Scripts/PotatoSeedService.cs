using VContainer;
using VContainer.Unity;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ProbablePotato
{
    public class PotatoSeedService
    {
        private SHA256CryptoServiceProvider cryptoServiceProvider;

        PotatoSeedService()
        {
            // UnityEngine.Random.InitState(DateTime.Now.Millisecond);
            cryptoServiceProvider = new SHA256CryptoServiceProvider();
        }

        /// <summary>
        /// グループIDを作る関数
        /// </summary>
        /// <returns></returns>
        public String GeneratePotatoGroup()
        {
            var seed = UnityEngine.Random.Range(0f, 1f);
            
            var hashBytes = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(seed.ToString()));

            var hashStr = new StringBuilder();
            foreach(var h in hashBytes)
            {
                hashStr.Append(h.ToString("x2"));
            }

            return hashStr.ToString();
        }

        /// <summary>
        /// potatoオブジェクトのステータス(生成時間)を生成する関数
        /// </summary>
        /// <returns></returns>
        public float GeneratePotatoStatus()
        {

            var generateSpan = UnityEngine.Random.Range(1.0f, 3.0f);
            return generateSpan;
        }

        /// <summary>
        /// potatoオブジェクトの生成個数を決める関数
        /// </summary>
        /// <returns></returns>
        public int GeneratePotatoNum()
        {
            return Mathf.FloorToInt(UnityEngine.Random.Range(2, 5));
        }
    }

}

