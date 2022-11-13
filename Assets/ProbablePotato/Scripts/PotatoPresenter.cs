using System.Collections.Generic;
using VContainer;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using MessagePipe;
using MessagePipe.VContainer;

namespace ProbablePotato
{
    public class PotatoPresenter: IStartable
    {
        readonly PotatoFactory potatoFactory;
        readonly PotatoScreen potatoScreen;
        readonly PotatoSeedService potatoSeedService;
        readonly IPublisher<float> publisher;

        public List<IValueModel> valueModels = new List<IValueModel>();

        public PotatoPresenter(
            PotatoFactory potatoFactory,
            PotatoScreen potatoScreen,
            PotatoSeedService potatoSeedService,
            IPublisher<float> publisher)
        {
            this.potatoFactory = potatoFactory;
            this.potatoScreen = potatoScreen;
            this.potatoSeedService = potatoSeedService;
            this.publisher = publisher;
        }

        void IStartable.Start()
        {
            // UIにpotatoオブジェクト作成のイベントを追加
            potatoScreen.PotatoButton.onClick.AddListener(() => {

                this.CreateHierarchy();
            });

        }

        /// <summary>
        /// オブジェクト作成処理
        /// </summary>
        async void CreateHierarchy()
        {
            // 生成数指定
            var iteration = this.potatoSeedService.GeneratePotatoNum();

            // 生成数分のオブジェクト(ゲームオブジェクトなし)生成
            List<UniTask<PotatoModel>> tasks = new List<UniTask<PotatoModel>>();
            for (int i = 0; i < iteration; i++)
            {
                tasks.Add(this.potatoFactory.Create());
                // 合計値を管理するオブジェクトに各オブジェクトの値を通知する
            }

            // 全て作成したら
            var result = await UniTask.WhenAll(tasks);

            // ゲームオブジェクトを生成
            float potatoTotal = 0.0f;
            foreach (var potato in result)
            {
                var potatoView = this.potatoFactory.GeneratePotatoModelView(potato);
                
                // 通知用の値を用意
                potatoTotal += potato.Value;

                // 自身にオブジェクトを格納
                valueModels.Add(potato);
            }

            // 生成したオブジェクトの値を合計してUIに通知
            this.publisher.Publish(potatoTotal);

        }
    }

}

