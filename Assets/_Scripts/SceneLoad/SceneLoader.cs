using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoad
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private  SceneField _scene;

        public void Load() => SceneManager.LoadScene(_scene);
    }
}