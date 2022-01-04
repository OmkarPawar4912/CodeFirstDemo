using DemoRepoPattern.Data;
using DemoRepoPattern.Entities;
using DemoRepoPattern.Interfaces;

namespace DemoRepoPattern.Implementations
{
    public class DivisionRepository : Repository<Division>, IDivisionRepository
    {
        public DivisionRepository(ApplicationBDContext applicationBDContext) : base(applicationBDContext)
        {

        }
    }
}
