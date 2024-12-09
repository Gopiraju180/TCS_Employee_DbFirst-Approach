using TCS_Employee_DbFirst_Approach.DbConnect;
using TCS_Employee_DbFirst_Approach.Dtos;
using TCS_Employee_DbFirst_Approach.Interfaces;
namespace TCS_Employee_DbFirst_Approach.Services
{
    public class DepartementService : IDepartementService
    {
        private readonly IDepartementRepository _departementRepository;
        public DepartementService(IDepartementRepository departementRepository)
        {
            _departementRepository = departementRepository; 
        }
        public async Task<int> AddDepartments(DepartementDto deptdetail)
        {

            //In future this code was replaced by automapper conncept.
            Departement dept = new Departement();
            dept.Deptid = deptdetail.deptid;
            dept.Deptname = deptdetail.deptname;
            dept.Deptlocation = deptdetail.deptlocation;
            var res = await _departementRepository.AddDepartments(dept);
            return res;
        }

        public async  Task<bool> DeleteDepartmentById(int deptid)
        {
            await _departementRepository.DeleteDepartmentById(deptid);
            return true;
        }

        public async  Task<DepartementDto> GetDepartmentById(int deptid)
        {
            var res = await _departementRepository.GetDepartmentById(deptid);
            DepartementDto deptdto = new DepartementDto();
            deptdto.deptid = res.Deptid;
            deptdto.deptname = res.Deptname;
            deptdto.deptlocation = res.Deptlocation;
            return deptdto;
        }

        public async Task<List<DepartementDto>> GetDepartments()
        {
            List<DepartementDto> lstdeptdto = new List<DepartementDto>();
            var res = await _departementRepository.GetDepartments();
            foreach (Departement dept in res)
            {
                DepartementDto deptDto = new DepartementDto();
                deptDto.deptid = dept.Deptid;
                deptDto.deptname = dept.Deptname;
                deptDto.deptlocation = dept.Deptlocation;
                lstdeptdto.Add(deptDto);

            }
            return lstdeptdto;
        }

        public async  Task<bool> UpdateDepartment(DepartementDto deptdetail)
        {
            Departement dept = new Departement();
            dept.Deptid = deptdetail.deptid;
            dept.Deptname = deptdetail.deptname;
            dept.Deptlocation = deptdetail.deptlocation;
            await _departementRepository.UpdateDepartment(dept);
            return true;
        }
    }
}
