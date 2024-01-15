using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionPage : MonoBehaviour
{

    void Start()
    {
        //Time.timeScale = 0f;
    }

    public void ClickedOnStart(bool isClicked)
    {
        if (isClicked)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
