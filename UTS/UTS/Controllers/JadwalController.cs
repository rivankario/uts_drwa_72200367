using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UTS.Models;

namespace UTS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JadwalController : ControllerBase
    {
        private JadwalContext _context;

        public JadwalController(JadwalContext context)
        {
            this._context = context;
        }

        // GET: api/kelas
        [HttpGet]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetAllJadwal();
        }

        //Get : api/kelas/{id}
        [HttpGet("id/{id}", Name = "GetJadwalID")]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetJadwal(id);
        }

        [HttpGet("nip/{nip}", Name = "GetJadwalNIP")]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItemNip(String nip)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetJadwalNip(nip);
        }

        [HttpPost]
        public ActionResult<JadwalItem> AddKelas([FromForm] string tahun_akademik, [FromForm] string semester, [FromForm] int id_guru, [FromForm] string hari, [FromForm] int id_kelas, [FromForm] int id_mapel, [FromForm] string jam_mulai, [FromForm] string jam_selesai)
        {
            JadwalItem ki = new JadwalItem();
            ki.tahun_akademik = tahun_akademik;
            ki.semester = semester;
            ki.id_guru = id_guru;
            ki.hari = hari;
            ki.id_kelas = id_kelas;
            ki.id_mapel = id_mapel;
            ki.jam_mulai = jam_mulai;
            ki.jam_selesai = jam_selesai;


            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.AddJadwal(ki);
        }
    }
}
