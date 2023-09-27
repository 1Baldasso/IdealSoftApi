using IdealSoftApi.Domain;

namespace IdealSoftApi.Repositories;

public interface IPessoaRepository
{
    public Task<IEnumerable<Pessoa>> ListAllAsync(CancellationToken ct = default);
    public Task<Pessoa> GetByIdAsync(Guid id, CancellationToken ct = default);
    public Task<Pessoa> CreateAsync(Pessoa pessoa, CancellationToken ct = default);
    public Task<Pessoa> UpdateAsync(Pessoa pessoa, CancellationToken ct = default);
    public void DeleteAsync(Guid id, CancellationToken ct = default);
}
