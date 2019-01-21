using Utilidades.ApplicationCore.Model;

namespace Utilidades.Infrastructure.Repository {
    public interface IUserRepository {
        User FindByLogin (string login);
    }
}