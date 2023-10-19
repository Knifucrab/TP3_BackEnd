using ArticulosAPI.Data;
using ArticulosAPI.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace ArticulosAPI.Repositorios
{
    public class ArticuloRepositorio : IArticulosRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ArticuloRepositorio(ApplicationDbContext context, IMapper mapper)

        {
            _context = context;
            _mapper = mapper;
        }
        public bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(articulo => articulo.Id == id);
        }

        public async Task DeleteArticulo(int id)
        {
            try
            {
                var articulo = await _context.Articulos.FindAsync(id);
                if (articulo != null)
                {
                    _context.Articulos.Remove(articulo);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<ArticulosDto>> GetArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            return _mapper.Map<Articulo, ArticulosDto>(articulo);
        }

        public async Task<IEnumerable<ArticulosDto>> GetArticulos()
        {
            List<Articulo> articulos = await _context.Articulos.ToListAsync();
            return _mapper.Map<List<Articulo>, List<ArticulosDto>>(articulos);
        }

        public async Task<ArticulosDto> PostArticulo(Articulo articulo)
        {
            await _context.Articulos.AddAsync(articulo);
            await _context.SaveChangesAsync();
            return _mapper.Map<Articulo, ArticulosDto>(articulo);
        }

        public async Task<ActionResult<ArticulosDto>> PutArticulo(int id, Articulo articulo)
        {
            var articuloAModificar = await _context.Articulos.FindAsync(id);
            if (articuloAModificar == null)
            {
                throw new Exception("Artículo no encontrado");
            }
            _mapper.Map(articulo, articuloAModificar);
            await _context.SaveChangesAsync();
            return _mapper.Map<Articulo, ArticulosDto>(articulo);
        }
    }
}
