using Project.Assets._Project._Scripts.Managers;
using Project.Assets._Project._Scripts.UI;
using Reflex.Attributes;
using UnityEngine;

namespace Project.Assets._Project._Scripts.DI
{
    public class MainMenuReferenceHolder : Singleton<MainMenuReferenceHolder>
    {
        [Inject] public readonly Camera MainCamera;
        [Inject] public readonly ServerStarterUI ServerStarterUI;
        [Inject] public readonly UIManager UIManager;
    }
}
