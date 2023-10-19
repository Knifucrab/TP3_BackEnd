using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticulosAPI.Data;
using ArticulosAPI.Modelos;
using ArticulosAPI.Repositorios;

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticulosRepositorio _repositorio;

        public ArticulosController(IArticulosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<IEnumerable<ArticulosDto>> GetArticulos()
        {
            return await _repositorio.GetArticulos();
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticulosDto>> GetArticulo(int id)
        {
            var articulo = await _repositorio.GetArticulo(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/Articulos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Articulo>> PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return BadRequest();
            }
            await _repositorio.PutArticulo(id, articulo);

            return CreatedAtAction("PUTArticulo", new { id = articulo.Id }, articulo); ;
        }

        // POST: api/Articulos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
            await _repositorio.PostArticulo(articulo);

            return CreatedAtAction("POSTArticulo", new { id = articulo.Id }, articulo);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticulo(int id)
        {
            await _repositorio.DeleteArticulo(id);
            return CreatedAtAction("DELETEArticulo", new { id = id });
        }

        public bool ArticuloExists(int id)
        {
            return _repositorio.ArticuloExists(id);
        }
    }
}
