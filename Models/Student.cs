using StudentApi.Data;

namespace StudentApi.Models;

public class Student : Entity
{
    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    public Student(string name) { 
        Name = name;
        IsActive = true;
        Id = Guid.NewGuid();
    }
}
