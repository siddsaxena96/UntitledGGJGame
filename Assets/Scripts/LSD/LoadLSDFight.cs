﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLSDFight : MonoBehaviour
{
    public GameObject loadingPanel;
    public AudioSource transitionAudio;
    public BasicMovement player;


    void OnCollisionEnter2D(Collision2D col)
    {                
        if(col.gameObject.tag=="Player")        
        {            
            StartCoroutine("LSDFIGHT");      
            player.move=false;      
        }
    }

    IEnumerator LSDFIGHT(){        
        loadingPanel.SetActive(true);      
        transitionAudio.Play();
        while(transitionAudio.isPlaying){  
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene("ShootingGameSinglePlayer");     
    }
}
