using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Haru.Converters;

namespace Haru.Converters.Tests.Units
{
    [TestClass]
    public class ByteArrayTest
    {
        private readonly string _hash;
        private readonly string _text;
        private readonly byte[] _data;

        public ByteArrayTest()
        {
            _hash = "48656c6c6f2c20776f726c6421";
            _text = "Hello, world!";
            _data = Encoding.UTF8.GetBytes(_text);
        }

        [TestMethod]
        public void TestToString()
        {
            var hash = ByteArray.ToString(_data);
            var result = (hash == _hash);
            Assert.IsTrue(result);
        }
    }
}