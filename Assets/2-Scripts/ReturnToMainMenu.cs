using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    VRInputActions inputActions;


    private void Awake()
    {
        inputActions = new VRInputActions();
        inputActions.Enable();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputActions.RhythmRiftControls.ReturnToMainMenu.IsPressed())
        {

            SceneManager.LoadScene("Track0");
           
        }
    }
}
