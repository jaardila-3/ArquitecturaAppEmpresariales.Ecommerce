using ArquitecturaAppEmpresariales.Ecommerce.Application.DTO;
using ArquitecturaAppEmpresariales.Ecommerce.Application.Interface;
using ArquitecturaAppEmpresariales.Ecommerce.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerApplication _customerApplication;

        public CustomersController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        #region métodos Sincronos
        /// <summary>
        /// Método para insertar un cliente de manera sincrona en el aplicativo
        /// </summary>
        /// <param name="customersDto">Estructura datos del cliente</param>
        /// <returns>Una estructura de respuesta o un mensaje</returns>
        /// <remarks>
        /// Sample request: Campos mínimos obligatorios
        ///
        ///     POST
        ///     {
        ///        "customerId": "strin", (max 5 characters)
        ///        "companyName": "string",
        ///     }
        /// </remarks>
        /// <response code="200"> Retorna la siguiente estructura.</response>
        /// <response code="400">Return: Message Exception.</response>
        [HttpPost("Insert")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Insert([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null) return BadRequest();

            var response = _customerApplication.Insert(customersDto);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null) return BadRequest();

            var response = _customerApplication.Update(customersDto);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customerApplication.Delete(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customerApplication.Get(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _customerApplication.GetAll();
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region "Métodos Asincronos"

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsincrono([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();
            var response = await _customerApplication.InsertAsync(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsincrono([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();
            var response = await _customerApplication.UpdateAsync(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteAsync/{customerId}")]
        public async Task<IActionResult> DeleteAsincrono(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = await _customerApplication.DeleteAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAsync/{customerId}")]
        public async Task<IActionResult> GetAsincrono(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = await _customerApplication.GetAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsincrono()
        {
            var response = await _customerApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
