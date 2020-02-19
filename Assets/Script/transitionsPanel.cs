using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionsPanel : MonoBehaviour
{
    private Animator transferPanel;
    void Start()
    {
        transferPanel = GetComponent<Animator>();
    }

    public void LoadSreen(int index)
    {
        StartCoroutine(Transitions(index));
    }

    public void loadScreen()
    {
        StartCoroutine(Transitions(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator Transitions(int sceneName)
    {
        transferPanel.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
