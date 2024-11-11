namespace Taskeroni.Core.Entities
{
	public class TodoTask
	{
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsCompleted { get; private set; }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public bool IsOverdue() => DueDate.HasValue && DueDate.Value < DateTime.UtcNow && !IsCompleted;
    }
}

