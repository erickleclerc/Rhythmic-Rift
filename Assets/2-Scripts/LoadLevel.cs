using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public Button loadSceneButton;
    public string levelname = "Track1";

    // Start is called before the first frame update
    void Start()
    {
        loadSceneButton.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    public void LoadScene()
    {
        SceneManager.LoadScene($"{levelname}");
    }
}
