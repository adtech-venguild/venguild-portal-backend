namespace VG.Services
{
    public interface IEnvService
    {
        /// <summary>
        /// Gets database connection.
        /// </summary>
        string DbConnectionString { get; }
    }
}
