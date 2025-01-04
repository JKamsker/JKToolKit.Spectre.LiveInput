using Spectre.Console;

namespace JKToolKit.Spectre.LiveInput.TestConsole;

class Program
{
    static async Task Main(string[] args)
    {
        var ct = CancellationTokenFactory.FromConsoleCancelKeyPress();
        
        var myText = CreateTextField("Waiting for input...");
        await AnsiConsole.Console.LiveInput(myText)
            .StartAsync(async ctx =>
            {
                ctx.OnInputChanged += (_, s) =>
                {
                    ctx.UpdateTarget(CreateTextField(s.Input));
                    ctx.Refresh();
                };
                
                await Task.Delay(-1, ct);
            });
    }
    
    private static Panel CreateTextField(string value) =>
        new Panel(new Markup(value))
            .Expand()
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Green);
}
