using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product_Catalog_Web_Application.Core.Interfaces;
using Product_Catalog_Web_Application.Core.ViewModels;
using System.Security.Claims;

namespace Product_Catalog_Web_Application.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,
            ICategoryService categoryService,
            IAdminRepository adminRepository,
            IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = (await _productService.GetAllAsync()).Data;
            return View(allProducts);
        }

        public async Task<IActionResult> Create()
        {
            var categories = (await _categoryService.GetAllAsync()).Data;
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            if(ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var adminId = (await _adminRepository.GetByApplicationUserIdAsync(userId)).Id;
                var result = await _productService.AddAsync(productCreateVM, adminId);
                if (!result.Success)
                    return BadRequest(result.Message);

                return RedirectToAction("Index");
            }

            return View(productCreateVM);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (!result.Success)
                return NotFound(result.Message);
            return View(result.Data);
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _productService.GetForUpdate(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var categories = (await _categoryService.GetAllAsync()).Data;
            ViewBag.Categories = categories;

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute]int id, ProductUpdateVM productUpdateVM)
        {
            var result = await _productService.Update(id, productUpdateVM);
            if (!result.Success)
                return BadRequest(result.Message);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return RedirectToAction("Index");
        }
    }
}
