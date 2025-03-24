
using System.CommandLine;
using System.CommandLine.Invocation;

var rootCommand = new RootCommand
{
    new Option<string>(
        "--name",
        description: "Your name")
};

rootCommand.Description = "Sample app for parsing command line arguments";

rootCommand.Handler = CommandHandler.Create<string>((name) =>
{
    Console.WriteLine($"Hello, {name}!");
});

await rootCommand.InvokeAsync(args);

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
