
using Microsoft.AspNetCore.Mvc;
using urlshorterner.Services;

namespace urlshorterner.Controllers{

    public class Retrive : Controller {
        

    private readonly URLMappingService _urlMappingService;

    


        public Retrive(URLMappingService urlMappingService){
            _urlMappingService = urlMappingService;
        }

    public ActionResult Index(string shortUrl){
        var longURL = _urlMappingService.ObtainLongUrl(shortUrl);
        return Content($"The shortUrl {shortUrl} maps {longURL}");
    }


    }

public class Create : Controller
{
    private readonly URLMappingService _urlMappingService;

    public Create(URLMappingService urlMappingService) // <-- Incorrect constructor name
    {
        _urlMappingService = urlMappingService;
    }

    public ActionResult Index(string longUrl)
    {
        var shortUrl = _urlMappingService.GenerateShortenedURL();
        return Content($"The longUrl {longUrl} mapsto {shortUrl}");
    }
}



}

