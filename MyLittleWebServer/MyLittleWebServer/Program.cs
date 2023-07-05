using System.Net;

namespace MyLittleWebServer;

public class WebHost
{
    int port;
    HttpListener httpListener;

    public WebHost(int port)
    {
        this.port = port;
        httpListener = new();
    }

    public void Run()
    {
        httpListener.Prefixes.Add($"http://localhost:{port}/");

        httpListener.Start();

        Console.WriteLine($"Http server started on {port}");

        while (true)
        {
            var context = httpListener.GetContext();
            Task.Run(() =>
            {
                HandleRequest(context);
            });
        }
    }

    private void HandleRequest(HttpListenerContext context)
    {
        var str = context.Request.RawUrl;
        var path = $@"C:\Users\namiqrasullu\Desktop\MyLittleWebServer\MyLittleWebServer\Views\{str?.Split('/').Last()}.htm";
        var response = context.Response;
        StreamWriter sw = new(response.OutputStream);

        try
        {
            var src = File.ReadAllText(path);
            sw.Write(src);
        }
        catch
        {
            var src = File.ReadAllText(@"C:\Users\namiqrasullu\Desktop\MyLittleWebServer\MyLittleWebServer\Views\error.htm");
            sw.Write(src);
        }
        finally
        {
            sw.Close();
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        new WebHost(27001).Run();
    }
}