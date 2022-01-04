using DemoRepoPattern.Data;
using DemoRepoPattern.Entities;
using DemoRepoPattern.Interfaces;

namespace DemoRepoPattern.Implementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationBDContext bdContext) : base(bdContext)
        {
        }
    }
}
