using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Util;

namespace TodoApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase
  {
    private readonly IRepositoryWrapper _repositoryWrapper;
    public CustomerController(IRepositoryWrapper RW)
    {
      _repositoryWrapper = RW;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerResult>>> GetCustomers()
    {
      var customerItems = await _repositoryWrapper.Customer.ListCustomer();
      return Ok(customerItems);
    }
    [HttpGet("id")]
    public async Task<ActionResult<Customer>> Getcustomer(int id)
    {
      var customer = await _repositoryWrapper.Customer.FindByIDAsync(id);

      if (customer == null)
      {
        return NotFound();
      }
      return CreatedAtAction(nameof(Getcustomer), new { id = customer.CustomerId }, customer);
    }
    // [HttpPut("id")]
    // public async Task<IActionResult> PutCustomer(int id, CustomerRequest customerRequest)
    // {
    //   if (id != customerRequest.CustomerId)
    //   {
    //     return BadRequest();
    //   }
    //   Customer? objCustomer;
    //   try
    //   {
    //     objCustomer = await _repositoryWrapper.Customer.FindByIDAsync(id);
    //     if (objCustomer == null)
    //       throw new Exception("Invalid Customer ID");

    //     FileService.DeleteFileNameOnly("CustomerPhoto", id.ToString());
    //     FileService.MoveTempFile("CustomerPhoto", customer.CustomerId.ToString(), customer.CustomerPhoto);

    //     objCustomer.CustomerName = customer.CustomerName;
    //     await _repositoryWrapper.Customer.UpdateAsync(objCustomer);
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (!CustomerExists(id))
    //     {
    //       return NotFound();
    //     }
    //     else
    //     {
    //       throw;
    //     }
    //   }
    //   return NoContent();
    // }

    [HttpPut("{id}")]
    public async Task<ActionResult<Customer>> UpdateCustomer(int id, CustomerRequest customerRequest)
    {
      if (id != customerRequest.CustomerId)
      {
        return BadRequest();
      }

      var customer = await _repositoryWrapper.Customer.FindByIDAsync(id);
      if (customer == null)
      {
        return NotFound();
      }

      customer.CustomerName = customerRequest.CustomerName;
      customer.CustomerAddress = customerRequest.CustomerAddress;
      customer.CustomerTypeId = customerRequest.CustomerTypeId;
      customer.CustomerPhoto = customerRequest.CustomerPhoto;

      try
      {
        await _repositoryWrapper.Customer.UpdateAsync(customer);

        // ! EventLog
        await _repositoryWrapper.EventLog.Update(customer);

        // FileService.DeleteFileNameOnly("CustomerPhoto", id.ToString());
        // FileService.MoveTempFile("CustomerPhoto",
        //                          customer.CustomerId.ToString(),
        //                          customer.CustomerPhoto);
      }
      catch (DbUpdateConcurrencyException) when (!CustomerExists(id))
      {
        return NotFound();
      }

      // return NoContent();
      return CreatedAtAction(nameof(Getcustomer), new { id = customer.CustomerId }, customer);
    }

    [HttpPost("search/{term}")]
    public async Task<ActionResult<IEnumerable<CustomerResult>>> SearchCustomer(string customer)
    {
      var customerList = await _repositoryWrapper.Customer.SearchCustomer(customer);
      return Ok(customerList);
    }

    [HttpPost("searchcustomer/{filter}")]
    public async Task<List<CustomerSearchComboResult>> SearchCustomerCombo(string filter)
    {
      var customerList = await _repositoryWrapper.Customer.SearchCustomerCombo(filter);
      return customerList;
    }


    // [HttpPost("movefolder/{customer}")]
    // public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
    // {

    //   // Validator.ValidateObject(customerRequest, new ValidationContext(customerRequest), true); //server side validation by using
    //   //                 await _repositoryWrapper.Customer.CreateAsync(customerRequest, true);
    //   //                 if(customerRequest.CustomerPhoto != null && customerRequest.CustomerPhoto != "")
    //   //                 {
    //   //                     FileService.MoveTempFile("customerPhoto", customerRequest.Id.ToString(), customerRequest.CustomerPhoto);
    //   //                     //FileService.MoveTemmpFileDir("CustomerPhoto", customer.Id.ToStrig(), customer.CustomerPhoto);
    //   //                 }
    //   await _repositoryWrapper.Customer.CreateAsync(customer, true);
    //   if (customer.CustomerPhoto != null && customer.CustomerPhoto != "")
    //   {
    //     FileService.MoveTempFile("CustomerPhoto", customer.CustomerId.ToString(), customer.CustomerPhoto);
    //   }

    //   return CreatedAtAction(nameof(Getcustomer), new { id = customer.CustomerId }, customer);
    // }

    [HttpPost]
    public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
    {
      try
      {
        Validator.ValidateObject(customer, new ValidationContext(customer), true); //server side validation by using
        await _repositoryWrapper.Customer.CreateAsync(customer, true);
        if (customer.CustomerPhoto != null && customer.CustomerPhoto != "")
        {
          // FileService.MoveTempFile("CustomerPhoto", customer.CustomerId.ToString(), customer.CustomerPhoto);
          FileService.MoveTempFileDir("CustomerPhoto", customer.CustomerId.ToString(), customer.CustomerPhoto);
        }
      }
      catch (ValidationException vex)
      {
        BadRequest(vex.Message);
      }

      return CreatedAtAction(nameof(Getcustomer), new { id = customer.CustomerId }, customer);
    }

    // await _repositoryWrapper.Customer.CreateAsync(customer, true);
    // if (customer.CustomerPhoto != null && customer.CustomerPhoto != "")
    // {
    //   FileService.MoveTempFile("CustomerPhoto", customer.CustomerId.ToString(), customer.CustomerPhoto);
    // }

    // return CreatedAtAction(nameof(Getcustomer), new { id = customer.CustomerId }, customer);


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
      var customer = await _repositoryWrapper.Customer.FindByIDAsync(id);
      if (customer == null)
      {
        return NotFound();
      }
      FileService.DeleteFileNameOnly("CustomerPhoto", id.ToString());
      await _repositoryWrapper.Customer.DeleteAsync(customer, true);
      return NoContent();
    }
    private bool CustomerExists(int id)
    {
      return _repositoryWrapper.Customer.IsExists(id);
    }
  }
}