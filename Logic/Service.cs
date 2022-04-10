using Data;
using System.Collections.Generic;

namespace Logic
{
    internal class Service
    {
        internal void AddElement(string id, string name, string author, AbstractDataAPI dataLayer)
        {
            if (!dataLayer.ElementExists(id)) dataLayer.AddElement(id, name, author);
            else throw new System.InvalidOperationException();
        }

        internal void AddUser(string id, string name, string surname, AbstractDataAPI dataLayer)
        {
            if (!dataLayer.UserExists(id)) dataLayer.AddUser(id, name, surname);
            else throw new System.InvalidOperationException();
        }

        internal void RemoveElement(string id, AbstractDataAPI dataLayer)
        {
            if (dataLayer.ElementExists(id))
            {
                List<string> elements = dataLayer.GetElementOccurrences(id);
                foreach (string element in elements)
                {
                    dataLayer.RemoveElementOccurrence(element);
                }
                dataLayer.RemoveElement(id);
            }
            else throw new System.InvalidOperationException();
        }

        internal void RemoveUser(string id, AbstractDataAPI dataLayer)
        {
            if (dataLayer.UserExists(id)) dataLayer.RemoveUser(id);
            else throw new System.InvalidOperationException();
        }

        internal void RentElement(string elementId, string userId, AbstractDataAPI dataLayer)
        {
            if (dataLayer.ElementExists(elementId) && dataLayer.ElementIsAvailable(elementId) 
                && dataLayer.UserExists(userId))
            {
                dataLayer.RentElement(elementId, userId);
                dataLayer.MakeElementAvailable(dataLayer.WhichBookHas(elementId, userId), false);
            }
            else throw new System.InvalidOperationException();
        }

        internal void ReturnElement(string elementId, string userId, AbstractDataAPI dataLayer)
        {
            if ( dataLayer.UserExists(userId) && dataLayer.HasBook(elementId, userId))
            {
                string elementNo = dataLayer.WhichBookHas(elementId, userId);
                dataLayer.ReturnElement(elementNo, userId);
                dataLayer.MakeElementAvailable(elementNo, true);
            }
            else throw new System.InvalidOperationException();
        }
    }
}
