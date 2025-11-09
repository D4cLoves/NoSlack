using MediatR;
using NoSlack.Domain.Interfaces;
using NoSlack.Domain.Models;

namespace NoSlackApplication.Queries;

    public record GetHabitsQuery : IRequest<List<Habit>>;

    public class GetHabitsHandler : IRequestHandler<GetHabitsQuery, List<Habit>>
    {
        private readonly IHabitRepository _repo;
        public GetHabitsHandler(IHabitRepository repo) => _repo = repo;

        public async Task<List<Habit>> Handle(GetHabitsQuery request, CancellationToken ct) =>
            await _repo.GetAllAsync();
    }