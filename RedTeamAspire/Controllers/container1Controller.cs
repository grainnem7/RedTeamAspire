

namespace RedTeamAspire.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RedTeamAspire.Models;
    using RedTeamAspire.Services;

    public class container1Controller : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;
        public container1Controller(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _cosmosDbService.GetItemsAsync("SELECT * FROM c"));
        }

        [ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Pond_Key,Start_Date,Intial_Population,Intial_Average_Weight, Estimated_End_Date,Estimated_Harvest_Average_Weight,Estimated_Survival, Food_Type")] container1 item)
        {
            if (ModelState.IsValid)
            {
                item.Pond_Key = Guid.NewGuid().ToString();
                await _cosmosDbService.AddItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind("Pond_Key,Start_Date,Intial_Population,Intial_Average_Weight, Estimated_End_Date,Estimated_Harvest_Average_Weight,Estimated_Survival, Food_Type")] container1 item)
        {
            if (ModelState.IsValid)
            {
                await _cosmosDbService.UpdateItemAsync(item.Pond_Key, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            container1 item = await _cosmosDbService.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            container1 item = await _cosmosDbService.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind("Pond_Key")] string id)
        {
            await _cosmosDbService.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            return View(await _cosmosDbService.GetItemAsync(id));
        }
    }
}
