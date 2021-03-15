using UnityEngine;
using UnityEngine.SceneManagement;


    public class SceneController : MonoBehaviour
    {
        // Start is called before the first frame update

        public static void LoadGameScene()
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
        
        public static void LoadGameMainMenu()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }

