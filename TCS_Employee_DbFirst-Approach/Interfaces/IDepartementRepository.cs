using TCS_Employee_DbFirst_Approach.DbConnect;

namespace TCS_Employee_DbFirst_Approach.Interfaces
{
    public interface IDepartementRepository
    {
        Task<List<Departement>> GetDepartments();
        Task<Departement> GetDepartmentById(int deptid);
        Task<int> AddDepartments(Departement deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(Departement deptdetail);
    }
}
