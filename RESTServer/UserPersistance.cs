using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using RESTServer.Models;
using System.Collections;

namespace RESTServer
{
    public class UserPersistence
    {
        private NpgsqlConnection conn;

        public UserPersistence()
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

        public List<User> GetUsers()
        {
            String command = "SELECT * FROM users";
            List<User> users = new List<User>();

            NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
            NpgsqlDataReader result = cmd.ExecuteReader();

            while (result.Read())
            {
                User user = new User();
                user.Id = result.GetInt32(0);
                user.Username = result.GetString(1);
                user.Password = result.GetString(2);
                user.Name = result.GetString(3);
                user.LastName = result.GetString(4);
                user.BirthDay = result.GetDateTime(5);
                user.Proffesion = result.GetString(6);
                users.Add(user);
            }

            conn.Close();
            return users;

        }

        public User GetUser (int id)
        {
            String command = "SELECT * FROM users WHERE id="+id;
            User user = new User();

            NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
            NpgsqlDataReader result = cmd.ExecuteReader();

            while (result.Read())
            {
                user.Id = result.GetInt32(0);
                user.Username = result.GetString(1);
                user.Password = result.GetString(2);
                user.Name = result.GetString(3);
                user.LastName = result.GetString(4);
                user.BirthDay = result.GetDateTime(5);
                user.Proffesion = result.GetString(6);
            }

            conn.Close();
            return user;

        }

        public bool DeleteUser(int id)
        {
            String command = "SELECT * FROM users WHERE id=" + id;
            User user = new User();

            NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.Read())
            {
                result.Close();
                command = "DELETE FROM users WHERE id=" + id;

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

        public bool UpdateUser(int id, User user)
        {
            String command = "SELECT * FROM users WHERE id=" + id;

            NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.Read())
            {
                result.Close();
                command = "UPDATE Users SET username = '" + user.Username + "', password = '" + user.Password + "', name = '" + user.Name + "', lastname =  '" + user.LastName + "', birthday =  '" + user.BirthDay.ToString("yyyy-MM-dd HH:mm:ss") + "', proffesion =  '" + user.Proffesion+"' WHERE id ="+id;

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

        public int SaveUser(User user)
        {
            String command = "INSERT INTO users (username, password, name, lastname, birthday, proffesion) VALUES ('" + user.Username + "', '" + user.Password + "', '" + user.Name + "', '" + user.LastName + "', '" + user.BirthDay.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + user.Proffesion + "'); SELECT CURRVAL(pg_get_serial_sequence('users', 'id'))";

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

        public List<Photos> GetUserPhotos(int id)
        {
            String command = "SELECT * FROM photos WHERE userid ="+id;
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

    }
}