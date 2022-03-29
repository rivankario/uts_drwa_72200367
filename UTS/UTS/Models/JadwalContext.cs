using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UTS.Models
{
    public class JadwalContext : DbContext
    {
        public JadwalContext(DbContextOptions<JadwalContext> options) : base(options)
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

        public List<JadwalItem> GetAllJadwal()
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM jadwal_guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")

                        });
                    }
                }
            }
            return list;
        }

        public List<JadwalItem> GetJadwal(string id_mapel)
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM jadwal_guru WHERE id_mapel = @id_mapel", conn);
                cmd.Parameters.AddWithValue("@id_mapel", id_mapel);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")
                        });
                    }
                }
            }
            return list;
        }

        public List<JadwalItem> GetJadwalNip(string nip)
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT guru.nip, jadwal_guru.id_jadwal_guru, jadwal_guru.tahun_akademik, jadwal_guru.semester, jadwal_guru.id_guru, jadwal_guru.hari, jadwal_guru.id_kelas, jadwal_guru.id_mapel, jadwal_guru.jam_mulai, jadwal_guru.jam_selesai FROM jadwal_guru inner join guru ON jadwal_guru.id_guru=guru.id_guru WHERE guru.nip = @nip", conn);
                cmd.Parameters.AddWithValue("@nip", nip);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            nip = reader.GetString("nip"),
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")
                        }) ;
                    }
                }
            }
            return list;
        }
        public JadwalItem AddJadwal(JadwalItem KI)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO jadwal_guru (tahun_akademik, semester, id_guru, hari, id_kelas, id_mapel, jam_mulai, jam_selesai) VALUES (@tahun_akademik, @semester, @id_guru, @hari, @id_kelas, @id_kelas, @jam_mulai, @jam_selesai)", conn);
                cmd.Parameters.AddWithValue("@tahun_akademik", KI.tahun_akademik);
                cmd.Parameters.AddWithValue("@semester", KI.semester);
                cmd.Parameters.AddWithValue("@id_guru", KI.id_guru);
                cmd.Parameters.AddWithValue("@hari", KI.hari);
                cmd.Parameters.AddWithValue("@id_kelas", KI.id_kelas);
                cmd.Parameters.AddWithValue("@id_mapel", KI.id_mapel);
                cmd.Parameters.AddWithValue("@jam_mulai", KI.jam_mulai);
                cmd.Parameters.AddWithValue("@jam_selesai", KI.jam_selesai);

                cmd.ExecuteReader();
            }
            return KI;
        }
    }
}