using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands.News
{
    public class SaveNewsCommandHandler : IRequestHandler<SaveNewsCommand, bool>
    {
        public async Task<bool> Handle(SaveNewsCommand request, CancellationToken cancellationToken)
        {
            int i = 0;
            return true;
        }
    }
}
