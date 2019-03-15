using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNetCore.Models
{
    public class MockCakeService : ICakeService
    {

        private List<Cake> cakes = new List<Cake>();
        private int idCount = 1;

        public MockCakeService()
        {
            cakes.Add(new Cake() { Id=0, Name = "Strawberry Cake", Price = 150, Details = "Strawberry fileds for ever..." });
        }

        public List<Cake> AllCakes()
        {
            return cakes;
        }

        public Cake CreateCake(string name, int price, string details)
        {
            Cake cake = new Cake() { Id = idCount, Name = name, Price = price, Details = details };
            idCount++;
            cakes.Add(cake);

            return cake;
        }

        public bool DeleteCake(int id)
        {
            bool wasRemoved = false;

            foreach (Cake item in cakes)
            {
                if (item.Id == id)
                {
                    cakes.Remove(item);

                    wasRemoved = true;
                    break;
                }
            }

            return wasRemoved;
        }

        public Cake FindCake(int id)
        {
            foreach (Cake item in cakes)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public bool UpdateCake(Cake cake)
        {
            bool wasUpdated = false;

            foreach (Cake orginal in cakes)
            {
                if (orginal.Id == cake.Id)
                {
                    orginal.Name = cake.Name;
                    orginal.Price = cake.Price;
                    orginal.Details = cake.Details;

                    wasUpdated = true;
                    break;
                }
            }

            return wasUpdated;
        }
    }
}
