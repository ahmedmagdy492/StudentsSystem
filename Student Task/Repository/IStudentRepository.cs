using Student_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Student_Task.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> CreateStudent(Student student);
        Task<bool> DeleteStudent(Student student);
        Task<bool> UpdateStudent(Student student, Student oldstudent);
    }
}