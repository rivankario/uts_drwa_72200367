﻿namespace UTS.Models
{
    public class JadwalItem
    {

        public int id_jadwal_guru { get; set; }
        public string tahun_akademik { get; set; }
        public string semester { get; set; }
        public int id_guru { get; set; }
        public string hari { get; set; }
        public int id_kelas { get; set; }
        public int id_mapel { get; set; }
        public string jam_mulai { get; set; }
        public string jam_selesai { get; set; }
        public string nip { get; internal set; }
    }
}
