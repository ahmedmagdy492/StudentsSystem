using Student_Task.Models;
using Student_Task.Repository;
using Student_Task.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Student_Task.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly IGovernorateRepository _governorateRepository;
        private readonly IFieldRepository _fieldRepository;

        public StudentController(
            IStudentRepository studentRepository,
            INeighborhoodRepository neighborhoodRepository,
            IGovernorateRepository governorateRepository,
            IFieldRepository fieldRepository
            )
        {
            _studentRepository = studentRepository;
            _neighborhoodRepository = neighborhoodRepository;
            _governorateRepository = governorateRepository;
            _fieldRepository = fieldRepository;
        }

        // GET: Student
        public async Task<ActionResult> Index(int? i)
        {
            var allStudents = (await _studentRepository.GetStudents()).ToPagedList(i ?? 1, 10);
            return View(allStudents);
        }

        // GET: Create
        public async Task<ActionResult> Create()
        {
            var govs = await _governorateRepository.GetGovernorates();
            var model = new StudentViewModel
            {
                Fields = new SelectList(await _fieldRepository.GetFields(), "ID", "Name"),
                Governorates = new SelectList(govs, "ID", "Name"),
                Neighborhoods = new SelectList(await _neighborhoodRepository.GetNeighborhoodsOfGovernrate(govs.FirstOrDefault().ID), "ID", "Name"),
                Student = new Student()
            };
            return View(model);
        }

        // POST: Create
        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _studentRepository.CreateStudent(student);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "An Error has occured: " + ex.Message);
                }
            }
            var govs = await _governorateRepository.GetGovernorates();
            var model = new StudentViewModel
            {
                Fields = new SelectList(await _fieldRepository.GetFields(), "ID", "Name"),
                Governorates = new SelectList(govs, "ID", "Name"),
                Neighborhoods = new SelectList(await _neighborhoodRepository.GetNeighborhoodsOfGovernrate(govs.FirstOrDefault().ID), "ID", "Name"),
                Student = student
            };
            return View(model);
        }

        // POST: Delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetStudent(id);

            if (student == null) return HttpNotFound("Request Student is not found");

            try
            {
                var result = await _studentRepository.DeleteStudent(student);
                if (result) return new HttpStatusCodeResult(HttpStatusCode.OK, "Deleted Successfully");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Something went Wrong");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "An Error has occured: " + ex.Message);
            }
        }

        // GET: Edit
        public async Task<ActionResult> Edit(int id)
        {
            var student = await _studentRepository.GetStudent(id);

            if (student == null) return HttpNotFound("Requested Student is not found");

            var govs = await _governorateRepository.GetGovernorates();
            var model = new StudentViewModel
            {
                Student = student,
                Fields = new SelectList(await _fieldRepository.GetFields(), "ID", "Name", student.FieldId),
                Governorates = new SelectList(govs, "ID", "Name", student.GovernorateId),
                Neighborhoods = new SelectList(await _neighborhoodRepository.GetNeighborhoodsOfGovernrate(govs.FirstOrDefault().ID), "ID", "Name", student.NeighborhoodId)
            };
            return View(model);
        }

        // POST: Edit
        [HttpPost]
        public async Task<ActionResult> Edit(Student student, int id)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var oldStudent = await _studentRepository.GetStudent(id);

                    if (oldStudent == null) return HttpNotFound("Student with this id " + id +" is not found");
                    var result = await _studentRepository.UpdateStudent(student, oldStudent);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "An Error has occured: " + ex.Message);
                }
            }
            var govs = await _governorateRepository.GetGovernorates();
            var model = new StudentViewModel
            {
                Student = student,
                Fields = new SelectList(await _fieldRepository.GetFields(), "ID", "Name", student.FieldId),
                Governorates = new SelectList(govs, "ID", "Name", student.GovernorateId),
                Neighborhoods = new SelectList(await _neighborhoodRepository.GetNeighborhoodsOfGovernrate(govs.FirstOrDefault().ID), "ID", "Name", student.NeighborhoodId)
            };
            return View(model);
        }
    }
}