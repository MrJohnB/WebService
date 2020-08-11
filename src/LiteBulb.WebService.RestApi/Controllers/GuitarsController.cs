using System.Threading.Tasks;
using LiteBulb.WebService.Database;
using LiteBulb.WebService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiteBulb.WebService.RestApi.Controllers
{
	/// <summary>
	/// ActivitiesController controller class.
	/// Note: Route Constraints (https://stackoverflow.com/questions/44694658/string-route-constraint)
	/// TODO: Make DTO's for this?
	/// </summary>
	//[Route("api/[controller]")] TODO: make it all lowercase?
	[Route("api/v1/guitars")]
	[ApiController]
	public class GuitarsController : ControllerBase
	{
		private readonly ILogger<GuitarsController> _logger;
		private readonly DatabaseContext _databaseContext;

		/// <summary>
		/// GuitarsController constructor.
		/// </summary>
		/// <param name="logger">ILogger instance</param>
		/// <param name="databaseContext">DatabaseContext instance</param>
		public GuitarsController(ILogger<GuitarsController> logger, DatabaseContext databaseContext)
		{
			_logger = logger;
			_databaseContext = databaseContext;
		}

		/// <summary>
		/// Get all details about a specific Guitar object from the database.
		/// Note 1: Can check this endpoint to get all details about an Guitar.
		/// Note 2: Id is a int (could make it a string).
		/// </summary>
		/// <param name="id">Guitar id</param>
		/// <returns>Guitar object for a given id</returns>
		// GET: api/v1/guitars/5
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetGuitarByIdAsync([FromRoute] int id)
		{
			_logger.LogInformation($"GetGuitarByIdAsync() method start with Guitar id '{id}'.");

			// Get Guitar by id
			var getResult = await Task.FromResult(_databaseContext.Select(id));

			if (getResult == null)
			{
				_logger.LogError($"Error in GetGuitarByIdAsync() method.  Cannot fetch Guitar info.  Response from DatabaseContext Select() method was null.");
				return NotFound($"Guitar with id: '{id}' was not found.");
			}

			_logger.LogInformation($"GetGuitarByIdAsync() method end with Guitar id '{id}'.");

			return Ok(getResult);
		}

		/// <summary>
		/// Adds a new Guitar object to the database.
		/// </summary>
		/// <param name="guitar">Guitar object to add</param>
		/// <returns>Location of resource for newly added Guitar object with its Id (if POST was successful)</returns>
		// POST api/v1/guitars
		[HttpPost()]
		public async Task<IActionResult> CreateGuitarAsync([FromBody] Guitar guitar)
		{
			_logger.LogInformation("CreateGuitarAsync() method start.");

			// Add Guitar object to the database
			var addResult = await Task.FromResult(_databaseContext.Insert(guitar));

			if (addResult == null)
			{
				_logger.LogError($"Error in CreateGuitarAsync() method.  Guitar object may not have been added to database.  Response from DatabaseContext Insert() method was null.");
				return NotFound("Error.  Guitar object may not have been added to database.");
			}

			var id = addResult.Id;

			_logger.LogInformation($"CreateGuitarAsync() method end with Guitar id '{id}'.");

			var actionResult = CreatedAtAction(
				actionName: nameof(GetGuitarByIdAsync), // ASP.NET Core 3.0 bug: https://stackoverflow.com/questions/59288259/asp-net-core-3-0-createdataction-returns-no-route-matches-the-supplied-values
														//controllerName: ControllerContext.ActionDescriptor.ControllerName,
				routeValues: new { id },
				value: addResult);

			return actionResult;
		}

		/// <summary>
		/// Remove a Guitar object from the database.
		/// </summary>
		/// <param name="id">Guitar id</param>
		/// <returns>200 OK response code and boolean of whether DELETE was successful</returns>
		// DELETE api/v1/guitars/5
		[HttpDelete("{id:int}")]
		public IActionResult DeleteGuitarById([FromRoute]int id)
		{
			_logger.LogInformation($"DeleteGuitarById() method start with Guitar id '{id}'.");

			// Delete Guitar object from the database
			var deleteResult = _databaseContext.Delete(id);

			if (deleteResult == false)
			{
				_logger.LogError($"Error in DeleteGuitarById() method.  Guitar was not deleted.  Guitar with id: '{id}' was not found.  Response from DatabaseContext Delete() method was false.");
				return NotFound($"Guitar with id: '{id}' was not found.  Guitar was not deleted.");
			}

			// Create response message
			var responseMessage = deleteResult ? "Delete successful" : "Delete unsuccessful";

			_logger.LogInformation($"DeleteGuitarById() method end with Guitar object id '{id}'.");

			return Ok(responseMessage);
		}
	}
}
