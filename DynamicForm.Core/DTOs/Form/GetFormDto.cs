using DynamicForm.Core.DTOs.InputComponent;

namespace DynamicForm.Core.DTOs.Form
{
    public class GetFormDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }

        public List<GetInputValuesDto>? InputValues { get; set; }
    }
}
