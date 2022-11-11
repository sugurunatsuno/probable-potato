using VContainer;
using VContainer.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        /// ステータスを持つゲームオブジェクトのプレハブ
        /// ここではpotatoという名前のオブジェクト
        /// </summary>
        [SerializeField]
        PotatoModelView potatoModelViewPrefab;


        protected override void Configure(IContainerBuilder builder)
        {

            builder.Register<PotatoSeedService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<PotatoPresenter>();
            builder.RegisterComponent(potatoScreen);
            builder.RegisterComponent(potatoModelViewPrefab);
            builder.Register<PotatoFactory>(Lifetime.Scoped);
        }
    }

}

