using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.Model;
using DLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class DepartmentController : MainApiController
    {
        private static IDepartmentReponsitory _departmentReponsitory;

        public DepartmentController(IDepartmentReponsitory departmentReponsitory)
        {
            _departmentReponsitory = departmentReponsitory;
        }
        
        [HttpGet] 
        public async Task<IActionResult> GetAll()
        { 
            return Ok( await _departmentReponsitory.GetALLAsync());
        }
        [HttpGet(template: "{code}")] 
        public async Task<IActionResult> GetA(string code) 
        { 
            return Ok(await  _departmentReponsitory.GetAAsync(code));
        }
        
        [HttpPost] 
        public async Task<IActionResult> Insert(Department department) 
        { 
            return Ok(await _departmentReponsitory.InsertAsync(department));
        }
        
        [HttpPut(template: "{code}")] 
        public async Task<IActionResult> Update(string code, Department department) 
        { 
            return Ok(await _departmentReponsitory.UpdateAsync(code,department));
        }
        
        [HttpDelete(template: "{code}")] 
        public async Task<IActionResult> Delete(string code) 
        { 
            return Ok(await _departmentReponsitory.DeleteAsync(code));
            
        }
    }

        
}
    
