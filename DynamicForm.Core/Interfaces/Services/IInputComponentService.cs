using DynamicForm.Core.DTOs;
using DynamicForm.Core.DTOs.Form;
using DynamicForm.Core.DTOs.InputComponent;

namespace DynamicForm.Core.Interfaces.Services
{
    public interface IInputComponentService
    {
        Task<ResponseMessage> AddValueToInput(List<CreateInputValueDto> inputValueDto);
    }
}
