using Business.Services.Abstractions;
using Data.DataApp;
using Data.Entities;


namespace Business.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> DepartmentList = TestData.DepartmentList;

        private readonly AppDbContext _context;
        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public List<Department> GetDepartments()
        {
            return DepartmentList;
        }

        public List<Subdepartment> GetSubdepartments(string name)
        {
            var department = DepartmentList.FirstOrDefault(c => c.Name == name);

            if (department != null)
                return (List<Subdepartment>)department.Subdepartments;

            return new List<Subdepartment>();
        }
    }
}
