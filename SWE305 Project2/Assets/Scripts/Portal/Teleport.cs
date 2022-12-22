using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private Transform destination;
    [SerializeField]private KeyCode interactKey;
    [SerializeField]private bool enterLevel;

    public bool canTeleport;
    private float distance = 0.2f;
    private LevelItemManager levelItemManager;

    void Start()
    {
        levelItemManager = GetComponent<LevelItemManager>();
        //Debug.Log("start");
        //Debug.Log(destination.position.x + " + " + destination.position.y);
    }

    void Update()
    {
        if(canTeleport && Input.GetKeyDown(interactKey))
        {
            //Debug.Log("key");
            if (Vector2.Distance(transform.position, player.transform.position) > distance)
            {
                if(enterLevel){
                    //Debug.Log("spawn enemy");
                    levelItemManager.spawnEnemy();
                }else{
                    //Debug.Log("destroy enemy");
                    levelItemManager.destroyEnemy();
                }
                player.transform.position = new Vector2 (destination.position.x, destination.position.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("player in range" + canTeleport);
            canTeleport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("player out of range" + canTeleport);
            canTeleport = false;
        }
    }
}
