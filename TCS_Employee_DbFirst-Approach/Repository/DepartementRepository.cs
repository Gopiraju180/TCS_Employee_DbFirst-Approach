using Microsoft.EntityFrameworkCore;
using TCS_Employee_DbFirst_Approach.DbConnect;
using TCS_Employee_DbFirst_Approach.Interfaces;
namespace TCS_Employee_DbFirst_Approach.Repository
{
    public class DepartementRepository : IDepartementRepository
    {
        private readonly TcsEmployeeEntityCodeFirstApproachContext _tcsDbContext;
        public DepartementRepository(TcsEmployeeEntityCodeFirstApproachContext tcsDbContext)
        {
            _tcsDbContext = tcsDbContext;
        }
        public async Task<int> AddDepartments(Departement deptdetail)
        {
            await _tcsDbContext.Departements.AddAsync(deptdetail);//add the record by using addasync
            _tcsDbContext.SaveChanges();//it will commit/save the data perminently in table
            return 1;
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            Departement rm = _tcsDbContext.Departements.SingleOrDefault(e => e.Deptid == deptid);
            if (rm != null)
            {//Here Remove() method is used for removing the data from database.

                _tcsDbContext.Departements.Remove(rm);
                _tcsDbContext.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<Departement> GetDepartmentById(int deptid)
        {
            var rm = await _tcsDbContext.Departements.Where(e => e.Deptid == deptid).FirstOrDefaultAsync();

            if (rm == null)
                return null;
            else
                return rm;
        }

        public async Task<List<Departement>> GetDepartments()
        {
            var result = _tcsDbContext.Departements.ToList();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<bool> UpdateDepartment(Departement deptdetail)
        {
            _tcsDbContext.Update(deptdetail);
            await _tcsDbContext.SaveChangesAsync();
            return true;

        }
    }
}
