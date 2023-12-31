using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;
using WebApi.UserOperations.CreateToken;
using WebApi.UserOperations.CreateUser;
using static WebApi.UserOperations.CreateToken.CreateTokenCommand;
using static WebApi.UserOperations.CreateUser.CreateUserCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]

    public class UserController: ControllerBase
    {
        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public UserController(ProductsDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            
                command.Model = newUser;
               
                command.Handle();
                
                return Ok();
        }

        [HttpPost("connect/token")]
         public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
         {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            
                command.Model = login;
               
                var token = command.Handle();
                
                return token;
         }
    }
}