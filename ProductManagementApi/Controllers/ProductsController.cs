using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagementApplication.Products.Commands;
using ProductManagementApplication.Products.Commands.Create;
using ProductManagementApplication.Products.Queries;
using ProductManagementDomain.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProductManagementApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    #region Propeities
    private readonly IValidator<CreateProductCommand> _createValidator;
    private readonly IValidator<UpdateProductCommand> _updateValidator;
    private readonly IValidator<DeleteProductCommand> _deleteValidator;
    private readonly IMediator _mediator;
    #endregion

    public ProductsController(IMediator mediator, IValidator<CreateProductCommand> createValidator, IValidator<UpdateProductCommand> updateValidator)
    {
        _mediator = mediator;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var query = new GetAllProductsQuery();
        var products = await _mediator.Send(query);

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var query = new GetProductByIdQuery(id);
        var product = await _mediator.Send(query);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        var validationResult = await _createValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {

            return BadRequest(validationResult.Errors);
        }

        var productId = await _mediator.Send(command);
        return Ok(productId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduclt(int id, [FromBody] UpdateProductDto productDto)
    {

        var query = new IsProductExistsQuery(id);
        var queryResult = await _mediator.Send(query);
        if (!queryResult)

            return BadRequest("Product ID mismatch.");
        var command = new UpdateProductCommand(productDto);

        // IF product is exists:
        // Check the UPD
        var validationResult = await _updateValidator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            var errors = new  List<string>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(error.ErrorMessage);
            }
            return BadRequest(errors);
        }

        var result = await _mediator.Send(command);

        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        // Check if the product exists
        var query = new IsProductExistsQuery(id);
        var productExists = await _mediator.Send(query);

        if (!productExists)
        {
            return NotFound("Product not found.");
        }

        var command = new DeleteProductCommand(id);
        var result = await _mediator.Send(command);

        if (!result)
        {
            return NotFound();
        }

        return Ok("Product deleted successfully.");
    }

}
