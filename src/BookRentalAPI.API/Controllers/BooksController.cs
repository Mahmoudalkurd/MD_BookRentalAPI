using BookRentalAPI.Application.Features.Books.Commands;
using BookRentalAPI.Application.Features.Books.Queries;
using BookRentalAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            return HandleResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery { Id = id });
            return HandleResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand { Id = id });
            return HandleResult(result);
        }

        private IActionResult HandleResult<T>(OperationResult<T> result)
        {
            if (result == null) return NotFound();
            if (result.Success) return Ok(result.Data);
            return StatusCode(result.StatusCode, result.ErrorMessage);
        }
    }
}