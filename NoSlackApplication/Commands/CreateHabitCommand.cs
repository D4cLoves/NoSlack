using MediatR;
using NoSlack.Domain.Interfaces;
using NoSlack.Domain.Models;

namespace NoSlackApplication.Commands;

    public record CreateHabitCommand(string Name) : IRequest<Habit>;
    public class CreateHabitHandler : IRequestHandler<CreateHabitCommand, Habit>
    {
        private readonly IHabitRepository _repo;
        public CreateHabitHandler(IHabitRepository repo) => _repo = repo;
        
        public async Task<Habit> Handle(CreateHabitCommand request, CancellationToken ct)
        {
            var habit = new Habit { Name = request.Name };
            return await _repo.AddAsync(habit);
        }
        
}