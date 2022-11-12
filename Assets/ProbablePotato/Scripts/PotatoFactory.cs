using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
using System;
using MessagePipe;
using MessagePipe.VContainer;

namespace ProbablePotato
{
    public class PotatoFactory
    {
        readonly PotatoSeedService potatoSeedService;
        readonly PotatoModelView potatoModelView;

        private readonly IPublisher<PotatoModel> publisher;

        public PotatoFactory(
           PotatoSeedService potatoSeedService,
           PotatoModelView potatoModelView,
           IPublisher<PotatoModel> publisher)
        {
            this.potatoSeedService = potatoSeedService;
            this.potatoModelView = potatoModelView;
            this.publisher = publisher;
        }

        /// <summary>
        /// potatoオブジェクトの作成
        /// シーン上にGameObjectも作成する
        /// </summary>
        /// <returns></returns>
        public async UniTask<PotatoModelView> Create(String groupID)
        {
            var potato = new PotatoModel(potatoSeedService.GeneratePotatoStatus(), groupID);

            await UniTask.Delay((int)(potato.Value * 1000));

            var potatoView = UnityEngine.GameObject.Instantiate(this.potatoModelView);
            potatoModelView.Construct(potato);

            publisher.Publish(potato);

            return potatoModelView;
        }
    }
}


