using Degishop.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
namespace unit_test
{
    public class TestHomeController
    {
        [Fact]
        public void Test1()
        {
            HomeController obj = new HomeController(null);
            var result = obj.Login("taha", "taha5678") as ViewResult;
            Assert.Equal("TahaDashboard", result.ViewName);

        }
    }
}
