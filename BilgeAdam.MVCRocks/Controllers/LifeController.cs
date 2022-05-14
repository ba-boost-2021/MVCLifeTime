using BilgeAdam.MVCRocks.Models;
using BilgeAdam.Services;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.MVCRocks.Controllers
{
    public class LifeController : Controller
    {
        private readonly SingletonService singletonService;

        public LifeController(SingletonService singletonService)
        {
            this.singletonService = singletonService;
            this.singletonService.Count++;
        }
        public IActionResult CustomServices()
        {
            var transientService1 = HttpContext.RequestServices.GetService<TransientService>(); //Container'dan servis çağır
            var transientService2 = HttpContext.RequestServices.GetService<TransientService>();

            transientService1.Count++;
            transientService1.Count++;
            transientService2.Count++;

            var scopedService1 = HttpContext.RequestServices.GetService<ScopedService>();
            var scopedService2 = HttpContext.RequestServices.GetService<ScopedService>();
            
            scopedService1.Count++;
            scopedService1.Count++;
            scopedService2.Count++;



            var result = new List<CustomService>();
            result.Add(new CustomService
            {
                Name = nameof(SingletonService),
                Count = singletonService.Count,
                Created = singletonService.Created,
                Code = singletonService.GetHashCode()
            });
            result.Add(new CustomService
            {
                Name = nameof(ScopedService),
                Count = scopedService1.Count,
                Created = scopedService1.Created,
                Code = scopedService1.GetHashCode()
            });
            result.Add(new CustomService
            {
                Name = nameof(ScopedService),
                Count = scopedService2.Count,
                Created = scopedService2.Created,
                Code = scopedService2.GetHashCode()
            });
            result.Add(new CustomService
            {
                Name = nameof(TransientService),
                Count = transientService1.Count,
                Created = transientService1.Created,
                Code = transientService1.GetHashCode()
            });
            result.Add(new CustomService
            {
                Name = nameof(TransientService),
                Count = transientService2.Count,
                Created = transientService2.Created,
                Code = transientService2.GetHashCode()
            });
            return View(result);
        }
    }
}
