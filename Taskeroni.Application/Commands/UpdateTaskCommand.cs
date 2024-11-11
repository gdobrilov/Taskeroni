using MediatR;
using System;

namespace Taskeroni.Application.Commands
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
    }
}