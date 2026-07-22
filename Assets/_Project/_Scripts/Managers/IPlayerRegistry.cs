using Project.Assets._Project._Scripts.Player;

namespace Project.Assets._Project._Scripts.Managers
{
    public interface IPlayerRegistry
    {
        public void RegisterPlayer(PlayerController player);
    }
}