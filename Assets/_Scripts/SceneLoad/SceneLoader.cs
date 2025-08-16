using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.SceneLoad
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private  SceneField _scene;

        public void Load() => SceneManager.LoadScene(_scene);
    }
}
