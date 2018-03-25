
using NUnit.Framework;

namespace NET.S._2018.Karakouski._6.Tests
{
    [TestFixture]
    class PolynomialTests
    {
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string DoubleToBinaryString_NormalInputs_TestCalulations(double number) => number.DoubleToBinaryString();
    }
}
