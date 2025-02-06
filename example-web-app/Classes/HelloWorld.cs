namespace example_web_app.Classes
{
    public class HelloWorld : IHelloWorld
    {
        // This method is not used in the example, but it is here to show how to use a constructor  
        public HelloWorld()
        {

        }

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
