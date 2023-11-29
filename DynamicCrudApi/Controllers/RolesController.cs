using AutoMapper;
using DynamicCrud.Api.Helpers;
using DynamicCrud.Api.Dto;
using DynamicCrud.Api.Interfaces;
using DynamicCrud.Api.Mapper;
using DynamicCrud.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using DynamicCrud.Entity.Model;

namespace DynamicCrud.Api.Controllers
{
    /// <summary>
    /// Controller for managing Roles.
    /// </summary>
    [Route("api/Roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        /// <summary>
        /// The logger of type RolesController.
        /// </summary>
        private readonly ILogger<RolesController> logger;

        /// <summary>
        /// The Roles Service.
        /// </summary>
        private readonly ICrudService<Roles, RolesDto> crudService;

        /// <summary>
        ///     The http context accessor.
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesController" /> class.
        /// </summary>
        /// <param name="crudService">Instance of the <see cref="ICrudService<Roles, RolesDto>"/> class.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="httpContextAccessor">The http context accessor.</param>
        public RolesController(ICrudService<Roles, RolesDto> crudService,
            ILogger<RolesController> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            this.crudService = crudService;
            this.logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }


        [HttpGet("all", Name = "GetAllRoles")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var logMessage = $"GetList";
                List<RolesDto>? dataList = null;
                this.logger.LogInformation($"Entered {logMessage}");
                dataList = await this.crudService.GetAll();
                this.logger.LogInformation($"Exited {logMessage}");

                return dataList != null ? this.Ok(dataList) : (IActionResult)this.NotFound();
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    GeneralExceptionHandler.HandleGeneralApiException(
                        ex,
                        this.logger,
                        this.httpContextAccessor.HttpContext?.TraceIdentifier));
            }
        }

        [HttpGet("{id}", Name = "GetRole")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return this.BadRequest();
            }

            try
            {
                var logMessage = $"Get Role id: {id}";
                this.logger.LogInformation($"Entered {logMessage}");
                RolesDto? positiveTypesDto = await this.crudService.GetById(id);
                this.logger.LogInformation($"Exited {logMessage}");

                return positiveTypesDto != null ? this.Ok(positiveTypesDto) : (IActionResult)this.NotFound();
            }
            catch (ArgumentException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    GeneralExceptionHandler.HandleGeneralApiException(
                        ex,
                        this.logger,
                        this.httpContextAccessor.HttpContext?.TraceIdentifier));
            }
        }

        [HttpPost(Name = "CreateRole")]
        public async Task<IActionResult> Add([FromBody] RolesDto dto)
        {
            try
            {
                if (dto == null)
                {
                    throw new ArgumentException($"Invalid parameter!!");
                }

                var logMessage = $"Create Role for Type  {dto.Description}";
                this.logger.LogInformation($"Entered {logMessage}");
                int PositiveTypesId = await this.crudService.Add(dto);
                this.logger.LogInformation($"Exited {logMessage}");

                return (PositiveTypesId == 0)
                  ? StatusCodeHelper.GetObjectResult(StatusCodes.Status500InternalServerError, "Unable to add details")
                  : this.Ok(PositiveTypesId);
            }
            catch (ArgumentException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    GeneralExceptionHandler.HandleGeneralApiException(
                        ex,
                        this.logger,
                        this.httpContextAccessor.HttpContext?.TraceIdentifier));
            }
        }

        [HttpPut(Name = "UpdateRole")]
        public async Task<IActionResult> Update([FromBody] RolesDto role)
        {
            try
            {
                if (role == null)
                {
                    throw new ArgumentException($"Invalid parameter!!");
                }

                var logMessage = $"Update role: {role.Id}";
                this.logger.LogInformation($"Entered {logMessage}");
                await this.crudService.Update(role.Id, role);
                this.logger.LogInformation($"Exited {logMessage}");

                return this.NoContent();
            }
            catch (ArgumentException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    GeneralExceptionHandler.HandleGeneralApiException(
                        ex,
                        this.logger,
                        this.httpContextAccessor.HttpContext?.TraceIdentifier));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return this.BadRequest();
            }

            try
            {
                var logMessage = $"Delete Role : Id {id}";
                this.logger.LogInformation($"Entered {logMessage}");
                await this.crudService.Delete(id);
                this.logger.LogInformation($"Exited {logMessage}");

                return this.Ok();
            }
            catch (InvalidOperationException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (ArgumentException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return StatusCodeHelper.GetObjectResult(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    GeneralExceptionHandler.HandleGeneralApiException(
                        ex,
                        this.logger,
                        this.httpContextAccessor.HttpContext?.TraceIdentifier));
            }
        }
    }
}
