using Pokedex.Service.Interfaces;
using Serilog;

namespace Pokedex.Service.Services
{
    public class LogService : ILogService
    {
        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
            //Crashes.TrackError(new Exception(message));
        }

        public void Error(Exception exception)
        {
            Log.Error(exception.Message);
            //Crashes.TrackError(exception);
        }

        public void Info(string message)
        {
            Log.Information(message);
            //Analytics.TrackEvent(message);
        }
    }

}
