using Azure;
using DynamicForm.Core.DTOs;
using DynamicForm.Core.DTOs.Form;
using DynamicForm.Core.DTOs.InputComponent;
using DynamicForm.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;
using System.Text.Json.Nodes;

namespace DynamicForm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicFormController : ControllerBase
    {
        private readonly IFormService _formService;
        private readonly IInputComponentService _inputComponentService;
        public DynamicFormController(IFormService formService, IInputComponentService inputComponentService)
        {
            _formService = formService;
            _inputComponentService = inputComponentService;
        }

        [HttpPost("CreateForm")]
        public async Task<IActionResult> CreateForm([FromBody] CreateFormDto createFormDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _formService.CreateForm(createFormDto);
            var responseStatus = GetResponseStatus(response);

            return responseStatus;
        }

        [HttpGet("GetFormsList")]
        public async Task<IActionResult> GetFormsList()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _formService.GetFormsList();
            var responseStatus = GetResponseStatus(response);

            return responseStatus;
        }

        [HttpGet("GetFormInputs")]
        public async Task<IActionResult> GetFormInputs([FromQuery] int formId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _formService.GetFormInputs(formId);
            var responseStatus = GetResponseStatus(response);

            return responseStatus;
        }

        [HttpPost("SaveFormData")]
        public async Task<IActionResult> SaveFormData([FromBody] JsonObject model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _formService.SaveFormData(model);
            var responseStatus = GetResponseStatus(response);

            return responseStatus;
        }

        [NonAction]
        public IActionResult GetResponseStatus(ResponseMessage responseMessage)
        {
            if (responseMessage.HasSucceed)
                return Ok(responseMessage);
            else
                return BadRequest(responseMessage);
        }
    }
}