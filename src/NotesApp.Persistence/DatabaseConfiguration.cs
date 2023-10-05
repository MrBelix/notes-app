namespace NotesApp.Persistence;

public record DatabaseConfiguration(string Host, string Name, string User, string Password)
{
    public override string ToString()
    {
        return $"Host={Host};Port=5432;Database={Name};Username={User};Password={Password}";
    }
}