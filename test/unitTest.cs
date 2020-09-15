using Xunit;
using System;
using Summary;

    public class unitTest
    {
        
        [Fact]
        public void passTest()
        {
            Assert.Equal("cat", Program.center("cat"));
        }

    }