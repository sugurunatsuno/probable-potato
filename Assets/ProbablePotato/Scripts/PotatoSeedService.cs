using VContainer;
using VContainer.Unity;
using UnityEngine;
using System;

namespace ProbablePotato
{
    public class PotatoSeedService
    {
        PotatoSeedService()
        {
            UnityEngine.Random.InitState(DateTime.Now.Millisecond);
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

