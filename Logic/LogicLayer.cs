using Data;

namespace Logic
{
    public abstract class AbstractLogicAPI
    {
        private Service service;
        private AbstractDataAPI dataLayer;
        private class LogicLayer : AbstractLogicAPI
        {
            public LogicLayer(AbstractDataAPI dataLayer)
            {
                this.dataLayer = dataLayer;
                service = new Service();
            }

            public override void AddElement(string id, string name, string author)
            {
                service.AddElement(id, name, author, dataLayer);
            }

            public override void AddUser(string id, string name, string surname)
            {
                service.AddUser(id, name, surname, dataLayer);
            }

            public override void RemoveElement(string id)
            {
                service.RemoveElement(id, dataLayer);
            }

            public override void RemoveUser(string id)
            {
                service.RemoveUser(id, dataLayer);
            }

            public override void RentElement(string elementId, string userId)
            {
                service.RentElement(elementId, userId, dataLayer);
            }

            public override void ReturnElement(string elementId, string userId)
            {
                service.ReturnElement(elementId, userId, dataLayer);
            }
        }

        public static AbstractLogicAPI CreateLayer(AbstractDataAPI dataLayer)
        {
            return new LogicLayer(dataLayer);
        }

        public abstract void AddElement(string id, string name, string author);
        public abstract void RemoveElement(string id);
        public abstract void AddUser(string id, string name, string surname);
        public abstract void RemoveUser(string id);
        public abstract void RentElement(string elementId, string userId);
        public abstract void ReturnElement(string elementId, string userId);
    }
}
