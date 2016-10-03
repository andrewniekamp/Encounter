using Encounter.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace Encounter.Tests.ControllerTests
{
    public class CharacterControllerTest
    {
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //arrange
            CharacterController controller = new CharacterController();

            //act
            var result = controller.Index();

            //assert
            Assert.IsType<Task<IActionResult>>(result);
        }
    }
}
