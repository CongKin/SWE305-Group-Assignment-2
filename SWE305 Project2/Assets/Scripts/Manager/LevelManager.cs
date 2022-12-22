using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] private Transform spawnPosition;

    private Character playableCharacter;

    private void Start()
    {
        playableCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ReviveCharacter();
        }
    }

    private void ReviveCharacter()
    {
        if (playableCharacter.GetComponent<Health>().CurrentHealth <= 0)
        {
            playableCharacter.GetComponent<Health>().Revive();
            playableCharacter.transform.position = spawnPosition.position;
        }
    }
}
