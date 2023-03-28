using DynamicForm.Core.DTOs;
using DynamicForm.Core.DTOs.Form;
using System.Text.Json.Nodes;

namespace DynamicForm.Core.Interfaces.Services
{
    public interface IFormService
    {
        Task<ResponseMessage> CreateForm(CreateFormDto createFormDto);
        Task<ResponseMessage> GetFormInputs(int formId);
        Task<ResponseMessage> GetFormsList();
        Task<ResponseMessage> SaveFormData(JsonObject model);
    }
}
