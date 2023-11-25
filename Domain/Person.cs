using _0_FrameWork.Domain;

namespace Domain;

public class Person : EntityBase
{
    public string Name { get; private set; }

    public Person(string name,DateTime birthDate)
    {
        BirthDate = birthDate;
        Name = name;
    }
    public Person(long id,string name, DateTime birthDate)
    {
        Id = id;
        BirthDate = birthDate;
        Name = name;
    }
}
