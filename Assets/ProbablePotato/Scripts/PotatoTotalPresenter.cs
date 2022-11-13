using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using MessagePipe;

namespace ProbablePotato
{
    /// <summary>
    /// potatoオブジェクトのメッセージを管理して、UIに伝えるクラス
    /// </summary>
    public class PotatoTotalPresenter : IStartable
    {
        readonly PotatoScreen potatoScreen;

        private float total = 0.0f;

        [Inject]
        private ISubscriber<float> subscriber;

        PotatoTotalPresenter(
            PotatoScreen potatoScreen)
        {
            this.potatoScreen = potatoScreen;
        }

        void IStartable.Start()
        {
            // メッセージを受信してUIの値を更新する
            subscriber.Subscribe((value) => 
            {
                total += value;
                this.potatoScreen.PotatoTotalText.text = "total: " + total.ToString("F2") + ", prev: " + value.ToString("F2");
            });
        }
    }
}


