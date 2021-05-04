using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Systems {
    public class SceneChanger : MonoBehaviour {

        [SerializeField] private string sceneName;

        public void changeScene() {
            SceneManager.LoadScene(sceneName);
        }
    }
}
