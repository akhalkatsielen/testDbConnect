using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDbConnect;

public static class AlbumsRepository
{
    private static string connectionString =
            "Server=DESKTOP-TC01TCH\\SQLEXPRESS;Database=test;" +
            "Trusted_Connection=True;TrustServerCertificate=True";
    private static SqlConnection connection = new SqlConnection(connectionString);
    public static Album GetAlbumById(int id)
    {
        connection.Open();

        string getByIdScript = $"SELECT * FROM AlbumsTest WHERE Id = {id}";
        SqlCommand cmd = new SqlCommand(getByIdScript, connection);
        SqlDataReader sqlDataReader = cmd.ExecuteReader();
        sqlDataReader.Read();

        var album = new Album(sqlDataReader);
        connection.Close();
        return album;
    }
    public static List<Album> GetAllAlbum()
    {
        connection.Open();

        string getAllScript = $"SELECT * FROM AlbumsTest";
        SqlCommand cmd = new SqlCommand(getAllScript, connection);
        SqlDataReader sqlDataReader = cmd.ExecuteReader();

        var albums = new List<Album>();

        while (sqlDataReader.Read()) 
        {
            var album = new Album(sqlDataReader);
            albums.Add(album);
        }

        connection.Close();
        return albums;
    }
    public static void AddAlbum(string name, int releaseYear, string? description, string author, int? includedSongs)
    {
        connection.Open();

        string insertIntoScript = $"INSERT INTO AlbumsTest (Name, ReleaseYear, Description, Author, IncludedSongs)" +
            $"VALUES('{name}', {releaseYear}, '{description}', '{author}', {includedSongs})";
        SqlCommand cmd = new SqlCommand(insertIntoScript, connection);
        cmd.ExecuteNonQuery();

        connection.Close();
    }
    public static Album UpdateAlbumById(int id, string fieldName, string value) 
    {
        connection.Open();

        string updateIntoScript = $"UPDATE AlbumsTest " +
            $"SET {fieldName} = '{value}' " +
            $"WHERE ID = {id}";
        SqlCommand cmd = new SqlCommand(updateIntoScript, connection);
        cmd.ExecuteNonQuery();

        var album = GetAlbumById(id);

        connection.Close();
        return album;
    }
    public static Album UpdateAlbumById(int id, string fieldName, int value)
    {
        connection.Open();

        string updateIntoScript = $"UPDATE AlbumsTest" +
            $"SET {fieldName} = {value}" +
            $"WHERE ID = {id}";
        SqlCommand cmd = new SqlCommand(updateIntoScript, connection);
        cmd.ExecuteNonQuery();

        var album = GetAlbumById(id);

        connection.Close();
        return album;
    }
    public static void DeleteAlbumById(int id)
    {
        connection.Open();

        string deleteByIdScript = $"DELETE FROM AlbumsTest WHERE ID = {id}";
        SqlCommand cmd = new SqlCommand(deleteByIdScript, connection);
        cmd.ExecuteNonQuery();

        connection.Close();
    }
}
