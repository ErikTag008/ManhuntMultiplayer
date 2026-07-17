using Project.Assets._Project._Scripts.Player;
using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class InjectionHolder : Singleton<InjectionHolder>
    {
        [Inject] public readonly PlayerStats Stats;
        [Inject] public readonly Camera MainCamera;
        [Inject] public readonly GameplayCamera GameplayCamera;
    }
}
