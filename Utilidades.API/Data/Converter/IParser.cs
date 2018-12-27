using System.Collections.Generic;

namespace Utilidades.API.Data.Converter {
    public interface IParser<Origin, Destiny> {
        Destiny Parse (Origin origin);
        List<Destiny> ParseList (IList<Origin> origin);
    }
}