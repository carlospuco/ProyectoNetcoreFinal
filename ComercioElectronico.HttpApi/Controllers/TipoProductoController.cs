using ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[AllowAnonymous]
public class TipoProductoController:ControllerBase
{
    private readonly ITipoProductoAppService tipoProductoAppService;
    public TipoProductoController(ITipoProductoAppService tipoProductoAppService)
    {
        this.tipoProductoAppService=tipoProductoAppService;
    }

    [HttpGet]
    [AllowAnonymous] 
    public ICollection<TipoProductoDto> obtenerMarcas()
    {
        return tipoProductoAppService.GetAll();
    }

    [HttpPost]
    [AllowAnonymous]
    //[FromDorm] acceptar informacion desde un formulario 
    public async Task<TipoProductoDto> registrar([FromForm] TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {
        return await tipoProductoAppService.CreateAsync(tipoProductoCreateUpdateDto);
    }

    [HttpPut("{tipoProductoId}")]
    public async Task actualizar(string tipoProductoId, [FromForm] TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {
        await tipoProductoAppService.UpdateAsync(tipoProductoId,tipoProductoCreateUpdateDto);
    }

    [HttpDelete("{tipoProductoId}")]
    public async Task<bool> DeleteAsync(string tipoProductoId)
    {

        return await tipoProductoAppService.DeleteAsync(tipoProductoId);

    }
}

