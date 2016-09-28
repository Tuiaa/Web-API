using Students.DataModel.Models;
using Students.DataModel.UnitOfWork;
using System.Linq;
using System;

namespace Students.Services
{
    public class StudentService : IStudentService
    {
        private readonly UnitOfWork _sUnitofWork;

        public StudentService()
        {
            _sUnitofWork = new UnitOfWork();
        }

        public Student Get(int i)
        {
            return _sUnitofWork.Students.Get(i);
        }

        public IQueryable<Student> GetAll()
        {
            return _sUnitofWork.Students.GetAll();
        }

        public void Delete(int id)
        {
            _sUnitofWork.Students.Delete(s => s.StudentID, id);
        }

        public void Insert(Student student)
        {
            _sUnitofWork.Students.Add(student);
        }

        public void Update(Student student)
        {
            _sUnitofWork.Students.Update(s=>s.StudentID, student.StudentID, student);
        }
    }
}
