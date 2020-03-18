using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class Ads_Manager:MonoBehaviour,IUnityAdsListener 
{
    string Google_Play_Id = "3492187";
    bool GameMode = false;
    string myPlacementId = "rewardedVideo";
    public int scene;
    
    private void Start()
    {
        Advertisement.Initialize(Google_Play_Id, GameMode);
    }

    public void DispayAdvertisment()
    {
        Advertisement.Show(myPlacementId);
        
    }

    public void DisplayAd()
    {
        Advertisement.Show();
        StartCoroutine("Reload");
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene);
    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
       if(showResult== ShowResult.Finished)
        {
            
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new NotImplementedException();
    }
}