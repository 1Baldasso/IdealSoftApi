using IdealSoftApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IdealSoftApi.DTO;

public class UpdatePessoaDTO
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public Pessoa Pessoa { get; set; }
}
