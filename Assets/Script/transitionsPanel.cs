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

    public void loadScreen(string sceneName)
    {
        StartCoroutine(Transitions(sceneName));
    }

    IEnumerator Transitions(string sceneName)
    {
        transferPanel.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
