using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Command;

namespace TableTennis4dView.Application.Commands.Techniques;

public class TechniqueCreateCommand : IRequest<int>
{
    public long PlayerId { get; set; }
    public string Title { get; set; }
    public IFormFile File { get; set; }
}


public class TechniqueCreateCommandHandler : IRequestHandler<TechniqueCreateCommand, int>
{
    private readonly ITechniqueCommandRepository _repository;
    private readonly IMapper _mapper;
    private readonly IHostingEnvironment _environment;


    public TechniqueCreateCommandHandler(ITechniqueCommandRepository repository, IMapper mapper, IHostingEnvironment environment)
    {
        _repository = repository;
        _mapper = mapper;
        _environment = environment;
    }

    public async Task<int> Handle(TechniqueCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var contentRoot = _environment.ContentRootPath; 
            var filePath = Path.Combine(contentRoot, $"Players/{request.File.FileName}");
            await using var stream = File.Create(filePath);
            await request.File.CopyToAsync(stream, cancellationToken);
            await _repository.AddAsync(new Technique
            {
                PlayerId = request.PlayerId,
                SourcePath = $"/players/{request.File.FileName}",
                Title = request.Title
            });
            
            return 1;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}