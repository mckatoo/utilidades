using System.ComponentModel.DataAnnotations;
using Utilidades.Domain.Dtos;

namespace Utilidades.Domain.Users {
    public class TypeStorer {
        private readonly IRepository<UsersType> _typeRepository;

        public TypeStorer (IRepository<UsersType> typeRepository) {
            _typeRepository = typeRepository;
        }

        public void Store (TypeDto dto) {
            var type = _typeRepository.GetById (dto.Id);
            if (type == null) {
                type = new UsersType(dto.Type, dto.Level, dto.Description);
                _typeRepository.Save (type);
            } else {
                type.Update (dto.Type, dto.Level, dto.Description);
            }
        }

    }
}