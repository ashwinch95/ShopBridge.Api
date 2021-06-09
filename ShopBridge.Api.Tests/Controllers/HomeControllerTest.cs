using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Api.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void GetTest()
        {
            HomeController controller = new HomeController();
            var result = controller.Get();

            Assert.IsNotNull(result);
        }
    }
}
