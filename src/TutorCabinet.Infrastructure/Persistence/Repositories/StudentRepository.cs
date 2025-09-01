using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;
using TutorCabinet.Infrastructure.Persistence.Contexts;
using TutorCabinet.Infrastructure.Persistence.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Repositories;

public class StudentRepository(AppDbContext ctx)
    : BaseRepository<StudentEntity, Student>(ctx),
        IStudentRepository
{
    protected override Student ToDomain(StudentEntity entity)
    {
        throw new NotImplementedException();
    }

    protected override StudentEntity ToEntity(Student domain)
    {
        throw new NotImplementedException();
    }
}
