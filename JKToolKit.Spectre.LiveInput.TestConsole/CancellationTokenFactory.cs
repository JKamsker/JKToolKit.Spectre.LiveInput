namespace JKToolKit.Spectre.LiveInput.TestConsole;

public static class CancellationTokenFactory
{
    public static CancellationToken FromConsoleCancelKeyPress()
    {
        var cts = new CancellationTokenSource();
        System.Console.CancelKeyPress += (_, _) => cts.Cancel();
        return cts.Token;
    }
}
