using ReviewMe.Models.Employees;

namespace ReviewMe.Frontend.Services.Data
{
    public interface IEmployeesService
    {
        Task<List<Employee>> Get();
        Task<Employee> Get(int assessmentId);
    }
}