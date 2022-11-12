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
        /// �O���[�vID�����֐�
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
        /// potato�I�u�W�F�N�g�̃X�e�[�^�X(��������)�𐶐�����֐�
        /// </summary>
        /// <returns></returns>
        public float GeneratePotatoStatus()
        {

            var generateSpan = UnityEngine.Random.Range(1.0f, 3.0f);
            return generateSpan;
        }

        /// <summary>
        /// potato�I�u�W�F�N�g�̐����������߂�֐�
        /// </summary>
        /// <returns></returns>
        public int GeneratePotatoNum()
        {
            return Mathf.FloorToInt(UnityEngine.Random.Range(2, 5));
        }
    }

}

