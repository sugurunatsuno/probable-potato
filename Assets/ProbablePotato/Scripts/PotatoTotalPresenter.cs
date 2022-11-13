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
    /// potato�I�u�W�F�N�g�̃��b�Z�[�W���Ǘ����āAUI�ɓ`����N���X
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
            // ���b�Z�[�W����M����UI�̒l���X�V����
            subscriber.Subscribe((value) => 
            {
                total += value;
                this.potatoScreen.PotatoTotalText.text = "total: " + total.ToString("F2") + ", prev: " + value.ToString("F2");
            });
        }
    }
}


