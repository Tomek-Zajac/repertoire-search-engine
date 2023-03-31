using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepertoireManagementService.Application.Modules.Cinemas.Dtos;

public record RepertoireDto
{
    public string Id { get; set; }
    public List<MovieDto> Movies { get; init; }
    public List<SittingDto> Sittings { get; init; }
}