using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public void Switch(string sceneName){
		SceneManager.LoadScene(sceneName);
	}
}
