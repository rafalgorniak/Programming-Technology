using Service.API;

namespace Presentation
{
    public class Model : IModel
    {
        private IService service;
        public Model(IService service = default(IService))
        {
            if (service == null)
            {
                this.service = DataServiceFactory.CreateService();
            }
            else
            {
                this.service = service;
            }
        }
        public IService Service { get { return service; } }
    }
}
