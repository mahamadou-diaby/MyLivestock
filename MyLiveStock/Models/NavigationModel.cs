using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLiveStock.Models
{
    public class NavigationModel
    {
        private readonly string _url;

        public NavigationModel(string currentURL)
        {
            _url = currentURL.ToLower();
        }

        public string GetCssClassIfHomeSelected()
        {
            return _url == "/" ? "active" : "";
        }

        public string GetGroupCssClassIfSelected(string url)
        {
            return _url.ToLower().Contains(url.ToLower()) ? "active" : "";
        }

        public string GetCssClassIfSelected(string url)
        {
            return _url.ToLower() == url.ToLower() ? "active" : "";
        }
    }
}