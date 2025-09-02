using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;
using TutorCabinet.Infrastructure.Persistence.Contexts;
using TutorCabinet.Infrastructure.Persistence.Entities;
using TutorCabinet.Infrastructure.Persistence.Mappers;

namespace TutorCabinet.Infrastructure.Persistence.Repositories;

public class StudentRepository(AppDbContext ctx)
    : BaseRepository<StudentEntity, Student>(ctx),
        IStudentRepository
{
    protected override Student ToDomain(StudentEntity entity)
    {
        return entity.ToDomain();
    }

    protected override StudentEntity ToEntity(Student domain)
    {
        return domain.ToEntity();
    }
}
