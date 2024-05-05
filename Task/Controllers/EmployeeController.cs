using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Task.IRepos;
using Task.Models;

namespace Task.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepoEmployee repoEmployee;
        private readonly IRepouser repouser ;
        private readonly IRepoDepartment repoDepartment ;



        public EmployeeController( IRepoEmployee _repoEmployee, IRepouser repouser,IRepoDepartment repoDepartment)
        {
            repoEmployee = _repoEmployee;
            this.repouser = repouser;
            this.repoDepartment = repoDepartment;

        }
        public IActionResult Index()
        {
           var employees=repoEmployee.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            var departments=repoDepartment.GetAll();
            var users = repouser.GetAll();
            ViewBag.Users = users;
            ViewBag.Departments = departments;

            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            
            ModelState.Remove("ModifaiedByNavigation");
            ModelState.Remove("CreatedByNavigation");

            if (ModelState.IsValid)
            {
              
                repoEmployee.Add(employee);

             
                return RedirectToAction("Index");
            }
            var departments = repoDepartment.GetAll();
            var users = repouser.GetAll();
            ViewBag.Users = users;
            ViewBag.Departments = departments;

            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            repoEmployee.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
           
            var emp = repoEmployee.GetById(id);

            var departments = repoDepartment.GetAll();
            var users = repouser.GetAll();
            ViewBag.Users = users;
            ViewBag.Departments = departments;
            return View(emp);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
           repoEmployee.Update(employee);
            return RedirectToAction("Index");
        }
    }
    }

