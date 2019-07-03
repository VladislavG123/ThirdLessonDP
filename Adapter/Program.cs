// TODO: восстановить работоспособность кода, чтобы он выводил следующий результат в консоли
/*
Client: I get a simple component:
RESULT: ConcreteComponent

Client: Now I've got a decorated component:
RESULT: ConcreteDecoratorB(ConcreteDecoratorA(ConcreteComponent))
Press any key to continue . . .
*/

using System;

namespace TODO.DesignPatterns.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Traveler traveler = new Camel(car);

            Console.WriteLine(traveler.Travel());
        }
    }

    public class Camel : Traveler
    {
        private readonly Car _car;

        public Camel(Car car)
        {
            _car = car;
        }

        public string Travel()
        {
            return $"Camel is {_car.Move()}";
        }
    }

    public interface Traveler
    {
        string Travel();
    }

    public class Car
    {
        public string Move()
        {
            return "moving";
        }
    }
}
