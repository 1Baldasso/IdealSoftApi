using FastEndpoints;
using IdealSoftApi.Domain;
using IdealSoftApi.DTO;
using IdealSoftApi.Repositories;

namespace IdealSoftApi.Endpoints;

public class DeletePessoa : Endpoint<PessoaByIdDTO>
{
    private readonly IPessoaRepository _repository;
        public DeletePessoa(IPessoaRepository repository)
    {
            _repository = repository;
        }
        public override void Configure()
    {
            AllowAnonymous();
            Delete("/pessoas/{id}");
        }
        public override async Task HandleAsync(PessoaByIdDTO req, CancellationToken ct)
    {
            _repository.DeleteAsync(req.Id, ct);
            await SendOkAsync();
        }
}
