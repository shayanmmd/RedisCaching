using _0_FrameWork.Application;

namespace Application_Contracts;

public interface IPersonApplication
{
    OperationResult Create(CreatePerson command);
    OperationResult Edit(EditPerson command);
    PersonViewModel GetBy(long id);
    List<PersonViewModel> GetAll();
}
