using DynamicForm.Core.DTOs.InputComponent;
using System.ComponentModel.DataAnnotations;

namespace DynamicForm.Core.DTOs.Form
{
    public class CreateFormDto
    {
        [Required]
        public string Name { get; set; }
        public List<CreateInputComponentDto> InputComponents { get; set; }
    }
}
