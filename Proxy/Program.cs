using System;

namespace TODO.DesignPatterns.Proxy
{
    public class Client
    {

        public void ClientCode(ISubject subject)
        {
            // ...

            subject.Request();

            // ...
        }

    }

    public interface ISubject
    {
        void Request();
        void Do();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy);
        }
    }

    public class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            _realSubject = realSubject;
        }

        // Наиболее распространёнными областями применения паттерна
        // Заместитель являются ленивая загрузка, кэширование, контроль доступа,
        // ведение журнала и т.д. Заместитель может выполнить одну из этих
        // задач, а затем, в зависимости от результата, передать выполнение
        // одноимённому методу в связанном объекте класса Реального Субъект.
        public void Request()
        {
            Console.WriteLine("Проверка до вызова");
            if (CheckAccess())
            {
                _realSubject = new RealSubject();
                _realSubject.Request();

                Console.WriteLine("Проверка после вызова");
                LogAccess();
            }
        }

        public bool CheckAccess()
        {
            // Некоторые реальные проверки должны проходить здесь.
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");

            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }

        public void Do()
        {
        }
    }

    public class RealSubject : ISubject
    {
        public void Do()
        {
            Console.WriteLine("Делать");
        }

        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }
}
