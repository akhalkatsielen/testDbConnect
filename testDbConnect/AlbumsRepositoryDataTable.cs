using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDbConnect;

public static class AlbumsRepositoryDataTable
{
    private static string connectionString =
            "Server=DESKTOP-TC01TCH\\SQLEXPRESS;Database=test;" +
            "Trusted_Connection=True;TrustServerCertificate=True";
    private static SqlConnection connection = new SqlConnection(connectionString);
    public static Album GetAlbumById(int id)
    {
        connection.Open();

        string getByIdScript = $"SELECT * FROM AlbumsTest";

        DataTable albums = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(getByIdScript, connection);
        adapter.Fill(albums);

        //var album = from row in albums.AsEnumerable()
        //            where row.Field<int>("Id") == id
        //            select row;

        //var albumsEnumerable = from row in albums.AsEnumerable()
        //            where row.Field<int>("Id") == id
        //            select new Album()
        //            {
        //                Id = row.Field<int>("Id"),
        //                Name = row.Field<string>("Name"),
        //                ReleaseYear = row.Field<int>("ReleaseYear"),
        //                Description = row.Field<string>("Description"),
        //                Author = row.Field<string>("Author"),
        //                IncludedSongs = row.Field<int>("IncludedSongs")
        //            };

        var album = albums.AsEnumerable()
            .Where(album => album.Field<int>("Id") == id)
            .Select(album => new Album(album)).FirstOrDefault();

        connection.Close();
        return album;
    }
    public static List<Album> GetAllAlbum()
    {
        connection.Open();

        string getAllScript = $"SELECT * FROM AlbumsTest";

        DataTable albumsDataTable = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(getAllScript, connection);
        adapter.Fill(albumsDataTable);

        var albums = albumsDataTable.AsEnumerable()
            .Select(album => new Album(album)).ToList();

        connection.Close();
        return albums;
    }
    public static void AddAlbum(string name, int releaseYear, string? description, string author, int? includedSongs)
    {
        connection.Open();

        //string insertIntoScript = $"INSERT INTO AlbumsTest (Name, ReleaseYear, Description, Author, IncludedSongs)" +
        //    $"VALUES('{name}', {releaseYear}, '{description}', '{author}', {includedSongs})";

        //DataTable albumsDataTable = new DataTable();
        //SqlDataAdapter adapter = new SqlDataAdapter(insertIntoScript, connection);
        //adapter.Fill(albumsDataTable);

        connection.Close();
    }
    public static Album UpdateAlbumById(int id, string fieldName, string value)
    {
        connection.Open();

        //string updateIntoScript = $"UPDATE AlbumsTest " +
        //    $"SET {fieldName} = '{value}' " +
        //    $"WHERE ID = {id}";
        //SqlCommand cmd = new SqlCommand(updateIntoScript, connection);
        //cmd.ExecuteNonQuery();

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
