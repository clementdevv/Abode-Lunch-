using AbodeLunch.Application.Authentication.Commands.Register;
using AbodeLunch.Application.Authentication.Common;
using AbodeLunch.Application.Authentication.Queries.Login;
using AbodeLunch.Contracts.Authentication;
using Mapster;

namespace AbodeLunch.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            // .Map(dest => dest.Token, scr => scr.Token)
            .Map(dest => dest, src => src.User);
        }
    }
}