using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string RestaurantsEndpoint = $"{Prefix}/restaurants";
        public static readonly string MenuItemsEndpoint = $"{Prefix}/menuitems";
        public static readonly string MenusEndpoint = $"{Prefix}/menus";
    }
}
