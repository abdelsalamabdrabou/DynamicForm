using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicForm.Core.Entities
{
    public class InputValue : BaseEntity
    {
        public int InputComponentId { get; set; }
        [ForeignKey("InputComponentId")]
        public InputComponent InputComponent { get; set; }
        public string? Value { get; set; }
    }
}
