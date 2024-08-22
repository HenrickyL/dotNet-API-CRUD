
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

    [Theory]
    [InlineData("John Doe")]
    [InlineData("Jane Doe")]
    public async Task GetAllStudentsAsync_ReturnsAllStudents(string name)
    {
        // Arrange
        var studentList = new List<Student>
        {
            new Student(name)
        };

        var mockRepository = new Mock<IRepository<Student>>();
        mockRepository.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(studentList);

        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(uow => uow.Students)
            .Returns(mockRepository.Object);

        var studentService = new StudentService(mockUnitOfWork.Object);

        // Act
        var result = await studentService.GetAllStudentsAsync();

        // Assert
        result.Should().BeEquivalentTo(studentList);
    }

}
