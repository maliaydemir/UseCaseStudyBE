using MediatR;
using UseCaseStudyBE.Models;

namespace UseCaseStudyBE.CQRS.Commands.ActivityCommands;

public record AddActivityCommand(Activity model):IRequest<Activity>;