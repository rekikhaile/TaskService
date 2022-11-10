using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeHomeCodingAssignment.Controllers;
using TakeHomeCodingAssignment.Data;
using TakeHomeCodingAssignment.Models;

namespace TakeHomeCodingAssignment.Tests.Controller
{
    public class GeicoTasksControllerTests
    {
        

        //private readonly GeicoTask geicoTask;

        private readonly GeicoTaskDbContext _fakeContext;

        public GeicoTasksControllerTests()
        {
            _fakeContext = A.Fake<GeicoTaskDbContext>();

        }



        [Fact]
        public async Task GetGeicoTask_ReturnSuccess()
        {
            //Arrange
            var geicoTasks = A.Fake<ICollection<GeicoTask>>();
            var geicoTaskList = A.Fake<List<GeicoTask>>();
            var Tasks = A.Fake<DbSet<GeicoTask>>();
            var foo = _fakeContext.Tasks.ToListAsync();
            A.CallTo(() => foo).Returns(geicoTaskList);

            var controller = new GeicoTasksController(_fakeContext);

            //ACT
            var actionResult = await controller.GetTasks();

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<List<OkObjectResult>>();

            

        }



    }
}
