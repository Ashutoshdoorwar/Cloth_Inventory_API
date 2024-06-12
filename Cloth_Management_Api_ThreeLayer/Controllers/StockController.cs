using Ct.Bal.InterfacesBal;
using Ct.common.EmailModel;
using Ct.common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloth_Management_Api_ThreeLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllStock")]
        public IActionResult GetAllStock()
        {
            var stock = _stockService.GetAllStock();

            return Ok(stock);
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteStock/{id}")]
        public IActionResult DeleteStock(int id)
        {
            try
            {
                _stockService.DeleteStock(id);
                return Ok("Stock deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(404, "stock id not found ");
            }
           
        }
        [Authorize]
        [HttpPost]
        [Route("AddStock")]
        public IActionResult AddStock(StockModel stockModel)
        {
            try
            {
                var mailrequest = new MailRequest();
                mailrequest.ToEmail = EmailTemplate.ToEmail;
                mailrequest.Subject = EmailTemplate.Subject.Replace("@", "Stock");
                mailrequest.Body = $"<h1>{EmailTemplate.Body.Replace("@", "Stock")}</h1>";
                _stockService.AddStock(stockModel);
                return Ok("Stock Added Sucessfully");
            }
            catch (Exception)
            {
                return BadRequest("Enter VALID CLOTH ID and this cloth is not present ,PLEASE ADD YOUR PRODUCT FIRST");
            }
        }

       [Authorize]
        [HttpPut]
        [Route("UpdateStock")]
        public IActionResult UpdateStock(StockDto stockDto)
        {
            try
            {
                _stockService.UpdateStock(stockDto);
                return Ok("Stock updated succesfully");
            }
            catch (ArgumentException)
            {
                return BadRequest("stock not found");
            }
            catch (Exception)
            {
                return BadRequest("cloth id not found");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetStockById/{id}")]
        public IActionResult GetStockById(int id)
        {
            try
            {
                var stock = _stockService.GetStockById(id);
                return Ok(stock);
            }
            catch (Exception)
            {
                return BadRequest("Enter valid stock id");
            }
        }
    }
}
