using Student_Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;

namespace Student_Task.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolModel _context;

        public StudentRepository(SchoolModel context)
        {
            _context = context;
        }

        private async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            var createdStudent = _context.Students.Add(student);
            await Save();
            return createdStudent;
        }

        public async Task<bool> DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            bool result = await Save();
            _context.Entry(student).State = EntityState.Deleted;
            return result;
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<bool> UpdateStudent(Student student, Student oldStudent)
        {
            oldStudent.Name = student.Name;
            oldStudent.NeighborhoodId = student.NeighborhoodId;
            oldStudent.GovernorateId = student.GovernorateId;
            oldStudent.FieldId = student.FieldId;
            var result = await Save();
            _context.Entry(student).State = EntityState.Modified;
            return result;
        }
    }
}