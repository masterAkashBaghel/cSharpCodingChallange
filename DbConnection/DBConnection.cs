using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DbConnection;


public static class DBConnection
{
    // Static field to hold the connection string
    private static string _connectionString;

    // Static constructor to initialize the connection string
    static DBConnection()
    {
        // Create a configuration builder to read the appsettings.json file
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path to the application's base directory
            .AddJsonFile("appsettings.json") // Add the appsettings.json file to the configuration
            .Build(); // Build the configuration

        // Retrieve the connection string named "DefaultConnection" from the configuration
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // Method to get an open SQL connection
    public static SqlConnection GetConnection()
    {
        // Create a new SqlConnection using the connection string
        SqlConnection connection = new SqlConnection(_connectionString);
        // Open the connection
        connection.Open();
        // Return the open connection
        return connection;
    }
}
