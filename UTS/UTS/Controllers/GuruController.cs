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
    public class GuruController : ControllerBase
    {
        private GuruContext _context;

        public GuruController(GuruContext context)
        {
            this._context = context;
        }

        // GET: api/kelas
        [HttpGet]
        public ActionResult<IEnumerable<GuruItem>> GetSiswaItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetAllGuru();
        }

        //Get : api/kelas/{id}
        [HttpGet("{id}", Name = "GetGuru")]
        public ActionResult<IEnumerable<GuruItem>> GetSiswaItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetGuru(id);
        }
        [HttpPost]
        public ActionResult<GuruItem> AddKelas([FromForm] string rfid, [FromForm] string nip, [FromForm] string nama_guru, [FromForm] string alamat, [FromForm] int status_guru)
        {
            GuruItem ki = new GuruItem();
            ki.rfid = rfid;
            ki.nip = nip;
            ki.nama_guru = nama_guru;
            ki.alamat = alamat;
            ki.status_guru = status_guru;


            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.AddGuru(ki);
        }
    }
}
