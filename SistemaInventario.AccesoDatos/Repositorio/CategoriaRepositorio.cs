﻿using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.AcessoDatos.Data;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void actualizar(Categoria categoria)
        {
            var categoriaBD = _db.Categorias.FirstOrDefault(b => b.id == categoria.id);
        if(categoriaBD != null)
            {

                categoriaBD.Nombre = categoria.Nombre;
                categoriaBD.Descripcion = categoria.Descripcion;
                categoriaBD.Estado= categoria.Estado;
                _db.SaveChanges();
            }
        }
    }
}
