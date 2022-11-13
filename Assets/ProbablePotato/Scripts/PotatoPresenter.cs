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
            // UI��potato�I�u�W�F�N�g�쐬�̃C�x���g��ǉ�
            potatoScreen.PotatoButton.onClick.AddListener(() => {

                this.CreateHierarchy();
            });

        }

        /// <summary>
        /// �I�u�W�F�N�g�쐬����
        /// </summary>
        async void CreateHierarchy()
        {
            // �������w��
            var iteration = this.potatoSeedService.GeneratePotatoNum();

            // ���������̃I�u�W�F�N�g(�Q�[���I�u�W�F�N�g�Ȃ�)����
            List<UniTask<PotatoModel>> tasks = new List<UniTask<PotatoModel>>();
            for (int i = 0; i < iteration; i++)
            {
                tasks.Add(this.potatoFactory.Create());
                // ���v�l���Ǘ�����I�u�W�F�N�g�Ɋe�I�u�W�F�N�g�̒l��ʒm����
            }

            // �S�č쐬������
            var result = await UniTask.WhenAll(tasks);

            // �Q�[���I�u�W�F�N�g�𐶐�
            float potatoTotal = 0.0f;
            foreach (var potato in result)
            {
                var potatoView = this.potatoFactory.GeneratePotatoModelView(potato);
                
                // �ʒm�p�̒l��p��
                potatoTotal += potato.Value;

                // ���g�ɃI�u�W�F�N�g���i�[
                valueModels.Add(potato);
            }

            // ���������I�u�W�F�N�g�̒l�����v����UI�ɒʒm
            this.publisher.Publish(potatoTotal);

        }
    }

}

