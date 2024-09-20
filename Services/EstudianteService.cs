using PRACTICA.Services.Interface;
using PRACTICA.Models;

namespace PRACTICA.Services.Implementation
{
    public class EstudianteService : IEstudianteService
    {
        private List<Estudiante> _estudiante;
        public EstudianteService()
        {
            _estudiante = new List<Estudiante>{
                new Estudiante{Id = 1, Nombre = "Test", State = true, DNI = "1234"},
                new Estudiante{Id = 2, Nombre = "Test", State = true, DNI = "1234"},
                new Estudiante{Id = 3, Nombre = "Test", State = true, DNI = "1234"},
                new Estudiante{Id = 4, Nombre = "Test", State = true, DNI = "1234"}
            };
        }

        public void Add(Estudiante estudiante)
        {
            var existingStudent = _estudiante.FirstOrDefault(e => e.Id == estudiante.Id);
            if (existingStudent == null)
            {
             _estudiante.Add(estudiante);
            }
             else
            {
                throw new Exception();
            }

        }

        public void Delete(int id)
        {
            var estuDelete = _estudiante.FirstOrDefault(e => e.Id == id);
            if (estuDelete != null)
            {
                _estudiante.Remove(estuDelete);
            }
        }

        public List<Estudiante> GetAll()
        {
            return _estudiante;
        }

        public Estudiante GetById(int id)
        {
            return _estudiante.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Estudiante estudiante)
        {
            var existingStudent = _estudiante.FirstOrDefault(e => e.Id == estudiante.Id);
            if (existingStudent != null)
            {
                existingStudent.Nombre = estudiante.Nombre;
                existingStudent.State = estudiante.State;
                existingStudent.DNI = estudiante.DNI;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}