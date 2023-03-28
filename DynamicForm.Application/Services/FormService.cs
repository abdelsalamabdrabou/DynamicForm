using DynamicForm.Core.DTOs;
using DynamicForm.Core.DTOs.Form;
using DynamicForm.Core.DTOs.InputComponent;
using DynamicForm.Core.Entities;
using DynamicForm.Core.Interfaces.Services;
using DynamicForm.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;
using System.Text.Json.Nodes;

namespace DynamicForm.Application.Services
{
    public class FormService : IFormService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDatabase _database;

        public FormService(ApplicationDbContext context, IConnectionMultiplexer connectionMultiplexer)
        {
            _context = context;
            _database = connectionMultiplexer.GetDatabase();
        }
        public async Task<ResponseMessage> CreateForm(CreateFormDto createFormDto)
        {
            
            var FormModel = new Form
            {
                Name = createFormDto.Name,
                InputComponents = createFormDto.InputComponents.Select(x => new InputComponent
                {
                    Label = x.Label,
                    Name = x.Name,
                    Type = x.Type,
                    InputValues = x.Type == "dropdown" || x.Type == "radio" || x.Type == "checkbox" ? x.InputValues.Select(y => new InputValue
                    {
                        Value = y.Value

                    }).ToList() : null
                }).ToList(),
            };

            await _context.AddAsync(FormModel);

            if (await _context.SaveChangesAsync() < 1)
                return new ResponseMessage("Form cannot be added right now.", false);

            return new ResponseMessage("Form has been added successfully.", true);
        }
        public async Task<ResponseMessage> GetFormsList()
        {
            var forms = await _context.Forms.Select(x => new GetFormsListDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            if (forms.Count == 0)
                return new ResponseMessage("No data founded.", false);

            return new ResponseMessage("Data has been loaded successfully.", true, forms);
        }
        public async Task<ResponseMessage> GetFormInputs(int formId)
        {
            var formInputs = await _context.InputComponents
                .Where(x => x.FormId == formId)
                .Select(x => new GetFormDto
                {
                    Name = x.Name,
                    Label = x.Label,
                    Type = x.Type,
                    InputValues = x.InputValues.Select(y => new GetInputValuesDto
                    {
                        Value = y.Value
                    }).ToList()
                }).ToListAsync();

            if (formInputs.Count == 0)
                return new ResponseMessage("No data founded.", false);

            return new ResponseMessage("Data has been loaded successfully.", true, formInputs);
        }
        public async Task<ResponseMessage> SaveFormData(JsonObject model)
        {
            var key = Guid.NewGuid().ToString();
            var value = model.ToJsonString();

            if (!await _database.StringSetAsync(key, value))
                return new ResponseMessage("Data cannot be added right now.", false);

            return new ResponseMessage("Data has been added successfully.", true);
        }
    }
}
