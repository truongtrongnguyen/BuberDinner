using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Services.Authentication.Commands.Register;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Contacts.Authentication;
using Mapster;

namespace BuberDinner.Api.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationRespone>()
               // .Map(dest => dest.Token, src => src.Token)   --> same name no need mapping
                .Map(dest => dest, src => src.user); 
        }
    }
}
