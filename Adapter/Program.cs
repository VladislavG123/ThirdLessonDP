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
            Console.WriteLine($"Car can {car.Move()} ");
            ITransport traveler = new Camel(car);

            Console.WriteLine("Camel can " + traveler.Move());
        }
    }

    public class Camel : ITransport
    {
        private readonly Car _car;

        public Camel(Car car)
        {
            _car = car;
        }

        public string Move()
        {
            return $"{_car.Move()} also on the sands of the desert";
        }
    }

    public interface ITransport
    {
        string Move();
    }

    public class Car
    {
        public string Move()
        {
            return "move on the road";
        }
    }
}
