using NUnit.Framework;
using Project.Assets._Project._Scripts.Networking;

namespace Project.Assets._Project.Tests.EditMode
{
    public class ConnectionModeTests
    {
        [Test]
        public void Auto_IsLocalInEditor()
        {
            Assert.AreEqual(ConnectionMode.Local, ConnectionSettings.ResolveMode(ConnectionMode.Auto, isEditor: true));
        }

        [Test]
        public void Auto_IsSteamInBuilds()
        {
            Assert.AreEqual(ConnectionMode.Steam, ConnectionSettings.ResolveMode(ConnectionMode.Auto, isEditor: false));
        }

        [TestCase(ConnectionMode.Local, true)]
        [TestCase(ConnectionMode.Local, false)]
        [TestCase(ConnectionMode.Steam, true)]
        [TestCase(ConnectionMode.Steam, false)]
        public void ForcedMode_IsKept(ConnectionMode mode, bool isEditor)
        {
            Assert.AreEqual(mode, ConnectionSettings.ResolveMode(mode, isEditor));
        }
    }
}
