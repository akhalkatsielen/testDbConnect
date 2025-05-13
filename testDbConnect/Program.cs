using Microsoft.Data.SqlClient;

namespace testDbConnect;

class Program
{
    static void Main()
    {

        while (true) 
        {
            Console.WriteLine("1. Get All Albums\n2. Add Album\n3. Update Album \n4. Delete Album");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var albums = AlbumsRepository.GetAllAlbum();
                    foreach (var album in albums)
                    {
                        Console.WriteLine($"{album.Name} - {album.ReleaseYear} - " +
                            $"{album.Description} - {album.Author} - " +
                            $"{album.IncludedSongs}");
                    }
                    Console.WriteLine();
                    break;
                case "2":
                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();

                    Console.WriteLine("ReleaseYear: ");
                    var releaseYear = int.Parse(Console.ReadLine());

                    Console.WriteLine("Description: ");
                    var description = Console.ReadLine();

                    Console.WriteLine("Author: ");
                    var author = Console.ReadLine();

                    Console.WriteLine("IncludedSongs: ");
                    var includedSongs = int.Parse(Console.ReadLine());

                    AlbumsRepository.AddAlbum(name, releaseYear, description, author, includedSongs);
                    break;
                case "3":
                    Console.WriteLine("ID: ");
                    var id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Field Name: ");
                    var fieldName = Console.ReadLine();

                    Console.WriteLine("Value: ");
                    var valueString = Console.ReadLine();

                    var isValueInt = int.TryParse(valueString, out int valueInt);

                    if (isValueInt) AlbumsRepository.UpdateAlbumById(id, fieldName, valueInt);
                    else AlbumsRepository.UpdateAlbumById(id, fieldName, valueString);
                    break;
                case "4":
                    break;
                default:
                    break;
            }
        }


        //string connectionString =
        //    "Server=DESKTOP-TC01TCH\\SQLEXPRESS;Database=test;" +
        //    "Trusted_Connection=True;TrustServerCertificate=True";

        //Console.Write("Input your name: ");
        //string inputName = Console.ReadLine();

        //string insertScript = "INSERT INTO Users (Name) " +
        //                        "VALUES ('" + inputName + "')";

        ////int id = 3;

        ////string getById = "Select Name, ReleaseYear from Albums" +
        ////                        "where id = " + id;

        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    // insert
        //    connection.Open();
        //    Console.WriteLine("Connected to server");

        //    SqlCommand command = new SqlCommand(insertScript, connection);
        //    int affectedRows = command.ExecuteNonQuery();

        //    Console.WriteLine(affectedRows + " rows updated");

        //    // select 
        //    string selectScript = "Select Id, Name from users";
        //    SqlCommand selectCommand = new SqlCommand(selectScript, connection);

        //    SqlDataReader sqlDataReader = selectCommand.ExecuteReader();
        //    while (sqlDataReader.Read())
        //    {
        //        int id = sqlDataReader.GetInt32(0);
        //        string name = sqlDataReader.GetString(1);
        //        Console.WriteLine($"ID: {id}, Name: {name}");
        //    }
        //}

        //int id = 37;
        //string name = "album37";
        //int year = 2025;

        //Album album = new Album();  
        //album.Id = id;
        //album.Name = name;
        //album.ReleaseYear = year;
    }
}