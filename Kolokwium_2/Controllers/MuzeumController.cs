using Kolokwium_2.DTOs;
using Kolokwium_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_2.Controllers;


[ApiController]
public class MuzeumController : ControllerBase
{

    private IMuzeumService service;

    public MuzeumController(IMuzeumService service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("galleries/{id}/exhibitions")]
    public async Task<IActionResult> GetExhibitions([FromRoute] int id)
    {
        try
        {
            return Ok(await service.GetExhibitions(id));
        }
        catch (Exception e)
        {
            return NotFound("Gallery not found");
        }
    }

    [HttpPost]
    [Route("api/exhibitions")]
    public async Task<IActionResult> AddExhibition([FromBody] NewExhibitionDTO exhibitionDto)
    {
        ExhibitStatus status = await service.AddExhibition(exhibitionDto);
        switch (status)
        {
            case ExhibitStatus.ARTWORKNOTFOUND:
                return NotFound("Artwork not found");
            case ExhibitStatus.GALLERYNOTFOUND:
                return NotFound("Gallery not found");
            case ExhibitStatus.ERROR:
                return BadRequest("Error accured");
            default:
                return Ok();
        }
    }


}