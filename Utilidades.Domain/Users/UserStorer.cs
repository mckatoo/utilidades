using System.ComponentModel.DataAnnotations;
using Utilidades.Domain.Dtos;

namespace Utilidades.Domain.Users {
    public class UserStorer {
        private readonly IRepository<Users> _userRepository;
        private readonly IRepository<UsersType> _typeRepository;

        public UserStorer (IRepository<Users> userRepository, IRepository<UsersType> typeRepository) {
            _userRepository = userRepository;
            _typeRepository = typeRepository;
        }

        public void Store (UserDto dto) {
            var type = _typeRepository.GetById (dto.UsersTypeId);
            var user = _userRepository.GetById (dto.Id);
            if (user == null) {
                user = new Users (dto.Name, dto.Email, dto.Password, dto.RememberToken, type);
                _userRepository.Save (user);
            } else {
                user.Update (dto.Name, dto.Email, dto.Password, dto.RememberToken, type);
            }
        }

    }
}