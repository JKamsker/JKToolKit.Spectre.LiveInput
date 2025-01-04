# SpectreConsole LiveInput

A extension for Spectre.Console that introduces **LiveInput**, enabling real-time user input feedback in console applications.

## 🚀 Features
- **Real-time Input Handling**: Capture and display user input dynamically.
- **Customizable UI Elements**: Style input display with Spectre.Console panels.
- **Cancellation Support**: Interrupt live input gracefully with `Ctrl+C`.

## 📦 Installation
Add the package via NuGet:
```sh
Install-Package JKToolKit.Spectre.LiveInput
```

## 💻 Usage Example
Below is an example of how to use **LiveInput**:

```csharp
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
```

### Explanation:
- `LiveInput` dynamically updates the UI with each user input.
- `OnInputChanged` handles input changes in real-time.
- Graceful exit with `Ctrl+C` using a cancellation token.

## 🛠️ Requirements
- Anything that is ``netstandard2.0`` compatible.
- Spectre.Console

## 🤝 Contributing
Contributions are welcome! Please submit a PR or open an issue.

## 📄 License
This project is licensed under the MIT License.

## 🧑‍💻 Author
Jonas Kamsker
---
⭐ **If you find this project helpful, don't forget to give it a star!**

