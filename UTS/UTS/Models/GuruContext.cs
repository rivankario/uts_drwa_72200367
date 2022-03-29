using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UTS.Models
{
    public class GuruContext : DbContext
    {
        public GuruContext(DbContextOptions<GuruContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        //public KelasContext(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //}

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = kelas; Uid = root; Pwd =");
        }

        public List<GuruItem> GetAllGuru()
        {
            List<GuruItem> list = new List<GuruItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GuruItem()
                        {
                            id_guru = reader.GetInt32("id_guru"),
                            rfid = reader.GetString("rfid"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            alamat = reader.GetString("alamat"),
                            status_guru = reader.GetInt32("status_guru")
                        });
                    }
                }
            }
            return list;
        }

        public List<GuruItem> GetGuru(string nip)
        {
            List<GuruItem> list = new List<GuruItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM guru WHERE nip = @nip", conn);
                cmd.Parameters.AddWithValue("@nip", nip);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GuruItem()
                        {
                            id_guru = reader.GetInt32("id_guru"),
                            rfid = reader.GetString("kelas"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            alamat = reader.GetString("alamat"),
                            status_guru = reader.GetInt32("status_guru")
                        });
                    }
                }
            }
            return list;
        }
        public GuruItem AddGuru(GuruItem KI)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO guru (rfid, nip, nama_guru, alamat, status_guru) VALUES (@rfid, @nip, @nama_guru, @alamat, @status_guru)", conn);
                cmd.Parameters.AddWithValue("@rfid", KI.rfid);
                cmd.Parameters.AddWithValue("@nip", KI.nip);
                cmd.Parameters.AddWithValue("@nama_guru", KI.nama_guru);
                cmd.Parameters.AddWithValue("@alamat", KI.nama_guru);
                cmd.Parameters.AddWithValue("@status_guru", KI.nama_guru);

                cmd.ExecuteReader();
            }
            return KI;
        }
    }
}