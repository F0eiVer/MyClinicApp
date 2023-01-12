using MyClinicApp.Domain.Classes;
using MyClinicApp.Domain.Response;
using MyClinicApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinicApp.DAL.Repositories;
using MyClinicApp.DAL.Interfaces;
using MyClinicApp.Domain.Enum;

namespace MyClinicApp.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRespository;

        public UserService(IUserRepository _userRepository)
        {
            userRespository = _userRepository;
        }

        public async Task<IBaseResponse<User>> Create(User entity)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                if (entity == null)
                {
                    baseResponse.Description = "There is no parameter for creating a user.";
                    baseResponse.StatusCode = StatusCode.DoesNotHaveImpl;

                    return baseResponse;
                }
                var res = await userRespository.Create(entity);

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[Create] : {ex.Message}",
                };
            }
        }

        public async Task<IBaseResponse<User>> Create(UserParams userParams)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                if (userParams == null)
                {
                    baseResponse.Description = "There is no parameter for creating a user.";
                    baseResponse.StatusCode = StatusCode.DoesNotHaveImpl;

                    return baseResponse;
                }
                var res = await userRespository.Create(userParams);

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[Create] : {ex.Message}",
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(User entity)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                if (entity == null)
                {
                    baseResponse.Description = "No user is specified for deletion.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetUser;
                    return baseResponse;
                }
                var res = await userRespository.Delete(entity);
                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Delete] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<User>> Get(ulong id)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                var res = await userRespository.Get(id); //null
                if(res == null)
                {
                    baseResponse.Description = "The user was not found.";
                    baseResponse.StatusCode = StatusCode.DoesNotFind;
                    return baseResponse;
                }

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[Get] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<User>> GetUserByLogin(string login)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                var user = await userRespository.GetUserByLogin(login);
                if (login == string.Empty)
                {
                    baseResponse.Description = "The user's login was not set.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetLogin;
                    return baseResponse;
                }
                else if (user == null)
                {
                    baseResponse.Description = "No user with this login was found.";
                    baseResponse.StatusCode = StatusCode.DoesNotFind;
                    return baseResponse;
                }

                baseResponse.Data = user;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[GetUserByLogin] : {ex.Message}",
                };
            }
        }

        public async Task<IBaseResponse<bool>> HaveUserByLoginAndPassword(string login, string password)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                if (login == string.Empty)
                {
                    baseResponse.Description = "The user's login was not set.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetLogin;
                    return baseResponse;
                }
                else if (password == string.Empty)
                {
                    baseResponse.Description = "The user's password was not set.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetPassword;
                    return baseResponse;
                }

                var have = await userRespository.HaveUserByLoginAndPassword(login, password);

                baseResponse.Data = have;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[HaveUserByLoginAndPassword] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<User>>> GetUsers()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            try
            {
                var users = await userRespository.Select();
                if (users.Count == 0)
                {
                    baseResponse.Description = "There are no users in the database.";
                    //Possible 404 code in the future;
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = users;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<User>>()
                {
                    Description = $"[GetUsers] : {ex.Message}"
                };
            }
        }

        
    }
}
