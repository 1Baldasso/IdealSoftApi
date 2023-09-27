using FastEndpoints;
using IdealSoftApi.Domain;
using IdealSoftApi.Repositories;

namespace IdealSoftApi.Endpoints;

public class CreatePessoa : Endpoint<Pessoa>
{

    private readonly IPessoaRepository _repository;
    public CreatePessoa(IPessoaRepository repository)
    {
        _repository = repository;
    }
    public override void Configure()
    {
        AllowAnonymous();
        Post("/pessoas");
    }
    public override async Task HandleAsync(Pessoa req, CancellationToken ct)
    {
        await _repository.CreateAsync(req, ct);
        await SendOkAsync(req);
    }
}
