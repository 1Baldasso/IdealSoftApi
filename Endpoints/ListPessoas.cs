using FastEndpoints;
using IdealSoftApi.Domain;
using IdealSoftApi.Repositories;

namespace IdealSoftApi.Endpoints;

public class ListPessoas : EndpointWithoutRequest<IEnumerable<Pessoa>>
{
    private readonly IPessoaRepository _repository;
    public ListPessoas(IPessoaRepository repository)
    {
        _repository = repository;
    }
    public override void Configure()
    {
        AllowAnonymous();
        Get("/pessoas");
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var pessoas = await _repository.ListAllAsync();
        await SendOkAsync(pessoas);
    }
}
