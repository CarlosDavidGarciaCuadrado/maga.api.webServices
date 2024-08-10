using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;
using maga.accessData.mappers;
using maga.accessData.repositories;
using maga.aplication.contract;
using maga.aplication.contract.Security;
using maga.Bussines;
using maga.commons.util;

namespace maga.aplication
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccessorData _accessorData;
        private readonly IVerifyCodeRepository _verifyCodeRepository;
        private readonly ISendEmail _sendEmail;
        public UserService(IUserRepository userRepository, IAccessorData accessorData, IVerifyCodeRepository verifyCodeRepository, ISendEmail sendEmail)
        { 
            _userRepository = userRepository; 
            _accessorData = accessorData;
            _verifyCodeRepository = verifyCodeRepository;
            _sendEmail = sendEmail;
        }
        public async Task<UserToShow?> Add(UserToAdd user)
        {
            if (user.id > 0 && await _userRepository.Exists(user.id))
            {
                throw GenericExceptionHelper.GenerateException("El usuario ya se encuentra registrado.");
            }
            if (await _userRepository.ExistsEmail(user.email))
            {
                throw GenericExceptionHelper.GenerateException("Ya existe un usuario registrado con este correo.");
            }
            if (!await verifyCode(user.email, user.verificationCode))
            {
                throw GenericExceptionHelper.GenerateException("El código de verificación no coincide.");
            }
            UserEntity userEntity = UserMapper.MapperDtoToEntity(user);
            userEntity.creationDate = DateTime.Now;
            userEntity.updatedDate = DateTime.Now;
            userEntity.state = 1;
            return GetUserToShow(await _userRepository.Add(userEntity));
        }

        public async Task<UserToShow?> Update(UserToShow user)
        {

            if (user.id > 0 && await _userRepository.Exists(user.id))
            {
                return GetUserToShow(await _userRepository.Update(UserMapper.MapperDtoToEntity(await _userRepository.Get(user.id), user)));
            }
            throw GenericExceptionHelper.GenerateException("No se puede actualizar el registro. El usuario no existe o no está activo.");
        }

        public async Task<UserToShow?> DeleteAsync(ulong id)
        {
            return GetUserToShow(await _userRepository.DeleteAsync(id));
        }

        public async Task<UserToShow?> Get(ulong id)
        {
            return UserMapper.MapperEntityToUserToShow(await _userRepository.Get(id));
        }

        public async Task<UserEntity?> GetUserCurrentLogin()
        {
            return await _userRepository.Get(Validations.GetUlongFromString(_accessorData.GetUserId(), 0));
        }

        public UserToShow? GetUserToShow(UserEntity? entity) => UserMapper.MapperEntityToUserToShow(entity);

        public async Task<UserToShow?> UpdatePassword(RequestUpdatePassword request)
        {
            var user = await GetUserCurrentLogin();
            if(user != null && Encript.verifyBCrypt(user.password, request.password))
            {
                user.password = Encript.encriptBCrypt(request.passwordNew);
                return GetUserToShow(await _userRepository.Update(user));
            }
            throw GenericExceptionHelper.GenerateException("No se puede actualizar la contraseña. Verifique la contraseña actual.");
        }

        public async Task<string> SendCoderecoveryPassword(string email)
        {
            if (await _userRepository.ExistsEmail(email))
            {
                throw GenericExceptionHelper.GenerateException("No existe un usuario registrado con este correo.");
            }
            return await _sendEmail.VerifyEmail(email);
        }

        public async Task<string> RecoveryPassword(RequestRecoveryPassword request)
        {
            var user = await _userRepository.GetUserByEmail(request.email);
            if (user == null)
            {
                throw GenericExceptionHelper.GenerateException("No existe un usuario registrado con este correo.");
            }
            if (!await verifyCode(request.email, request.code))
            {
                throw GenericExceptionHelper.GenerateException("El código de verificación no coincide.");
            }
            user.password = Encript.encriptBCrypt(request.passwordNew);
            await _userRepository.Update(user);
            return "Se actualizó la contraseña. Por favor inicie sesión con su nueva contraseña.";
        }

        private async Task<bool> verifyCode(string email, string code)
        {
            VerifyCodeEntity? entity = await _verifyCodeRepository.Get(email);
            if(entity == null)
            {
                throw GenericExceptionHelper.GenerateException("No se ha enviado verificación a este correo. Por favor verifique");
            }
            if (entity.expirationDate < DateTime.Now)
            {
                await _verifyCodeRepository.DeleteAsync(email);
                throw GenericExceptionHelper.GenerateException("El código de verificación ya está vencido. Por favor inicie de nuevo.");
            }

            if(entity.code == code)
            {
                await _verifyCodeRepository.DeleteAsync(email);
                return true;
            }
            return false;
        }
    }
}
