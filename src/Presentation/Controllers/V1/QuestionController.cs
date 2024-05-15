using MediatR;
using SO00000010.Application.Commands.Question;
using SO00000010.Application.Queries.Question;
using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Presentation.Controllers.V1
{
    public class QuestionController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                IEnumerable<QuestionModel> Questions = await _mediator.Send(new GetQuestionsQuery());
                _response.IsSuccess = true;
                _response.Result = Questions;

                return Ok(_response);
            });
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetQuestion))]
        public async Task<IActionResult> GetQuestion(Guid id, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                QuestionModel? question = await _mediator.Send(new GetQuestionByIdQuery(id));
                if (question is null)
                {
                    _response.Message = $"Question with id=\"{id}\" not found!";
                    return NotFound(_response);
                }

                _response.IsSuccess = true;
                _response.Result = question;

                return Ok(_response);
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateQuestionModel data, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                QuestionModel? question = await _mediator.Send(new CreateQuestionCommand(data));
                if (question is null)
                {
                    _response.Message = "An error occured while creating question";
                    return BadRequest(_response);
                }

                _response.IsSuccess = true;
                _response.Result = question;
                Log.Information("Question created successfully.");
                return CreatedAtRoute(nameof(GetQuestion), new { id = question.Id }, _response);
            });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateQuestionModel data, CancellationToken cancellationToken)
        {
            return await HandleExceptionAsync(async () =>
            {
                QuestionModel? question = await _mediator.Send(new CreateQuestionCommand(data));
                if (question is null)
                {
                    _response.Message = "An error occured while updating question";
                    return BadRequest(_response);
                }

                _response.IsSuccess = true;
                _response.Result = question;
                Log.Information($"Question updated successfully. Id=\"{question.Id}\" ");
                return CreatedAtRoute(nameof(GetQuestion), new { id = question.Id }, _response);
            });
        }
    }
}