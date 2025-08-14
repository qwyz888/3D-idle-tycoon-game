using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoad
{
    public class Loader : MonoBehaviour
    {
        private void Start()
        {
            // If you are loading scenes without addressables
            var scene = SceneManager.LoadScene("Menu", new LoadSceneParameters(LoadSceneMode.Single));
        }
    }
}