﻿using Microsoft.AspNetCore.Mvc;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using SistemaInventario.Modelos.ViewModels;
using SistemaInventario.Utilidades;

namespace SistemaInventario.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductoController : Controller
    {
        
        private readonly IUnidadTrabajo _unidadTrabajo;

        public ProductoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;   
        }
        public IActionResult Index()
        {
            return View();
        }
        //metodo Upsert GET
        public async Task<IActionResult> Upsert(int? id)
        {
            ProductoVM productoVM = new ProductoVM()
            {
                Producto = new Producto(),
                CategoriaLista= _unidadTrabajo.Producto.ObtenerTodosDropDownList("Categoria"),
                MarcaLista = _unidadTrabajo.Producto.ObtenerTodosDropDownList("Marca")
            };

            if(id == null) 
            {
                //Crear Producto nuevo
                return View(productoVM);
            }
            else
            {
                productoVM.Producto = await _unidadTrabajo.Producto
                    .Obtener(id.GetValueOrDefault());
                if(productoVM.Producto == null)
                {
                    return NotFound();
                }
                return View(productoVM);
            }
        }






        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos= await _unidadTrabajo.Producto.ObtenerTodos(incluirPropiedades: "Categoria,Marca");
            return Json(new { data = todos});

        }

        
        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string serie,int id=0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Producto.ObtenerTodos();
            if(id==0)
            {
                valor = lista.Any(b => b.NumeroSerie.ToLower().Trim() == serie.ToLower().Trim());
            }
            else
            {
				valor = lista.Any(b => b.NumeroSerie.ToLower().Trim()
                == serie.ToLower().Trim() && b.Id!=id);
			}
            if(valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });

        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var productoDB = await _unidadTrabajo.Producto.Obtener(id);
            if (productoDB == null)
            {
                return Json(new { success = false, message = " Error al borrar el registro en la base de datos " });
            }
            _unidadTrabajo.Producto.Remover(productoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = " Producto eliminado con exito " });
        }
        #endregion

    }
}
