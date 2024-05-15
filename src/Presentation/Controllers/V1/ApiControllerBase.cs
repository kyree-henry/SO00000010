using Asp.Versioning;
using SO00000010.Domain.Exceptions;
using SO00000010.Presentation.Data;

namespace SO00000010.Presentation.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        public ServiceResponse _response { get; set; } = new();

        protected async Task<IActionResult> HandleExceptionAsync(Func<Task<IActionResult>> action, string? customErrorMessage = null)
        {
            try
            {
                return await action();
            }
            catch (SO00000010Exception ex)
            {
                Log.Error(ex, ex.Message);
                _response.Message = customErrorMessage ?? "An error occurred.";
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
                return StatusCode(500, _response);
            }
        }

    }
}