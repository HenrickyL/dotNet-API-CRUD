using StudentApi.Data;

namespace StudentApi.Models;

public class Cohort : Entity
{
    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    public Cohort(string name)
    {
        Name = name;
        IsActive = true;
        Id = Guid.NewGuid();
    }
}