using PRACTICA.Models;

namespace PRACTICA.Services.Interface
{
    public interface IEstudianteService
    {
        public List<Estudiante> GetAll();
        public Estudiante GetById(int id);
        public void Update(Estudiante estudiante);
        public void Add(Estudiante estudiante);
        public void Delete(int id);
    }
}