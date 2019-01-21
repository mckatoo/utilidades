using System.Collections.Generic;

namespace Utilidades.ApplicationCore.Data.Converter {
    public interface IParser<Origin, Destiny> {
        Destiny Parse (Origin origin);
        List<Destiny> ParseList (IList<Origin> origin);
    }
}