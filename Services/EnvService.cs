
namespace VG.Services
{
    using Serilog;
    using System;
    /// <summary>
    /// This is the environment class.
    /// </summary>
    public sealed class EnvService : IEnvService
    {
        public EnvService() {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public string DbConnectionString => Environment.GetEnvironmentVariable("DatabaseConnection") ?? string.Empty;
    }
}
