using System.ComponentModel.DataAnnotations;

namespace DynamicForm.Core.DTOs.InputComponent
{
    public class CreateInputComponentDto
    {
        [Required]
        public string Label { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public List<CreateInputValueDto>? InputValues { get; set; }

    }
}
