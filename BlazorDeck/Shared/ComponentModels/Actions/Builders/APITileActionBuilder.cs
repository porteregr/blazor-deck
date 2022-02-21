using System;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;

namespace BlazorDeck.Shared.ComponentModels.Actions.Builders
{
    public class APITileActionBuilder : ITileActionBuilder, IBuilderFor<APITileAction>
    {
        [Required]
        [Display(Name = "Route")]
        public string Route { get; protected set; }
        [Required]
        [Display(Name = "Http Method")]
        public HttpMethods Method { get; protected set; }
        [Display(Name = "Post Request content")]
        public object Content { get; protected set; }

        public APITileActionBuilder()
        {

        }

        public APITileActionBuilder(APITileAction aPITileAction)
        {
            Route = aPITileAction.Route;
            Method = (HttpMethods)Enum.Parse(typeof(HttpMethods),aPITileAction.Method.Method);
            Content = aPITileAction.Content;
        }
        public ITileAction BuildTileAction()
        {
            return new APITileAction(Route, new HttpMethod(Method.ToString()), Content);
        }
    }

    public enum HttpMethods
    {
        GET,
        PUT,
        POST,
        PATCH,
        DELETE,
        HEAD,
        OPTIONS
    }
}
