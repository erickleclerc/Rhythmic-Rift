using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;

public class Quit : MonoBehaviour
{
    public Button quitButton;
    [SerializeField] private TextMeshProUGUI gameText;
    
    private void Awake()
    {
        quitButton.onClick.AddListener(QuitNow);
    }

    public void QuitNow()
    {
        gameText.text = $"Sayonara!";
        for (int i = 3; i > 0; i--) //see if fade to 
        {
            RenderSettings.skybox.SetFloat("_Exposure", i);
        }

        StartCoroutine(QuitApp());        
    }

    IEnumerator QuitApp()
    {
        yield return new WaitForSecondsRealtime(3);
        Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
            QuitNow();
    }
}
