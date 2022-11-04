using Zenject;

namespace Database
{
    public class DatabaseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindItemDatabase();
        }

        private void BindItemDatabase()
        {
            Container
                .Bind<ItemDatabase>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}
