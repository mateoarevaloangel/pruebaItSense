using BackendPrueba.Models;
using BackendPrueba.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BackendPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetStatusAll()
        {
            try
            {
                return Ok(await statusRepository.GetStatusAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Status>> GetStatus(int id)
        {
            try
            {
                var result = await statusRepository.GetStatus(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Status>> CreateStatus(Status status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var createdStatus = await statusRepository.AddStatus(status);

                return CreatedAtAction(nameof(GetStatus),
                    new { id = createdStatus.StatusId }, createdStatus);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Status>> UpdateStatus(int id, Status status)
        {
            try
            {
                if (id != status.StatusId)
                    return BadRequest("Employee ID mismatch");

                var employeeToUpdate = await statusRepository.GetStatus(id);

                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                return await statusRepository.UpdateStatus(status);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Status>> DeleteEmployee(int id)
        {
            try
            {
                var productToDelete = await statusRepository.GetStatus(id);

                if (productToDelete == null)
                {
                    return NotFound($"status with Id = {id} not found");
                }

                statusRepository.DeleteStatus(id);
                return Ok(productToDelete);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
