using MediatR;
using UseCaseStudyBE.CQRS.Commands.ActivityCommands;
using UseCaseStudyBE.Models;

namespace UseCaseStudyBE.CQRS.Handlers.ActivityHandlers;

public class UpdateActivityHandler : IRequestHandler<UpdateActivityCommand, Activity>
{
    private readonly NEDbContext _neDbContext;

    public UpdateActivityHandler(NEDbContext neDbContext)
    {
        _neDbContext = neDbContext;
    }

    public Task<Activity> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        _neDbContext.Activities.Update(request.model);
        _neDbContext.SaveChanges();
        return Task.FromResult(request.model);
    }
}