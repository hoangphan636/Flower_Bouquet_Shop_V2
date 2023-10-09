using BusinessObject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerBouquet.Controllers
{
    
    public class FlowerBouquetController : Controller
    {
       


        public IActionResult Index()
        {
            string au = HttpContext.Session.GetString("token");
            if(au != null)
            {
                return View();

            }
          return RedirectToAction("Index", "Login");
        }
        public ActionResult Logout()
        {
            // Xóa token khỏi ứng dụng client, ví dụ: xóa cookie chứa token
          
            HttpContext.Session.Clear();
            // Chuyển hướng đến trang đăng nhập hoặc trang chủ
            return RedirectToAction("Index", "Login"); // Thay thế "Login" và "Account" bằng tên Action và Controller tương ứng của trang đăng nhập trong ứng dụng của bạn
        }

        public IActionResult Edit(int id)
        {
            // Find the flower bouquet by its ID


            //if (flowerBouquet == null)
            //{
            //    return NotFound(); // Flower bouquet not found
            //}

            return View();
        }
        //[HttpPost]
        //public IActionResult Edit(FlowerBouquet flowerBouquet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _dbContext.Entry(flowerBouquet).State = EntityState.Modified;
        //        _dbContext.SaveChanges();

        //        return RedirectToAction("Index"); // Redirect to the product list
        //    }

        //    // If the model state is not valid, return the edit view with the invalid model
        //    return View(flowerBouquet);
        //}



    }
}
