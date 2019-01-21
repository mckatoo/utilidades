using Utilidades.ApplicationCore.Model;

namespace Utilidades.Infrastructure.Business {
    public interface ILoginBusiness {
        object FindByLogin (LoginVO login);
    }
}