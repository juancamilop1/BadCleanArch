using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Data;

using System.Data;
using Microsoft.Data.SqlClient;

public static class BadDb
{
	// Convertido a propiedad para evitar campo público mutable.
	// Mantengo setter público porque Program.cs asigna la cadena desde configuración.
	public static string ConnectionString { get; set; } = "Server=localhost;Database=master;TrustServerCertificate=True";

	public static int ExecuteNonQueryUnsafe(string sql)
	{
		var conn = new SqlConnection(ConnectionString);
		var cmd = new SqlCommand(sql, conn);
		conn.Open();
		return cmd.ExecuteNonQuery();
	}

	public static IDataReader ExecuteReaderUnsafe(string sql)
	{
		var conn = new SqlConnection(ConnectionString);
		var cmd = new SqlCommand(sql, conn);
		conn.Open();
		return cmd.ExecuteReader();
	}
}