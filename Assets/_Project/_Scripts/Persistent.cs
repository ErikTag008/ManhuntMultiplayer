using UnityEngine;

namespace Project
{
    public class Persistent : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
