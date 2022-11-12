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
            // UI��potato�I�u�W�F�N�g�쐬�̃C�x���g��ǉ�
            potatoScreen.PotatoButton.onClick.AddListener(async () => {

                var iteration = this.potatoSeedService.GeneratePotatoNum();
                var groupID = this.potatoSeedService.GeneratePotatoGroup();
                for(int i = 0; i < iteration; i++)
                {
                    await this.potatoFactory.Create(groupID);
                    // ���v�l���Ǘ�����I�u�W�F�N�g�Ɋe�I�u�W�F�N�g�̒l��ʒm����
                }
            });

        }
    }

}

