using StudentApi.Data;
using StudentApi.DTO;
using StudentApi.Models;

namespace StudentApi.Services;

public class StudentService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _unitOfWork.Students.GetAllAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(Guid id)
    {
        return await _unitOfWork.Students.GetByIdAsync(id);
    }

    public async Task AddStudentAsync(StudentCreateRequest request)
    {
        var student = new Student(request.Name);
        await _unitOfWork.Students.AddAsync(student);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        await _unitOfWork.Students.UpdateAsync(student);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveStudentAsync(Guid id)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(id);
        if (student != null)
        {
            await _unitOfWork.Students.RemoveAsync(student);
            await _unitOfWork.CompleteAsync();
        }
    }
}
