using Microsoft.AspNetCore.Mvc;
using ArticulosAPI.Modelos;

namespace ArticulosAPI.Repositorios

{
    public interface IArticulosRepositorio
    {
        Task<IEnumerable<ArticulosDto>> GetArticulos();
        Task<ActionResult<ArticulosDto>> GetArticulo(int id);
        Task<ActionResult<ArticulosDto>> PutArticulo(int id, Articulo articulo);
        Task<ArticulosDto> PostArticulo(Articulo articulo);
        Task DeleteArticulo(int id);
        public bool ArticuloExists(int id);
    }
}

