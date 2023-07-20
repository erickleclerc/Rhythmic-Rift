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
    //[SerializeField] private AudioSource audioLoad; //REMOVE AUDIO CAUSING ISSUES WITH SCENE

    void Awake()
    {
        // useful if raytrace and controller trigger can be use for button press, otherwise can be omitted
        loadSceneButton.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    public void LoadScene()
    {        
        gameText.text = $"Loading {levelname}";

        //audioLoad.PlayDelayed(.2f); //REMOVE AUDIO CAUSING ISSUES WITH SCENE
        StartCoroutine(LoadTrack());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand")
        LoadScene();
        Debug.Log("Loading Scene");
    }

    IEnumerator LoadTrack()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene($"{levelname}");
    }
}
