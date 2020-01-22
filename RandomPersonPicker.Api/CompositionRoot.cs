using LightInject;
using RandomPersonPicker.Data.Interfaces.Repositories;
using RandomPersonPicker.Data.Repositories;

namespace RandomPersonPicker.Api
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IPersonRepository, PersonRepository>();
        }
    }
}
