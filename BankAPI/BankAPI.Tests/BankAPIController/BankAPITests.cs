using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using BankAPI.Configurations;
using BankAPI.Controllers;
using BankAPI.Data;
using BankAPI.Models;



namespace BankAPI.Tests.BankAPIController
{
    public class BankAPITests
    {
        private readonly BankCustomersDbContext _context;
        private readonly IMapper _mapper;
        public BankAPITests()
        {
            _context = A.Fake<BankCustomersDbContext>();
            _mapper = A.Fake<IMapper>();
        }



        [Fact]
        public async Task GetBankCustomersTbs_ReturnsListOfBankCustomer_WhenDataExists()
        {
            // Arrange

             var fakeCustomersData = new List<BankCustomersTb>
             {
                 
             new  BankCustomersTb { Id = 1, FirstName = "Kimia",LastName = "Abbasi" ,AccountNumber = 123456},
             new  BankCustomersTb { Id = 2, FirstName = "Mahmood",LastName = "Rezaei" ,AccountNumber = 123456}
                
             };

            var _controller = new BankCustomersTbsController(_context, _mapper);

            //Act
            var result = await _controller.GetBankCustomersTbs();

            //Assert


             result.Should().NotBeNull();
             result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
