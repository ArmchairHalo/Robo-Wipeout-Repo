using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    void Start()
    {
        GetComponent<Button>().Select();
    }

    public void ChangeScene(string scenechange)
    {
        SceneManager.LoadScene(scenechange);
    }
   
}
