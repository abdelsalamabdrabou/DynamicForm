using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicForm.Core.Entities
{
    public class InputComponent : BaseEntity
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int FormId { get; set; }
        [ForeignKey("FormId")]
        public Form Form { get; set; }

        public ICollection<InputValue>? InputValues { get; set; }
    }
}
