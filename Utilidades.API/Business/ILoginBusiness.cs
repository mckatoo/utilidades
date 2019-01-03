using Utilidades.API.Model;

namespace Utilidades.API.Business {
    public interface ILoginBusiness {
        object FindByLogin (LoginVO login);
    }
}