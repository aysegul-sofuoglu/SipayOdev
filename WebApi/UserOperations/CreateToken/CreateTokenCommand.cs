using AutoMapper;
using WebApi.DBOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.UserOperations.CreateToken{

    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }

        private readonly ProductsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand(ProductsDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper; 
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x=>x.Email==Model.Email && x.Password==Model.Password);

            if(user is not null){
                //create token
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();

                return token;
            }
            else
                throw new InvalidOperationException("Invalid email or password .");
            
        }

        public class CreateTokenModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}