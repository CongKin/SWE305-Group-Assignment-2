using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private Transform destination;
    [SerializeField]private KeyCode interactKey;

    public bool canTeleport;
    private float distance = 0.2f;

    void Start()
    {
        Debug.Log("start");
        Debug.Log(destination.position.x + " + " + destination.position.y);
    }

    void Update()
    {
        if(canTeleport && Input.GetKeyDown(interactKey))
        {
            Debug.Log("key");
            if (Vector2.Distance(transform.position, player.transform.position) > distance)
            {
                Debug.Log("teleport");
                player.transform.position = new Vector2 (destination.position.x, destination.position.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("player in range" + canTeleport);
            canTeleport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("player out of range" + canTeleport);
            canTeleport = false;
        }
    }
}
