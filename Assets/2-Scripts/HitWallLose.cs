using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitWallLose : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(other.gameObject);
            gameOverText.SetActive(true);

            //PAUSE EVERTYING
            Time.timeScale = 0;

           StartCoroutine(RestartScene());
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSecondsRealtime(7);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
