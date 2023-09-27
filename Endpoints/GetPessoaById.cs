using FastEndpoints;
using IdealSoftApi.Domain;
using IdealSoftApi.DTO;
using IdealSoftApi.Repositories;
namespace IdealSoftApi.Endpoints;

public class GetPessoaById : Endpoint<PessoaByIdDTO, Pessoa>
{
    public readonly IPessoaRepository _repository;
    public GetPessoaById(IPessoaRepository repository)
    {
        _repository = repository;
    }
    public override void Configure()
    {
        AllowAnonymous();
        Get("/pessoas/{id}");
    }
    public override async Task HandleAsync(PessoaByIdDTO req, CancellationToken ct)
    {
        var pessoa = await _repository.GetByIdAsync(req.Id, ct);
        await SendOkAsync(pessoa);
    }
}
