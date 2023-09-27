using FastEndpoints;
using IdealSoftApi.Domain;
using IdealSoftApi.DTO;
using IdealSoftApi.Repositories;

namespace IdealSoftApi.Endpoints;

public class UpdatePessoa : Endpoint<UpdatePessoaDTO,Pessoa>
{
    private readonly IPessoaRepository _repository;

    public UpdatePessoa(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Put("/pessoas/{id}");
    }
    public override async Task HandleAsync(UpdatePessoaDTO req, CancellationToken ct)
    {
        var pessoa = await _repository.UpdateAsync(req.Pessoa);
        await SendOkAsync(req.Pessoa);
    }
}