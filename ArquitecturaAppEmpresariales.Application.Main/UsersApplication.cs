using ArquitecturaAppEmpresariales.Application.Validator;
using ArquitecturaAppEmpresariales.Ecommerce.Application.DTO;
using ArquitecturaAppEmpresariales.Ecommerce.Application.Interface;
using ArquitecturaAppEmpresariales.Ecommerce.Domain.Interface;
using ArquitecturaAppEmpresariales.Ecommerce.Transversal.Common;
using AutoMapper;

namespace ArquitecturaAppEmpresariales.Application.Main;

public class UsersApplication : IUsersApplication
{
    private readonly IUsersDomain _usersDomain;
    private readonly IMapper _mapper;
    private readonly UsersDtoValidator _usersDtoValidator;

    public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UsersDtoValidator usersDtoValidator)
    {
        _usersDomain = usersDomain;
        _mapper = mapper;
        _usersDtoValidator = usersDtoValidator;
    }

    public Response<UsersDto> Authenticate(string username, string password)
    {
        var response = new Response<UsersDto>();
        var validation = _usersDtoValidator.Validate(new UsersDto() { UserName= username, Password = password });
        if (!validation.IsValid)
        {
            response.Message = "Errores de validación";
            response.Errors = validation.Errors;
            return response;
        }
        try
        {
            var user = _usersDomain.Authenticate(username, password);
            response.Data = _mapper.Map<UsersDto>(user);
            response.IsSuccess = true;
            response.Message = "Autenticación Exitosa!!!";

        }
        catch (InvalidOperationException)
        {
            //no se mapeo (Mapper) porque el usuario no existe (null) pero si realizo la consulta en bd correctamente
            response.IsSuccess = true;
            response.Message = "Usuario no existe!!!";
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }
        return response;
    }
}
