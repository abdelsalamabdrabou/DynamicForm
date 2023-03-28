namespace DynamicForm.Core.Entities
{
    public class Form : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<InputComponent> InputComponents { get; set; }
    }
}
