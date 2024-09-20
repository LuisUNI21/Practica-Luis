using Microsoft.AspNetCore.Mvc;
using PRACTICA.Services.Interface;
using PRACTICA.Models;

namespace PRACTICA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _IEstudianteService;
        public EstudianteController(IEstudianteService estudianteService)
        {
            _IEstudianteService = estudianteService;
        }

        // Get
        [HttpGet]
        public ActionResult<List<Estudiante>> GetAll()
        {
            return _IEstudianteService.GetAll();
        }

        // Get
        [HttpGet("{id}")]
        public ActionResult<Estudiante> GetById(int id)
        {
            var estudiante = _IEstudianteService.GetById(id);
            if (estudiante == null)
            {
                return NotFound("No se ha encontrado el id");
            }
            return estudiante;
        }
        // Post
        [HttpPost]
        public ActionResult Add(Estudiante estudiante)
        {
            try
            {
                _IEstudianteService.Add(estudiante);
                return Ok("Agregado");
            }
            catch (Exception)
            {
                return Conflict("El id proporcionado ya le pertenece a un estudiante"); 
            }
        }
        // Put
        [HttpPut]
        public ActionResult Update(Estudiante estudiante)
        {
            try
            {
                _IEstudianteService.Update(estudiante);
                return Ok("Actualizado");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Estudiante no encontrado "); // Si no se encuentra el estudiante, retorna 404
            }

        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var estudiante = _IEstudianteService.GetById(id);
            if (estudiante != null)
            {
                _IEstudianteService.Delete(id);
                return Ok("Eliminado");
            }
            return NotFound("El estudiante no esta en la lista"); // Si no se encuentra el estudiante, retorna 404
        }

    }

}

