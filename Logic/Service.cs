using Data;
using System.Collections.Generic;

namespace Logic
{
    internal class Service
    {
        internal void AddBook(string id, string name, string author, AbstractDataAPI dataLayer)
        {
            if (!dataLayer.BookExists(id)) dataLayer.AddBook(new Book(id, name, author));
            else throw new System.InvalidOperationException();
        }

        internal void AddUser(string id, string name, string surname, AbstractDataAPI dataLayer)
        {
            if (!dataLayer.UserExists(id)) dataLayer.AddUser(new User(id, name, surname));
            else throw new System.InvalidOperationException();
        }

        internal void RemoveBook(string id, AbstractDataAPI dataLayer)
        {
            if (dataLayer.BookExists(id))
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
            if (dataLayer.BookExists(elementId) && dataLayer.ElementIsAvailable(elementId) 
                && dataLayer.UserExists(userId))
            {
                dataLayer.RentElement(new Rental(dataLayer.GetUser(userId), dataLayer.WhichBookIsAvailable(elementId)));
                dataLayer.MakeBookAvailable(dataLayer.WhichBookHas(elementId, userId), false);
            }
            else throw new System.InvalidOperationException();
        }

        internal void ReturnElement(string elementId, string userId, AbstractDataAPI dataLayer)
        {
            if ( dataLayer.UserExists(userId) && dataLayer.HasBook(elementId, userId))
            {
                dataLayer.MakeBookAvailable(dataLayer.WhichBookHas(elementId, userId), true);
                dataLayer.ReturnElement(new Return(dataLayer.GetUser(userId), dataLayer.WhichBookHas(elementId, userId)));
            }
            else throw new System.InvalidOperationException();
        }
    }
}
