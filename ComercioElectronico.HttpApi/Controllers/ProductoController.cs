using ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductoController:ControllerBase
{
    private readonly IProductoAppService productoAppService;
    public ProductoController(IProductoAppService productoAppService)
    {
        this.productoAppService=productoAppService;
    }

    [HttpGet]
    [AllowAnonymous]
    public ICollection<ProductoDto> obtenerProductos()
    {
        return productoAppService.GetAll();
    }

    [HttpGet("{campo}/{parametro}")]
    [AllowAnonymous]
    public ICollection<ProductoDto> obtenerProductosPaginado([FromQuery] int limit=10,[FromQuery] int offset=0,[FromRoute] string campo="",[FromRoute] string parametro="")
    {
        return productoAppService.GetAll();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ProductoDto> registrar([FromBody] ProductoCreateUpdateDto productoCreateUpdateDto)
    {
        return await productoAppService.CreateAsync(productoCreateUpdateDto);
    }

    [HttpPut("{productoId}")]
    [AllowAnonymous]
    public async Task actualizar(Guid productoId, [FromForm] ProductoCreateUpdateDto productoCreateUpdateDto)
    {
        await productoAppService.UpdateAsync(productoId,productoCreateUpdateDto);
    }

    [HttpDelete("{productoId}")]
    [AllowAnonymous]
    public async Task<bool> DeleteAsync(Guid productoId)
    {

        return await productoAppService.DeleteAsync(productoId);

    }
}
