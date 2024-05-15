using MediatR;
using SO00000010.Application.Commands.ApplicationRecord;
using SO00000010.Application.Queries.ApplicationRecord;
using SO00000010.Domain.Contracts.ApplicationRecordContracts;

namespace SO00000010.Presentation.Controllers.V1
{
    public class ApplicationRecordController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public ApplicationRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                IEnumerable<ApplicationRecordModel> applicationRecords = await _mediator.Send(new GetApplicationRecordsQuery());
                _response.IsSuccess = true;
                _response.Result = applicationRecords;

                return Ok(_response);
            });
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetApplicationRecord))]
        public async Task<IActionResult> GetApplicationRecord(Guid id, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                ApplicationRecordModel? applicationRecord = await _mediator.Send(new GetApplicationRecordByIdQuery(id));
                if (applicationRecord is null)
                {
                    _response.Message = $"ApplicationRecord with id=\"{id}\" not found!";
                    return NotFound(_response);
                }

                _response.IsSuccess = true;
                _response.Result = applicationRecord;

                return Ok(_response);
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateApplicationRecordModel data, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                ApplicationRecordModel? applicationRecord = await _mediator.Send(new CreateApplicationRecordCommand(data));
                if (applicationRecord is null)
                {
                    _response.Message = "An error occured while creating application";
                    return BadRequest(_response);
                }

                _response.IsSuccess = true;
                _response.Result = applicationRecord;
                Log.Information("ApplicationRecord created successfully.");
                return CreatedAtRoute(nameof(GetApplicationRecord), new { id = applicationRecord.Id }, _response);
            });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateApplicationRecordModel data, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                ApplicationRecordModel? applicationRecord = await _mediator.Send(new UpdateApplicationRecordCommand(data));
                if (applicationRecord is null)
                {
                    _response.Message = "An error occured while updating application";
                    return BadRequest(_response);
                }

                _response.IsSuccess = true;
                _response.Result = applicationRecord;
                Log.Information($"ApplicationRecord updated successfully. Id=\"{applicationRecord.Id}\" ");
                return CreatedAtRoute(nameof(GetApplicationRecord), new { id = applicationRecord.Id }, _response);
            });
        }
    }
}