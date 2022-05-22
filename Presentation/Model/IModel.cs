using Service.API;

namespace Presentation
{
    public interface IModel
    {
        IService Service
        {
            get;
        }
    }
}
