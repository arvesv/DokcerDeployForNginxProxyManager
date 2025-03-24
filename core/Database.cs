using System.Data.SQLite;

namespace core;

public class Database
{
    private string _SqliteFile { get; init; }
    private SQLiteConnection? _Connection { get; set; }

    public Database(string sqliteFile)
    {
        _SqliteFile = sqliteFile;
    }

    public void Initialize()
    {
        if (!File.Exists(_SqliteFile))
        {
            Console.WriteLine($"Creating SQLite database file: {_SqliteFile}");
            SQLiteConnection.CreateFile(_SqliteFile);
        }
        else
        {
            Console.WriteLine($"Using existing SQLite database file: {_SqliteFile}");
        }

        _Connection = new SQLiteConnection($"Data Source={_SqliteFile};Version=3;");
        _Connection.Open();

        using var command = new SQLiteCommand(_Connection);

        command.CommandText = @"
        CREATE TABLE IF NOT EXISTS Settings (
            Name TEXT PRIMARY KEY  NOT NULL,
            Value TEXT NOT NULL
        );
        ";
        command.ExecuteNonQuery();
    }


}
