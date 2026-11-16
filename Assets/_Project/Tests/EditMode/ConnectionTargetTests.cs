using NUnit.Framework;
using Project.Assets._Project._Scripts.Networking;

namespace Project.Assets._Project.Tests.EditMode
{
    public class ConnectionTargetTests
    {
        private const string DefaultAddress = "127.0.0.1";
        private const ushort DefaultPort = 7777;

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Blank_UsesDefaults(string target)
        {
            Assert.IsTrue(ConnectionTarget.TryParse(target, DefaultAddress, DefaultPort, out var address, out var port));
            Assert.AreEqual(DefaultAddress, address);
            Assert.AreEqual(DefaultPort, port);
        }

        [Test]
        public void AddressOnly_UsesDefaultPort()
        {
            Assert.IsTrue(ConnectionTarget.TryParse(" 192.168.1.5 ", DefaultAddress, DefaultPort, out var address, out var port));
            Assert.AreEqual("192.168.1.5", address);
            Assert.AreEqual(DefaultPort, port);
        }

        [Test]
        public void AddressWithPort_UsesBoth()
        {
            Assert.IsTrue(ConnectionTarget.TryParse("10.0.0.2:7790", DefaultAddress, DefaultPort, out var address, out var port));
            Assert.AreEqual("10.0.0.2", address);
            Assert.AreEqual(7790, port);
        }

        [Test]
        public void PortOnly_UsesDefaultAddress()
        {
            Assert.IsTrue(ConnectionTarget.TryParse(":7790", DefaultAddress, DefaultPort, out var address, out var port));
            Assert.AreEqual(DefaultAddress, address);
            Assert.AreEqual(7790, port);
        }

        [TestCase("host:abc")]
        [TestCase("host:0")]
        [TestCase("host:70000")]
        [TestCase("host:")]
        public void BadPort_Fails(string target)
        {
            Assert.IsFalse(ConnectionTarget.TryParse(target, DefaultAddress, DefaultPort, out _, out _));
        }

        [TestCase("::1", "::1")]
        [TestCase("fe80::1", "fe80::1")]
        [TestCase("[::1]", "::1")]
        public void IPv6WithoutPort_KeepsWholeAddress(string target, string expected)
        {
            Assert.IsTrue(ConnectionTarget.TryParse(target, DefaultAddress, DefaultPort, out var address, out var port));
            Assert.AreEqual(expected, address);
            Assert.AreEqual(DefaultPort, port);
        }

        [Test]
        public void BracketedIPv6WithPort_UsesBoth()
        {
            Assert.IsTrue(ConnectionTarget.TryParse("[fe80::1]:7790", DefaultAddress, DefaultPort, out var address, out var port));
            Assert.AreEqual("fe80::1", address);
            Assert.AreEqual(7790, port);
        }

        [TestCase("::1")]
        [TestCase("10.0.0.2")]
        public void Format_RoundTripsAnyAddress(string expectedAddress)
        {
            Assert.IsTrue(ConnectionTarget.TryParse(ConnectionTarget.Format(expectedAddress, 7790), DefaultAddress, DefaultPort, out var address, out var port));
            Assert.AreEqual(expectedAddress, address);
            Assert.AreEqual(7790, port);
        }

        [Test]
        public void Format_RoundTrips()
        {
            Assert.IsTrue(ConnectionTarget.TryParse(ConnectionTarget.Format("10.0.0.2", 7790), DefaultAddress, DefaultPort, out var address, out var port));
            Assert.AreEqual("10.0.0.2", address);
            Assert.AreEqual(7790, port);
        }
    }
}
