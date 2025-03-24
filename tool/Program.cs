
using System.ComponentModel;
using Spectre.Console.Cli;
using core;

var app = new CommandApp<NginxProxyCommand>();
return app.Run(args);

public class NginxProxyCommand : Command<NginxProxyCommand.Settings>
{
    public override int Execute(CommandContext context, Settings settings)
    {
        if (string.IsNullOrEmpty(settings.SqliteBb))
        {
            Console.WriteLine("SQLite database file is required.");
            return 1;
        }

        var db = new core.Database(settings.SqliteBb);
        db.Initialize();

        string servicename = settings.ServiceName;
        if (string.IsNullOrEmpty(servicename))
        {
            Console.WriteLine("Service name is required.");
            return 1;
        }
        else
        {
            Console.WriteLine($"Service name is: {servicename}");
        }


        var api = new core.NginxProxyManagerApi("http://dockernuc:81/api");



        Console.WriteLine($"Nginx Proxy Command Executed  {settings.SqliteBb}");
        // Your command logic here
        return 0;
    }

    public class Settings : CommandSettings
    {
        [Description("The SQLite database file to use.")]
        [CommandArgument(0, "[sqlitedb]")]
        public required string SqliteBb { get; set; }

        [CommandOption("--service|-s")]
        public required string ServiceName { get; set; }



    }

}
