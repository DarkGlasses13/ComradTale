using Zenject;

namespace SaveSystem
{
    public class SaveSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStorage();
            BindSaveDataProvider();
        }

        private void BindStorage()
        {
            Container
                .Bind<Storage>()
                .FromNew()
                .AsSingle();
        }

        private void BindSaveDataProvider()
        {
            Container
                .Bind<SaveDataProvider>()
                .FromNew()
                .AsSingle();
        }
    }
}
