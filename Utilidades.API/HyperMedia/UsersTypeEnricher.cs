using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;
using Utilidades.API.Data.VO;

namespace Utilidades.API.HyperMedia {
    public class UsersTypeEnricher : ObjectContentResponseEnricher<UsersTypeVO> {
        protected override Task EnrichModel (UsersTypeVO content, IUrlHelper urlHelper) {
            var path = "api/userstype/v1";
            var url = new { controller = path, id = content.Id };
            content.Links.Add (new HyperMediaLink () {
                Action = HttpActionVerb.GET,
                    Href = urlHelper.Link ("DefaultApi", url),
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add (new HyperMediaLink () {
                Action = HttpActionVerb.POST,
                    Href = urlHelper.Link ("DefaultApi", url),
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add (new HyperMediaLink () {
                Action = HttpActionVerb.PUT,
                    Href = urlHelper.Link ("DefaultApi", url),
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add (new HyperMediaLink () {
                Action = HttpActionVerb.DELETE,
                    Href = urlHelper.Link ("DefaultApi", url),
                    Rel = RelationType.self,
                    Type = "int"
            });
            return null;
        }
    }
}