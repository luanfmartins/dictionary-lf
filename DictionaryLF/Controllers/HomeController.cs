using DictionaryLF.Services;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryLF.Controllers
{
    public class HomeController : Controller
    {
        private readonly DictionaryService _service;
        
        public HomeController(DictionaryService service) {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string word)
        {
            var result = await _service.GetWordAsync(word);
            return View("Index", result);
        }

    }
}
