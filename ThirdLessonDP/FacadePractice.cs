using System;

// TODO: раскомментировать код в клиенте, который должен в консоли выводить следующее:
/*
Facade initializes subsystems:
Subsystem1: Ready!
Subsystem2: Get ready!
Subsystem3: We are ready to finish!
Facade orders subsystems to perform the action:
Subsystem1: Go!
Subsystem2: Fire!
Subsystem3: Finish!
 */
namespace TODO.DesignPatterns.Facade.Conceptual
{

    class Client
    {
        public static void ClientCode(PostClient facade)
        {
            Console.Write(facade.SendPost());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new TextWriter();
            OrthographyChecker orthographyChecker = new OrthographyChecker();
            PostSender postSender = new PostSender();
            PostClient client = new PostClient(textWriter, orthographyChecker, postSender);

            Client.ClientCode(client);
            Console.Read();
        }
    }

    public class PostClient
    {
        private TextWriter _textWriter;
        private OrthographyChecker _orthographyChecker;
        private PostSender _postSender;

        public PostClient(TextWriter textWriter, OrthographyChecker orthographyChecker, PostSender postSender)
        {
            _textWriter = textWriter;
            _orthographyChecker = orthographyChecker;
            _postSender = postSender;
        }

        public string SendPost()
        {
            string result = "";
            var text = _textWriter.Write();
            result += text;
            result += _orthographyChecker.Check(text);
            result += _postSender.Send();
            return result;
        }
    }

    public class PostSender
    {
        public string Send()
        {
            return "Post sended\n";
        }
    }

    public class OrthographyChecker
    {
        public string Check(string text)
        {
            return "Errors not found\n";
        }
    }

    public class TextWriter
    {
        public string Write()
        {
            Console.Write("Start write text: ");
            return Console.ReadLine() + "\n";
        }
    }
}
