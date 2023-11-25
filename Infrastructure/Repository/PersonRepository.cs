using _0_FrameWork.Infrastructure;
using Domain;

namespace Infrastructure.Repository;

public class PersonRepository : RepositoryBase<long, Person>, IPersonRepository
{
    private readonly MainDbContext _context;

    public PersonRepository(MainDbContext context) : base(context)
    {
        _context = context;
    }
}
