using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;

    private Transform player;
    //private Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player.transform.position = spawnPosition.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
