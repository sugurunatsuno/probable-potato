using VContainer;
using VContainer.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;

namespace ProbablePotato
{
    public class PotatoLifetimeScope : LifetimeScope
    {
        /// <summary>
        /// UI
        /// </summary>
        [SerializeField]
        PotatoScreen potatoScreen;

        /// <summary>
        /// �X�e�[�^�X�����Q�[���I�u�W�F�N�g�̃v���n�u
        /// �����ł�potato�Ƃ������O�̃I�u�W�F�N�g
        /// </summary>
        [SerializeField]
        PotatoModelView potatoModelViewPrefab;


        protected override void Configure(IContainerBuilder builder)
        {

            builder.Register<PotatoSeedService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<PotatoPresenter>();
            builder.RegisterComponent(potatoScreen);
            builder.RegisterComponent(potatoModelViewPrefab);

            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<float>(options);
            builder.Register<PotatoFactory>(Lifetime.Scoped);
            builder.RegisterEntryPoint<PotatoTotalPresenter>();
        }
    }

}

