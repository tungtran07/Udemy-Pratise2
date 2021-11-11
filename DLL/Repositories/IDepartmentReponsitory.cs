using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.DBContext;
using DLL.Model;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories
{
    public interface IDepartmentReponsitory
    {
        Task<Department> InsertAsync(Department department);
        Task<List<Department>> GetALLAsync();
        Task<Department> UpdateAsync(string code, Department department);
        Task<Department> DeleteAsync(string code);
        Task<Department> GetAAsync(string code);
    }

    public class DepartmentReponsitory : IDepartmentReponsitory
    {
        private readonly ApplicationDBContext _context;

        public DepartmentReponsitory(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Department> InsertAsync(Department department)
        {
            await _context.Departments.AddAsync(department).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return department;
        }

        public async Task<List<Department>> GetALLAsync()
        {
            return await _context.Departments.ToListAsync();
        }
        
        public async Task<Department> DeleteAsync(string code)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }
        
        public async Task<Department> GetAAsync(string code)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);
            return department;
        }
        
        public async Task<Department> UpdateAsync(string code, Department department)
        {
            var finDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);
            finDepartment.Name = department.Name;
            _context.Departments.Update(finDepartment);
            await _context.SaveChangesAsync();
            return department;
        }
    }
}