namespace Pokedex.Service.Interfaces;

public interface ILogService
{
    void Debug(string message);
    void Error(Exception exception);
    void Info(string message);
}