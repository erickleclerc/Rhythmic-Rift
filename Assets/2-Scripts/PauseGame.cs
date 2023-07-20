using UnityEngine;

public class PauseGame : MonoBehaviour
{
     VRInputActions inputActions;
    private bool isPaused = false;


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
        if (inputActions.RhythmRiftControls.PauseGame.IsPressed())
        {
            if (isPaused == false)
            Time.timeScale = 0;
            else if (isPaused == true)
                Time.timeScale = 1;

        }
    }
}
