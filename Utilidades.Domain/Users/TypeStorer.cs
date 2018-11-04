using System.ComponentModel.DataAnnotations;
using Utilidades.Domain.Dtos;

namespace Utilidades.Domain.Users {
    public class TypeStorer {
        private readonly IRepository<UsersType> _typeRepository;

        public TypeStorer (IRepository<UsersType> typeRepository) {
            _typeRepository = typeRepository;
        }

        public void Store (UserDto dto) {
            var type = _typeRepository.GetById (dto.UsersTypeId);
            if (type == null) {
                type = new Users (dto.Name, dto.Email, dto.Password, dto.RememberToken, type);
                _userRepository.Save (type);
            } else {
                type.Update (dto.Name, dto.Email, dto.Password, dto.RememberToken, type);
            }
        }

    }
}