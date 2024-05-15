using MediatR;
using SO00000010.Application.Commands.Answer;
using SO00000010.Application.Queries.Answer;
using SO00000010.Domain.Contracts.AnswerContracts;

namespace SO00000010.Presentation.Controllers.V1
{
    public class AnswerController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                IEnumerable<AnswerModel> answers = await _mediator.Send(new GetAnswersQuery());
                _response.IsSuccess = true;
                _response.Result = answers;

                return Ok(_response);
            });
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetAnswer))]
        public async Task<IActionResult> GetAnswer(Guid id, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                AnswerModel? answer = await _mediator.Send(new GetAnswerByIdQuery(id));
                if (answer is null)
                {
                    _response.Message = $"Answer with id=\"{id}\" not found!";
                    return NotFound(_response);
                }

                _response.IsSuccess = true;
                _response.Result = answer;

                return Ok(_response);
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateAnswerModel data, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                AnswerModel? answer = await _mediator.Send(new CreateAnswerCommand(data));
                if (answer is null)
                {
                    _response.Message = "An error occured while creating answer";
                    return BadRequest(_response);
                }

                _response.IsSuccess = true;
                _response.Result = answer;
                Log.Information("Answer created successfully.");
                return CreatedAtRoute(nameof(GetAnswer), new { id = answer.Id }, _response);
            });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateAnswerModel data, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                AnswerModel? answer = await _mediator.Send(new UpdateAnswerCommand(data));
                if (answer is null)
                {
                    _response.Message = "An error occured while updating answer";
                    return BadRequest(_response);
                }

                _response.IsSuccess = true;
                _response.Result = answer;
                Log.Information($"Answer updated successfully. Id=\"{answer.Id}\" ");
                return CreatedAtRoute(nameof(GetAnswer), new { id = answer.Id }, _response);
            });
        }
    }
}