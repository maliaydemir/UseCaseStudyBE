using MediatR;
using UseCaseStudyBE.Models;

namespace UseCaseStudyBE.CQRS.Commands.ActivityCommands;

public record UpdateActivityCommand(Activity model):IRequest<Activity>;