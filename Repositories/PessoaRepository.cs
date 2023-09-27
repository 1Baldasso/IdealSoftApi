using IdealSoftApi.DataAccess;
using IdealSoftApi.Domain;
using Microsoft.EntityFrameworkCore;
namespace IdealSoftApi.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly PessoasContext _context;
    public PessoaRepository(PessoasContext context)
    {
        _context = context;
    }

    public async Task<Pessoa> CreateAsync(Pessoa pessoa, CancellationToken ct = default)
    {
        await _context.Pessoas.AddAsync(pessoa);
        await _context.SaveChangesAsync();
        return pessoa;
    }

    public async Task<Pessoa> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Pessoas.FirstOrDefaultAsync(x=>x.Id == id) ?? throw new EntityNotFoundException();
    }

    public async Task<IEnumerable<Pessoa>> ListAllAsync(CancellationToken ct = default)
    {
        return await _context.Pessoas.ToListAsync();
    }

    public async Task<Pessoa> UpdateAsync(Pessoa pessoa, CancellationToken ct = default)
    {
        var pessoaDb = await _context.Pessoas.FirstOrDefaultAsync(x=>x.Id == pessoa.Id);
        if(pessoaDb is null)
            throw new EntityNotFoundException();
        _context.Entry(pessoaDb).CurrentValues.SetValues(pessoa);
        await _context.SaveChangesAsync(ct);
        return pessoa;
    }

    public void DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var pessoa = _context.Pessoas.Find(id);
        if(pessoa == null)
            throw new EntityNotFoundException();
        _context.Pessoas.Remove(pessoa);
        _context.SaveChanges();
    }
}
