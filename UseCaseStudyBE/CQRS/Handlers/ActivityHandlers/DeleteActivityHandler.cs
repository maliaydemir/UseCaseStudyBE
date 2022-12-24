using MediatR;
using UseCaseStudyBE.CQRS.Commands.ActivityCommands;
using UseCaseStudyBE.Models;

namespace UseCaseStudyBE.CQRS.Handlers.ActivityHandlers;

public class DeleteActivityHandler:IRequestHandler<DeleteActivityCommand,Activity>
{
    private readonly NEDbContext _neDbContext;
    public DeleteActivityHandler(NEDbContext neDbContext)
    {
        _neDbContext = neDbContext;
    }
    public Task<Activity> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = _neDbContext.Activities.FirstOrDefault(e=>e.Id.ToString()==request.id);
        _neDbContext.Activities.Remove(activity);
        _neDbContext.SaveChanges();
        return Task.FromResult(_neDbContext.Activities.FirstOrDefault(e=>e.Id.ToString()==request.id));
    }
}