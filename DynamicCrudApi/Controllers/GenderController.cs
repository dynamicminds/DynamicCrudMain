using AutoMapper;
using DynamicCrud.Api.Helpers;
using DynamicCrud.Api.Dto;
using DynamicCrud.Api.Interfaces;
using DynamicCrud.Api.Mapper;
using DynamicCrud.Api.Exceptions;
using DynamicCrud.Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace DynamicCrud.Api.Controllers
{
    /// <summary>
    /// Controller for managing Genders.
    /// </summary>
    [Route("api/Gender")]
    [ApiController]
    public class GenderController : ControllerBase
    {

        /// <summary>
        /// The logger of type GenderController.
        /// </summary>
        private readonly ILogger<GenderController> logger;

        /// <summary>
        /// The Genders Service.
        /// </summary>
        private readonly ICrudService<Genders, GenderDto> crudService;

        /// <summary>
        ///     The http context accessor.
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenderController" /> class.
        /// </summary>
        /// <param name="crudService">Instance of the <see cref="ICrudService<Genders, GenderDto>"/> class.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="httpContextAccessor">The http context accessor.</param>
        public GenderController(ICrudService<Genders, GenderDto> crudService,
            ILogger<GenderController> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            this.crudService = crudService;
            this.logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }


        [HttpGet("all", Name = "GetAllGenders")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var logMessage = $"GetList";
                List<GenderDto>? dataList = null;
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

        [HttpGet("{id}", Name = "GetGender")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return this.BadRequest();
            }

            try
            {
                var logMessage = $"Get Gender id: {id}";
                this.logger.LogInformation($"Entered {logMessage}");
                GenderDto? positiveTypesDto = await this.crudService.GetById(id);
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

        [HttpPost(Name = "CreateGender")]
        public async Task<IActionResult> Add([FromBody] GenderDto genderDto)
        {
            try
            {
                if (genderDto == null)
                {
                    throw new ArgumentException($"Invalid parameter!!");
                }

                var logMessage = $"Create Gender for Type  {genderDto.Description}";
                this.logger.LogInformation($"Entered {logMessage}");
                int PositiveTypesId = await this.crudService.Add(genderDto);
                this.logger.LogInformation($"Exited {logMessage}");

                return (PositiveTypesId == 0)
                  ? StatusCodeHelper.GetObjectResult(StatusCodes.Status500InternalServerError, "Unable to add PositiveTypes details")
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

        [HttpPut(Name = "UpdateGender")]
        public async Task<IActionResult> Update([FromBody] GenderDto positiveTypes)
        {
            try
            {
                if (positiveTypes == null)
                {
                    throw new ArgumentException($"Invalid parameter!!");
                }

                var logMessage = $"Update Gender: {positiveTypes.Id}";
                this.logger.LogInformation($"Entered {logMessage}");
                await this.crudService.Update(positiveTypes.Id, positiveTypes);
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
                var logMessage = $"Delete Gender : Id {id}";
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
