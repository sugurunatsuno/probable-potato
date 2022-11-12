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
        List<PotatoModel> potatoes = new List<PotatoModel>();

        readonly PotatoScreen potatoScreen;


        [Inject]
        private ISubscriber<PotatoModel> subscriber;

        PotatoTotalPresenter(
            PotatoScreen potatoScreen)
        {
            this.potatoScreen = potatoScreen;


        }

        void IStartable.Start()
        {
            // メッセージを受信してUIの値を更新する
            subscriber.Subscribe((potato) => 
            {
                UnityEngine.Debug.Log("received: " + potato.Value.ToString() + ", " + potato.GroupID);

                potatoes.Add(potato);

                var total = 0.0f;
                foreach(var p in potatoes)
                {
                    total += p.Value;
                }

                this.potatoScreen.PotatoTotalText.text = total.ToString();
            });
        }
    }
}


