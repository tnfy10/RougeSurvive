using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private GameObject StartButton;
    private GameObject SettingButton;
    private GameObject ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_Start()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void OnClick_Exit() {
        Application.Quit();
    }

    public void OnClick_Title()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
