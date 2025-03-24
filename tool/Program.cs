
using Spectre.Console.Cli;

var app = new CommandApp<NginxProxyCommand>();
return app.Run(args);

public class NginxProxyCommand : Command<NginxProxyCommand.Settings>
{
    public override int Execute(CommandContext context, Settings settings)
    {
        Console.WriteLine($"Nginx Proxy Command Executed  {settings.Args}  {settings.Args.Length} args");
        // Your command logic here
        return 0;
    }

    public class Settings : CommandSettings
    {
        [CommandArgument(0, "[args]")]
        public string[] Args { get; set; } = Array.Empty<string>();
    }
}
