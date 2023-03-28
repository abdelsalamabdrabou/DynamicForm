using DynamicForm.Core.DTOs;
using DynamicForm.Core.DTOs.Form;
using DynamicForm.Core.DTOs.InputComponent;
using DynamicForm.Core.Entities;
using DynamicForm.Core.Interfaces.Services;
using DynamicForm.Infrastructure.Context;

namespace DynamicForm.Application.Services
{
    public class InputComponentService : IInputComponentService
    {
        private readonly ApplicationDbContext _context;
        public InputComponentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseMessage> AddValueToInput(List<CreateInputValueDto> inputValueDto)
        {
            var inputValueModel = inputValueDto.Select(x => new InputValue
            {
                Value = x.Value
            });

            await _context.AddRangeAsync(inputValueModel);

            if (await _context.SaveChangesAsync() < 1)
                return new ResponseMessage("Value cannot be added to input right now.", false);

            return new ResponseMessage("Value has been added to input successfully.", true);
        }
    }
}
