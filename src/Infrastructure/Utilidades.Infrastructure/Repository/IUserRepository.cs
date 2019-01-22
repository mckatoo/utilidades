using Utilidades.ApplicationCore.Entity;

namespace Utilidades.Infrastructure.Repository {
    public interface IUserRepository {
        Users FindByLogin (string login);
    }
}