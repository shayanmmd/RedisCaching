using _0_FrameWork.Application;
using Application_Contracts;
using Domain;

namespace Application;


public class PersonApplication : IPersonApplication
{
    public event EventHandler<Person> OnDataChanged;

    private readonly IPersonRepository _personRepository;
    public PersonApplication(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
        var redisInstance = RedisCache.GetInstance();
        OnDataChanged += redisInstance.HandlePerson;
    }

    public OperationResult Create(CreatePerson command)
    {
        OperationResult result = new();
        if (_personRepository.Exits(x => x.Id == command.Id))
            return result.Failed("رکورد مورد نظر قبلا در دیتابیس موجود است");
        Person person = new(command.Name, command.BirthDate);
        _personRepository.Create(person);
        _personRepository.SaveChanges();
        OnDataChanged.Invoke(this, person);
        return result.Succedded();
    }
    public OperationResult Edit(EditPerson command)
    {
        OperationResult result = new();
        if (!_personRepository.Exits(x => x.Id == command.Id))
            return result.Failed("چنین رکوردی در دیتابیس موجود نمیباشد");
        Person person = new(command.Id, command.Name, command.BirthDate);
        _personRepository.Update(person);
        _personRepository.SaveChanges();
        OnDataChanged.Invoke(this, person);
        return result.Succedded();
    }

    public PersonViewModel GetBy(long id)
    {
        Person person = _personRepository.Get(id);
        PersonViewModel personViewModel = new()
        {
            Name = person.Name,
            BirthDate = person.BirthDate
        };
        return personViewModel;
    }
    List<PersonViewModel> IPersonApplication.GetAll()
    {
        List<PersonViewModel> personViewModels = new();
        List<Person> persons = _personRepository.GetAll();
        foreach (var item in persons)
        {
            PersonViewModel personViewModel = new()
            {
                Name = item.Name,
                BirthDate = item.BirthDate,
            };
            personViewModels.Add(personViewModel);
        }
        return personViewModels;
    }
}
