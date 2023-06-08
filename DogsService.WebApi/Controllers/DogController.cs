using AutoMapper;
using DogsService.Application.Dogs.Commands.CreateDog;
using DogsService.Application.Dogs.Commands.DeleteCommand;
using DogsService.Application.Dogs.Commands.UpdateDog;
using DogsService.Application.Dogs.Queries.GetDogDetails;
using DogsService.Application.Dogs.Queries.GetDogList;
using DogsService.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogsService.WebApi.Controllers
{
    public class DogController : BaseController
    {
        private readonly IMapper _mapper;

        public DogController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<DogListVm>> GetAll()
        {
            var query = new GetDogListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<DogDetailsVm>> Get(Guid id)
        {
            var query = new GetDogDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDogDto createDogDto)
        {
            var command = _mapper.Map<CreateDogCommand>(createDogDto);
            command.UserId = UserId;
            var dogId = await Mediator.Send(command);
            return Ok(dogId);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateDogDto updateDogDto)
        {
            var command = _mapper.Map<UpdateDogCommand>(updateDogDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDogCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
