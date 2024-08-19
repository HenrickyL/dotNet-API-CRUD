
using FluentAssertions;
using Moq;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Services;
using Xunit;

namespace StudentApi.Tests;
public class StudentServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IRepository<Student>> _mockStudentRepository;
    private readonly StudentService _service;

    public StudentServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockStudentRepository = new Mock<IRepository<Student>>();
        _mockUnitOfWork.Setup(uow => uow.Students).Returns(_mockStudentRepository.Object);
        _service = new StudentService(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task GetAllStudentsAsync_ShouldReturnAllStudents()
    {
        // Arrange
        var students = new List<Student>
        {
            new Student("John Doe"),
            new Student("Jane Smith")
        };

        _mockStudentRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(students);

        // Act
        var result = await _service.GetAllStudentsAsync();

        // Assert
        result.Should().BeEquivalentTo(students);
    }

}
