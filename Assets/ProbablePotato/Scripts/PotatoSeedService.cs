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

