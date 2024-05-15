using MediatR;
using SO00000010.Application.Commands.Program;
using SO00000010.Application.Queries.Program;
using SO00000010.Domain.Contracts.ProgramContracts;

namespace SO00000010.Presentation.Controllers.V1
{
    public class ProgramController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                IEnumerable<ProgramModel> programs = await _mediator.Send(new GetProgramsQuery());
                _response.IsSuccess = true;
                _response.Result = programs;

                return Ok(_response);
            });
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetProgram))]
        public async Task<IActionResult> GetProgram(Guid id, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                ProgramModel? program = await _mediator.Send(new GetProgramByIdQuery(id));
                if (program is null)
                {
                    _response.Message = $"Program with id=\"{id}\" not found!";
                    return NotFound(_response);
                }

                _response.IsSuccess = true;
                _response.Result = program;

                return Ok(_response);
            });
        }

        [HttpPost]
        [Route(nameof(CreateProgramAndApplication))]
        public async Task<IActionResult> CreateProgramAndApplication([FromBody] CreateProgramAndApplicationModel data, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                bool result = await _mediator.Send(new CreateProgramAndApplicationCommand(data));
                if (!result)
                {
                    _response.Message = "An error occured while creating program and application";
                    return BadRequest(_response);
                }

                _response.IsSuccess = true;
                Log.Information("Program and Application created successfully.");
                return Ok(_response);
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateProgramModel data, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                ProgramModel? program = await _mediator.Send(new CreateProgramCommand(data));
                if (program is null)
                {
                    _response.Message = "An error occured while creating program";
                    return BadRequest(_response);
                }

                _response.IsSuccess = true;
                _response.Result = program;
                Log.Information("Program created successfully.");
                return CreatedAtRoute(nameof(GetProgram), new { id = program.Id }, _response);
            });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateProgramModel data, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                ProgramModel? program = await _mediator.Send(new UpdateProgramCommand(data));
                if (program is null)
                {
                    _response.Message = "An error occured while updating program";
                    return BadRequest(_response);
                }

                _response.IsSuccess = true;
                _response.Result = program;
                Log.Information($"Program updated successfully. Id=\"{program.Id}\", Title=\"{program.Title}\" ");
                return CreatedAtRoute(nameof(GetProgram), new { id = program.Id }, _response);
            });
        }
    }
}