using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDbConnect;

public class Album
{
    public Album()
    {
        
    }
    public Album(SqlDataReader sqlDataReader)
    {
        Id = sqlDataReader.GetInt32(0);
        Name = sqlDataReader.GetString(1);
        ReleaseYear = sqlDataReader.GetInt32(2);
        Description = !sqlDataReader.IsDBNull(3) ?
            sqlDataReader.GetString(3) : null;
        Author = sqlDataReader.GetString(4);
        IncludedSongs = !sqlDataReader.IsDBNull(5) ?
            sqlDataReader.GetInt32(5) : null;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int ReleaseYear { get; set; }
    public string? Description { get; set; }
    public string Author { get; set; }
    public int? IncludedSongs { get; set; }
}
