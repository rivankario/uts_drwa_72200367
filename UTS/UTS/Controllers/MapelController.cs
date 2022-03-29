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
    public class MapelController : ControllerBase
    {
        private MapelContext _context;

        public MapelController(MapelContext context)
        {
            this._context = context;
        }

        // GET: api/kelas
        [HttpGet]
        public ActionResult<IEnumerable<MapelItem>> GetSiswaItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetAllMapel();
        }

        //Get : api/kelas/{id}
        [HttpGet("{id}", Name = "GetMapel")]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetMapel(id);
        }
        [HttpPost]
        public ActionResult<MapelItem> AddKelas([FromForm] string nama_mapel, [FromForm] string deskripsi)
        {
            MapelItem ki = new MapelItem();
            ki.nama_mapel = nama_mapel;
            ki.deskripsi = deskripsi;
       

            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.AddMapel(ki);
        }
    }
}
