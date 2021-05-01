using Zenject;

namespace AValentini.Helpers.Async
{
    public class ExampleDecoratorInstaller : MonoInstaller<ExampleDecoratorInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ITickable>().To<TestHotKeysAdder>().AsSingle();
        }
    }
}