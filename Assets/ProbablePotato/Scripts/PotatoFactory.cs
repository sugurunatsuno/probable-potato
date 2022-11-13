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

        public PotatoFactory(
           PotatoSeedService potatoSeedService,
           PotatoModelView potatoModelView)
        {
            this.potatoSeedService = potatoSeedService;
            this.potatoModelView = potatoModelView;
        }

        /// <summary>
        /// potatoオブジェクトの作成
        /// </summary>
        /// <returns></returns>
        public async UniTask<PotatoModel> Create(String groupID)
        {
            var potato = new PotatoModel(potatoSeedService.GeneratePotatoStatus(), groupID);

            await UniTask.Delay((int)(potato.Value * 1000));

            return potato;
        }

        /// <summary>
        /// potatoオブジェクトをもとにゲームオブジェクトを作成する関数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PotatoModelView GeneratePotatoModelView(PotatoModel model)
        {
            var potatoView = UnityEngine.GameObject.Instantiate(this.potatoModelView);
            potatoModelView.Construct(model);

            // publisher.Publish(potato);

            return potatoModelView;
        }
    }
}


