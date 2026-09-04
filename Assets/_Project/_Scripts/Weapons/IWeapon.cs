using UnityEngine;

namespace Project.Assets._Project._Scripts.Weapons
{
    public interface IWeapon
    {
        void Attack();
        void StopAttack();
        void UpdateTarget(Vector3 target);
        void Reload();
        void SetNetworkUpdateMinMagnitude(float minMagnitude);
    }

    public class WeaponBase : MonoBehaviour, IWeapon
    {
        public virtual void Attack()
        {
            EUtils.Logger.Log("Attack");
        }
        public virtual void StopAttack()
        {
            EUtils.Logger.Log("StopAttack");
        }
        public virtual void UpdateTarget(Vector3 target)
        {
            EUtils.Logger.Log("UpdateTarget: " + target);
        }
        public virtual void Reload()
        {
            EUtils.Logger.Log("Reload");
        }
        public virtual void SetNetworkUpdateMinMagnitude(float minMagnitude)
        {
            EUtils.Logger.Log("Set Network Update Min magnitude");
        }

       
    }
}