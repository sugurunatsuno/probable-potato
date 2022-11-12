using System.Collections.Generic;
using VContainer;
using VContainer.Unity;
using Cysharp.Threading.Tasks;

namespace ProbablePotato
{
    public class PotatoPresenter: IStartable
    {
        readonly PotatoFactory potatoFactory;
        readonly PotatoScreen potatoScreen;
        readonly PotatoSeedService potatoSeedService;

        public PotatoPresenter(
            PotatoFactory potatoFactory,
            PotatoScreen potatoScreen,
            PotatoSeedService potatoSeedService)
        {
            this.potatoFactory = potatoFactory;
            this.potatoScreen = potatoScreen;
            this.potatoSeedService = potatoSeedService;
        }

        void IStartable.Start()
        {
            // UIにpotatoオブジェクト作成のイベントを追加
            potatoScreen.PotatoButton.onClick.AddListener(async () => {

                var iteration = this.potatoSeedService.GeneratePotatoNum();
                var groupID = this.potatoSeedService.GeneratePotatoGroup();
                for(int i = 0; i < iteration; i++)
                {
                    await this.potatoFactory.Create(groupID);
                    // 合計値を管理するオブジェクトに各オブジェクトの値を通知する
                }
            });

        }
    }

}

