using System.Collections.Generic;
using VContainer;
using VContainer.Unity;

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
            // UI��potato�I�u�W�F�N�g�쐬�̃C�x���g��ǉ�
            potatoScreen.PotatoButton.onClick.AddListener(() => {

                var iteration = this.potatoSeedService.GeneratePotatoNum();
                for(int i = 0; i < iteration; i++)
                {
                    this.potatoFactory.Create();
                }

            });
        }
    }

}

