using System.Data.Common;
using TutorCabinet.Application.DTOs.Students;
using TutorCabinet.Application.Interfaces.Services;
using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;

namespace TutorCabinet.Application.Services;

public class StudentService(IStudentRepository repo, IUnitOfWork uow) : IStudentService
{
    public async Task<Guid> CreateAsync(CreateStudentDto dto, CancellationToken cancellationToken)
    {
        var student = Student.Create(
            Guid.NewGuid(),
            dto.Name,
            dto.ClassNumber,
            dto.DirectionStudyId
        );
        try
        {
            await repo.AddAsync(student, cancellationToken);
            await uow.SaveChangesAsync(cancellationToken);
            return student.Id;
        }
        catch (DbException ex)
        {
            throw new InvalidOperationException("Unable to create student", ex);
        }
    }

    public async Task<StudentsListDto?> GetAllAsync(CancellationToken cancellationToken)
    {
        var students = await repo.GetAllAsync(cancellationToken);
        if (students is null)
            return null;
        var studentsDto = students
            .Select(s => new StudentDto(s.Id, s.Name, s.ClassNumber, s.DirectionStudyId))
            .ToList();
        return new StudentsListDto(studentsDto, studentsDto.Count);
    }

    public async Task<StudentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await repo.GetByIdAsync(id, cancellationToken);
        return student is null
            ? null
            : new StudentDto(
                student.Id,
                student.Name,
                student.ClassNumber,
                student.DirectionStudyId
            );
    }
}
