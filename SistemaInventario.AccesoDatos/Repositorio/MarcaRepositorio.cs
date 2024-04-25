using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.AcessoDatos.Data;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public MarcaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void actualizar(Marca marca)
        {
            var categoriaBD = _db.Marcas.FirstOrDefault(b => b.id == marca.id);
        if(categoriaBD != null)
            {

                categoriaBD.Nombre = marca.Nombre;
                categoriaBD.Descripcion = marca.Descripcion;
                categoriaBD.Estado= marca.Estado;
                _db.SaveChanges();
            }
        }
    }
}
