﻿using Colegios.Core.Interfaces.DataContext;
using Colegios.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Colegios.Infrastructure.DataContext
{
    public class DataContext(IlogService logService, IConfiguration configuration) : IDisposable, IDataContext
    {
        private readonly IlogService _logService = logService;
        private readonly IConfiguration _configuration = configuration;
        private SqlConnection? connection;
        public SqlConnection GetConnection()
        {
            try
            {
                if (connection == null || connection.State == ConnectionState.Closed)
                {
                    string defaultConnection = _configuration.GetConnectionString("DefaultConnection") ?? "";
                    connection = new SqlConnection(defaultConnection);
                    connection.Open();
                }
                return connection;
            }
            catch (Exception ex)
            {
                _logService.message($"Error :: {ex}");
                throw;
            }
        }

        public SqlCommand CreateCommand()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = GetConnection();
                command.CommandType = CommandType.Text;
                return command;
            }
            catch (Exception ex)
            {
                _logService.message($"Error :: {ex}");
                throw;
            }
        }
        public void Dispose()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
        }

    }
}
