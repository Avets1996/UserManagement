using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Entities;
using UserManagement.Application.Enums;
using UserManagement.Application.Interfaces;
using UserManagement.Models;

namespace UserManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.GetById(id);
        
        return Ok(_mapper.Map<UserResponse>(user));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(UserType? type = null)
    {
        var users = await _userService.GetAll(type);
        
        return Ok(_mapper.Map<List<UserResponse>>(users));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateUserRequest request)
    {
        var user = await _userService.Create(request.FirstName, request.LastName, request.UserType);

        return StatusCode((int)HttpStatusCode.Created, _mapper.Map<UserResponse>(user));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _userService.Delete(id))
        {
            return NoContent();
        }
        
        return NotFound();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserRequest request)
    {
        var user = _mapper.Map<User>(request);
        user.Id = id;
        await _userService.Update(user);
        return Ok(request);
    }
}