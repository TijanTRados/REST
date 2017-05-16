using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using RESTServer.Models;
using System.Collections;
using System.Globalization;

namespace RESTServer
{
    public class PhotosPersistence
    {
        private NpgsqlConnection conn;

        public PhotosPersistence()
        {
            string myConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=postgres";

            try
            {
                conn = new NpgsqlConnection(myConnectionString);
                conn.Open();

            }
            catch (Exception)
            {
            }
        }

        public List<Photos> GetPhotos()
        {
            String command = "SELECT * FROM photos";
            List<Photos> photos = new List<Photos>();

            NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
            NpgsqlDataReader result = cmd.ExecuteReader();

            while (result.Read())
            {
                Photos photo = new Photos();
                photo.Id = result.GetInt32(0);
                photo.UserId = result.GetInt32(1);
                photo.Name = result.GetString(2);
                photo.Width = result.GetFloat(3);
                photo.Height = result.GetFloat(4);
                photo.Size = result.GetFloat(5);
                photo.Date = result.GetDateTime(6);
                photos.Add(photo);
            }

            conn.Close();
            return photos;

        }

        public Photos GetPhoto(int id)
        {
            String command = "SELECT * FROM photos WHERE id=" + id;
            Photos photo = new Photos();

            NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
            NpgsqlDataReader result = cmd.ExecuteReader();

            while (result.Read())
            {
                photo.Id = result.GetInt32(0);
                photo.UserId = result.GetInt32(1);
                photo.Name = result.GetString(2);
                photo.Width = result.GetFloat(3);
                photo.Height = result.GetFloat(4);
                photo.Size = result.GetFloat(5);
                photo.Date = result.GetDateTime(6);
            }

            conn.Close();
            return photo;

        }

        public bool DeletePhoto(int id)
        {
            String command = "SELECT * FROM photos WHERE id=" + id;
            Photos photo = new Photos();

            NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.Read())
            {
                result.Close();
                command = "DELETE FROM photos WHERE id=" + id;

                cmd = new NpgsqlCommand(command, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }

        }

        public bool UpdatePhoto(int id, Photos photo)
        {
            String command = "SELECT * FROM photos WHERE id=" + id;

            NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.Read())
            {
                result.Close();
                command = "UPDATE photos SET userid = " + photo.UserId.ToString() + ", name = '" + photo.Name + "', width = " + photo.Width.ToString(new CultureInfo("en-US")) + ", height =  " + photo.Height.ToString(new CultureInfo("en-US")) + ", size =  " + photo.Size.ToString(new CultureInfo("en-US")) + ", date =  '" + photo.Date.ToString("yyyy-MM-dd HH:mm:ss")+"' WHERE id ="+id;

                cmd = new NpgsqlCommand(command, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }



        }

        public int SavePhoto(Photos photo)
        {
            String command = "INSERT INTO photos (userid, name, width, height, size, date) VALUES (" + photo.UserId.ToString() + ", '" + photo.Name + "', " + photo.Width.ToString(new CultureInfo("en-US")) + ", " + photo.Height.ToString(new CultureInfo("en-US")) + ", " + photo.Size.ToString(new CultureInfo("en-US")) + ", '" + photo.Date.ToString("yyyy-MM-dd HH:mm:ss") + "'); SELECT CURRVAL(pg_get_serial_sequence('photos', 'id'))";

            int id = 0;

            NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
            NpgsqlDataReader result = cmd.ExecuteReader();

            while (result.Read())
            {
                //id = Int32.Parse(result[0].ToString());
                id = result.GetInt32(0);
            }

            conn.Close();
            return id;

        }

    }
}