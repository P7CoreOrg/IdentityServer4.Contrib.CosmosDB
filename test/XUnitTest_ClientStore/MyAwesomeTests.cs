using System;
using Xunit;
namespace XUnitTest_ClientStore
{

    public class MyAwesomeTests
    {
        private readonly IDependency _d;

        public MyAwesomeTests(IDependency d) => _d = d;

        [Fact]
        public void AssertThatWeDoStuff()
        {
            Assert.Equal(1, _d.Value);
        }
    }

}
