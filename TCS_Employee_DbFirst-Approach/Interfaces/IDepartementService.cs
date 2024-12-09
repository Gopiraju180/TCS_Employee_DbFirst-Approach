using TCS_Employee_DbFirst_Approach.Dtos;

namespace TCS_Employee_DbFirst_Approach.Interfaces
{
    public interface IDepartementService
    {
        Task<List<DepartementDto>> GetDepartments();
        Task<DepartementDto> GetDepartmentById(int deptid);
        Task<int> AddDepartments(DepartementDto deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(DepartementDto deptdetail);
    }
}
