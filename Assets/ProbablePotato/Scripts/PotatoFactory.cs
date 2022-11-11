using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        /// シーン上にGameObjectも作成する
        /// </summary>
        /// <returns></returns>
        public PotatoModelView Create()
        {
            var potato = new PotatoModel(potatoSeedService.GeneratePotatoStatus());
            var potatoView = Object.Instantiate(this.potatoModelView);
            potatoModelView.Construct(potato);
            return potatoModelView;
        }
    }
}


