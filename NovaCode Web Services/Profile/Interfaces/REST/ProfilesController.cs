using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NovaCode_Web_Services.IAM.Domain.Model.Queries;
using NovaCode_Web_Services.IAM.Domain.Services;
using NovaCode_Web_Services.Profile.Domain.Model.Commands;
using NovaCode_Web_Services.Profile.Domain.Model.Queries;
using NovaCode_Web_Services.Profile.Domain.Services;
using NovaCode_Web_Services.Profile.Interfaces.REST.Resources;
using NovaCode_Web_Services.Profile.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaCode_Web_Services.Profile.Interfaces.REST;

[ApiController]
[Route("api/v1/profiles")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Profile Profile Management Endpoints.")]
public class ProfilesController : ControllerBase
{
    private readonly IProfileCommandService _commandService;
    private readonly IProfileQueryService _queryService;
    private readonly IUserQueryService _userQueryService;

    public ProfilesController(
        IProfileCommandService commandService,
        IProfileQueryService queryService,
        IUserQueryService userQueryService)
    {
        _commandService = commandService;
        _queryService = queryService;
        _userQueryService = userQueryService;
    }

    [HttpGet]
    [SwaggerOperation("Get All Profiles", "Returns all registered user profiles.", OperationId = "GetAllUsers")]
    [SwaggerResponse(200, "Users found.", typeof(IEnumerable<ProfileResource>))]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllProfilesQuery();
        var users = await _queryService.Handle(query);

        if (users == null || !users.Any())
            return NotFound("No users found.");

        var resources = users.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation("Get Profile by Id", "Returns user profile for a specific ID.", OperationId = "GetUserById")]
    [SwaggerResponse(200, "Profile found.", typeof(ProfileResource))]
    [SwaggerResponse(404, "Profile not found.")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _queryService.Handle(new GetProfileByIdQuery(id));

        if (user == null)
            return NotFound($"Profile with ID {id} not found.");

        return Ok(ProfileResourceFromEntityAssembler.ToResourceFromEntity(user));
    }

    [HttpPost("/api/v1/users/{userId}/profile")]
    [SwaggerOperation("Create new Profile", "Creates a new user profile.", OperationId = "CreateUser")]
    [SwaggerResponse(201, "Profile created successfully.", typeof(ProfileResource))]
    public async Task<IActionResult> CreateUser([FromRoute] int userId, [FromBody] CreateProfileResource resource)
    {
        if (resource == null)
            return BadRequest("Invalid data.");

        // Validar existencia del usuario en IAM
        var user = await _userQueryService.Handle(new GetUserByIdQuery(userId));
        if (user == null)
            return NotFound($"User with ID {userId} not found.");

        var command = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource, userId);
        var created = await _commandService.Handle(command);
        var resultResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(created);

        return CreatedAtAction(nameof(GetUserById), new { id = created.Id }, resultResource);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation("Update Profile", "Updates an existing user profile.", OperationId = "UpdateUser")]
    [SwaggerResponse(200, "Profile updated successfully.", typeof(ProfileResource))]
    [SwaggerResponse(404, "Profile not found.")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateProfileCommand command)
    {
        if (command == null)
            return BadRequest("Invalid data.");

        var updated = await _commandService.Handle(id, command);
        if (updated == null)
            return NotFound($"Profile with ID {id} not found.");

        return Ok(ProfileResourceFromEntityAssembler.ToResourceFromEntity(updated));
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation("Delete Profile", "Deletes a user profile.", OperationId = "DeleteUser")]
    [SwaggerResponse(200, "Profile deleted successfully.")]
    [SwaggerResponse(404, "Profile not found.")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _commandService.Handle(new DeleteProfileCommand(id));
        if (deleted == null)
            return NotFound($"Profile with ID {id} not found.");

        return Ok("Profile deleted successfully.");
    }
}