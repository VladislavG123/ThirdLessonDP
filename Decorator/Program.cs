using System;

namespace TODO.DesignPatterns.Composite.Conceptual
{
    public class Client
    {
        public void ClientCode(Cake component)
        {
            Console.WriteLine(component.GetCost());
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Cake spongeCakeAndChocolate = new SpongeCake();
            Console.Write("Sponge cake with chocolate: ");
            Chocolate chocolate = new Chocolate(spongeCakeAndChocolate);
            client.ClientCode(chocolate);
            Console.WriteLine();

            Cake sandCakeAndCinnamon = new SandCake();
            Console.Write("Sand cake with cinnamon: ");
            Cinnamon cinnamon = new Cinnamon(sandCakeAndCinnamon);
            client.ClientCode(cinnamon);
            Console.WriteLine();

            Cake fullCake = new SandCake();
            Console.Write("Sand cake with chocolate and cinnamon: ");
            chocolate = new Chocolate(fullCake);
            cinnamon = new Cinnamon(chocolate);
            client.ClientCode(cinnamon);
            Console.WriteLine();

            Console.Read();
        }
    }

    abstract class Decorator : Cake
    {
        protected Cake _component;

        public Decorator(Cake component)
        {
            _component = component;
        }


        public override int GetCost()
        {
            if (this._component != null)
            {
                return _component.GetCost();
            }
            else
            {
                return 0;
            }
        }
    }


    class Chocolate : Decorator
    {
        public Chocolate(Cake comp) : base(comp)
        { }

        public override int GetCost()
        {
            return base.GetCost() + 200;
        }
    }

    class Cinnamon : Decorator
    {
        public Cinnamon(Cake comp) : base(comp)
        { }

        public override int GetCost()
        {
            return base.GetCost() + 500;
        }
    }

    public abstract class Cake
    {
        public abstract int GetCost();
    }

    public class SpongeCake : Cake
    {
        public override int GetCost()
        {
            return 2000;
        }
    }

    public class SandCake : Cake
    {
        public override int GetCost()
        {
            return 1000;
        }
    }
}
