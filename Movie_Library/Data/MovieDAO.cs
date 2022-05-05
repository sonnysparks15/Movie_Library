// MSSQL DataBase Query Commands

using Movie_Library.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace Movie_Library.Data;
/* //////////////////////////////////////////////////////////////////////// */

internal class MovieDAO
{
    private string connectionString = @"Server=localhost; Database=MovieDataBase; User=sa; Password=#SonnySparks3;
                                        TrustServerCertificate=True; Encrypt=False; ApplicationIntent=ReadWrite";

    
/* ////////////////////////////////////////////////////////////////////// */
    // Preforms All Data retrieving functions 
       public List<MovieMod> FetchAll()
       {
           List<MovieMod> returnList = new List<MovieMod>();
           
           // Access Database
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               string sqlQuery = "SELECT * from MovieDataBase.dbo.movies";

               SqlCommand command = new SqlCommand(sqlQuery, connection);

               connection.Open();
               SqlDataReader reader = command.ExecuteReader();

               if (reader.HasRows)
               {
                   while (reader.Read())
                   {
                       // Create New Movie
                       MovieMod movieMod = new MovieMod();
                       movieMod.FilmTitle = reader.GetString(0);
                       movieMod.Genre = reader.GetString(1);
                       movieMod.Studio = reader.GetString(2);
                       movieMod.AudienceScore = reader.GetByte(3);
                       movieMod.Year = reader.GetInt16(7);
                       
                       returnList.Add(movieMod);
                   }
               }
           }

           return returnList;
       }
/* //////////////////////////////////////////////////////////////////////// */
/*
    public int MovieDAO Create(MovieMod movie)
    {
        List<MovieMod> returnList = new List<MovieMod>();
           
        // Access Database
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sqlQuery = "INSERT INTO MovieDataBase.dbo.movies Values(@FilmTitle, @Genre, @Studio, " +
                              "@AudienceScore, @Year)";

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            command.Parameters.Add("@FilmTitle", System.Data.SqlDbType.VarChar, 1000).Value = movie.FilmTitle;
            command.Parameters.Add("@Genre", System.Data.SqlDbType.VarChar, 1000).Value = movie.Genre;
            command.Parameters.Add("@Studio", System.Data.SqlDbType.VarChar, 1000).Value = movie.Studio;
            // ReSharper disable once HeapView.BoxingAllocation
            command.Parameters.Add("@AudienceScore", System.Data.SqlDbType.Int, 1000).Value = movie.AudienceScore;
            // ReSharper disable once HeapView.BoxingAllocation
            command.Parameters.Add("@Year", System.Data.SqlDbType.Int, 1000).Value = movie.Year;

            connection.Open();
            command.ExecuteNonQuery();

            return ;
        }
    }
    */
/* //////////////////////////////////////////////////////////////////////// */
    public MovieMod FetchDetails(string Film)
    {

        // Access Database
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // 
            string sqlQuery = "SELECT * from MovieDataBase.dbo.movies WHERE Film = @Film";
            

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@Film", System.Data.SqlDbType.VarChar).Value = Film;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            MovieMod movieMod = new MovieMod();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Create New Movie
                    movieMod.FilmTitle = reader.GetString(0);
                    movieMod.Genre = reader.GetString(1);
                    movieMod.Studio = reader.GetString(2);
                    movieMod.AudienceScore = reader.GetByte(3);
                    movieMod.Year = reader.GetInt16(7);
                       
                    
                }
            }
            return movieMod;
        }
        
    }
}
