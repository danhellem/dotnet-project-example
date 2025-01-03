namespace example_web_app.Classes
{
    public class HelloWorld : IHelloWorld
    {
        public string GetMessage()
        {
            return "Hello, World!";
        }
    }

    public interface IHelloWorld
    {
        string GetMessage();
    }
}
