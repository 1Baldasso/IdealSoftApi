using IdealSoftApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IdealSoftApi.DTO;

public class PessoaByIdDTO
{
    [FromRoute]
    public Guid Id { get; set; }
}
