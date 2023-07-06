using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LoadLevel : MonoBehaviour
{
    public Button loadSceneButton;

    [SerializeField] private TextMeshProUGUI gameText;
    [SerializeField] private string levelname = "Track1";
    [SerializeField] private AudioSource audioLoad;

    void Awake()
    {
        // useful if raytrace and controller trigger can be use for button press, otherwise can be omitted
        loadSceneButton.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    public void LoadScene()
    {        
        gameText.text = $"Loading {levelname}";        
        //for (int i = 3; i > 0; i--) //see if fade to 
        //{
        //    RenderSettings.skybox.SetFloat("_Exposure", i);
        //}
        audioLoad.PlayDelayed(.2f);
        StartCoroutine(LoadTrack());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        LoadScene();
    }

    IEnumerator LoadTrack()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene($"{levelname}");
    }
}
