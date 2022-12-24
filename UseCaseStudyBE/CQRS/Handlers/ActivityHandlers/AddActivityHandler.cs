using MediatR;
using UseCaseStudyBE.CQRS.Commands.ActivityCommands;
using UseCaseStudyBE.Models;

namespace UseCaseStudyBE.CQRS.Handlers.ActivityHandlers;

public class AddActivityHandler : IRequestHandler<AddActivityCommand, Activity>
{
    private readonly NEDbContext _neDbContext;

    public AddActivityHandler(NEDbContext neDbContext)
    {
        _neDbContext = neDbContext;
    }

    public Task<Activity> Handle(AddActivityCommand request, CancellationToken cancellationToken)
    {
        _neDbContext.Activities.Add(request.model);
        _neDbContext.SaveChanges();
        return Task.FromResult(request.model);
    }
}