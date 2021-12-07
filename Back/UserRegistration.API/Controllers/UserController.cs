using Microsoft.AspNetCore.Mvc;
using UserRegistration.Domain.Commands;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Handlers;
using UserRegistration.Domain.Repositories;
using UserRegistration.Infra.Contexts;

namespace UserRegistration.API.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<User>> Users([FromServices] IUserRepository repository)
        {
            return await repository.GetAllAsync();
        }

        [HttpGet("{id}")]        
        public async Task<User> Get([FromServices] IUserRepository repository, int id)
        {
            return await repository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> Post(
          [FromServices] DataContext context,
          [FromServices] UserHandler handler,
          [FromBody] AddUserCommand command)
        {
            try
            {
                var result = handler.Handle(command);

                if (result.Success)
                {
                    await context.SaveChangesAsync();
                    return Ok(result.Data);
                }

                return BadRequest(result.Error);
            }
            catch (Exception ex)
            {
                //TODO: logar erro
                return StatusCode(500, "Ocorreu um erro interno!");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Result>> Put(
          [FromServices] DataContext context,
          [FromServices] UserHandler handler,
          [FromBody] EditUserCommand command)
        {
            try
            {
                var result = handler.Handle(command);

                if (result.Success)
                {
                    await context.SaveChangesAsync();
                    return Ok(result.Data);
                }

                return BadRequest(result.Error);
            }
            catch (Exception ex)
            {
                //TODO: logar erro
                return StatusCode(500, "Ocorreu um erro interno!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> Delete(
        [FromServices] DataContext context,
        [FromServices] UserHandler handler,
        int id)
        {
            try
            {

                var result = handler.Handle(new DeleteUserCommand { Id = id});

                if (result.Success)
                {
                    await context.SaveChangesAsync();
                    return Ok();
                }

                return BadRequest(result.Error);
            }
            catch (Exception ex)
            {
                //TODO: logar erro
                return StatusCode(500, "Ocorreu um erro interno!");
            }
        }
    }
}
