using ChallengeUserAccess.Contracts;
using ChallengeUserAccess.Controllers.Base;
using ChallengeUserAccess.Usecase.AddressUseCase.Request;
using ChallengeUserAccess.Usecase.AddressUseCase.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ChallengeUserAccess.Controllers;

[ApiController]
[Route("/Address")]
[Authorize(Roles = "admin")]
public class AddressController : MainController
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateAddressResponse))]
    public async Task<IActionResult> CreateAddress([FromBody] CreateAddressRequest addressCreateRequest)
    {
        var response = await _addressService.CreateAddressAsync(addressCreateRequest);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SearchAddresResponse))]
    public async Task<IEnumerable> FindAllAddresses()
    {
        var response = await _addressService.GetAddressesAsync();
        return response;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SearchAddresResponse))]
    public async Task<IActionResult> FindClientById(Guid id)
    {
        var response = await _addressService.GetAddressByIdAsync(id);
        return Ok(response);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(UpdateAddressResponse))]
    public async Task<IActionResult> UpdateAddress(Guid id, JsonPatchDocument<UpdateAddressRequest> request)
    {
        var response = await _addressService.UpdateAddressAsync(id, request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(Guid id)
    {
        var response = await _addressService.DeleteAdressAsync(id);
        return Ok(response);
    }
}
