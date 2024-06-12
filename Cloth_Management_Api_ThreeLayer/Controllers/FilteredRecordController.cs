using Ct.BAL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloth_Management_Api_ThreeLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilteredRecordController : ControllerBase
    {
        private readonly IFilterRecordService _filterRecordService;
        public FilteredRecordController(IFilterRecordService filterRecordService)
        {
            _filterRecordService = filterRecordService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetClothByBrandId/{id}")]

        public IActionResult GetClothByBrandId(int id)
        {
            try { 
            
            var cloths = _filterRecordService.GetClothByBrandId(id);
            return Ok(cloths);
            }
            catch (Exception)
            {
                return BadRequest("cloths of this brand is not found");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetClothByCategoryId/{id}")]

        public IActionResult GetClothByCategoryId(int id)
        {
            try
            {
                var cloths = _filterRecordService.GetClothByCatId(id);
                return Ok(cloths);
            }
            catch (Exception)
            {
                return BadRequest("cloths of this Category is not found");
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetByDate/{datetime:datetime}")]

        public IActionResult GetByDate(DateTime datetime)
        {
            try
            {
                var records = _filterRecordService.GetByDate(datetime);
                return Ok(records);
            }
            catch (Exception)
            {
                return BadRequest("records of this date is not found");
            }
        }
    }
}
