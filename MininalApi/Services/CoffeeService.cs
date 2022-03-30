using MininalApi.Models;
using MininalApi.Repositories;

namespace MininalApi.Services
{
    public class CoffeeService:ICoffeeService
    {
        public CoffeeModel Create(CoffeeModel coffee) {
            coffee.Id = CoffeeRepository.Coffees.Count + 1;
            CoffeeRepository.Coffees.Add(coffee);
            return coffee;
        }

        public CoffeeModel? Get(int id) { 
            var coffee = CoffeeRepository.Coffees.FirstOrDefault<CoffeeModel>(c=>c.Id==id);
            if (coffee == null) {
                return null;
             }
            return coffee;
        }

        public List<CoffeeModel> List() {
            var coffees = CoffeeRepository.Coffees;
            return coffees;
        }

        public CoffeeModel? Update(CoffeeModel newCoffee) {
            var coffeeToBeUpdate = CoffeeRepository.Coffees.FirstOrDefault<CoffeeModel>(c => c.Id == newCoffee.Id);
            if (coffeeToBeUpdate is null)
            {
                return null;
            }
            coffeeToBeUpdate.Name = newCoffee.Name;
            coffeeToBeUpdate.Description = newCoffee.Description;
            return newCoffee;
        }

        public bool Delete(int id) {
            var coffeeToBeRemove = CoffeeRepository.Coffees.FirstOrDefault<CoffeeModel>(c => c.Id == id);
            if (coffeeToBeRemove is null)
            {
                return false;
            }
            CoffeeRepository.Coffees.Remove(coffeeToBeRemove);
            return true;
        }
    }
}
