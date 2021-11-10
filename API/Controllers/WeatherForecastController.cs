using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DepartmentStatic.GetAllDepartments());
        }

        [HttpGet(template: "{code}")]
        public IActionResult GetA(string code)
        {
            return Ok(DepartmentStatic.GetADepartment(code));
        }

        [HttpPost]
        public IActionResult Insert(Department department)
        {
            return Ok(DepartmentStatic.InsertDepartment(department));
        }

        [HttpPut(template: "{code}")]
        public IActionResult Update(string code, Department department)
        {
            return Ok(DepartmentStatic.UpdateDepartment(code, department));
        }

        [HttpDelete(template: "{code}")]
        public IActionResult Delete(string code)
        {
            return Ok(DepartmentStatic.DeleteDepartment(code));
        }
    }

    public static class DepartmentStatic
    {

        private static List<Department> AllDepartment { get; set; } = new List<Department>();

        public static Department InsertDepartment(Department department)
        {
            AllDepartment.Add(department);
            return department;
        }

        public static List<Department> GetAllDepartments()
        {
            return AllDepartment;
        }

        public static Department GetADepartment(string code)
        {
            return AllDepartment.FirstOrDefault(x => x.Code == code);
        }

        public static Department UpdateDepartment(string code, Department department)
        {
            Department result = new Department();
            foreach (var aDepartment in AllDepartment)
            {
                if (code == aDepartment.Code)
                {
                    aDepartment.Name = department.Name;
                    result = aDepartment;
                }
            }

            return result;
        }

        public static Department DeleteDepartment(string code)
        {
            var department = AllDepartment.FirstOrDefault(x => x.Code == code);
            AllDepartment = AllDepartment.Where(x => x.Code != department.Code).ToList();
            return department;
        }
    }
}