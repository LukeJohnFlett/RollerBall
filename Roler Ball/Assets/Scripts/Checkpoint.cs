using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerController player;
    public Renderer rend;

    public Material cpActive;
    public Material checkpoint;
    
    
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckpointActive()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach (Checkpoint cp in checkpoints)
        {
            cp.CheckpointOff();
        }
            
        rend.material = cpActive;
        
    }

    public void CheckpointOff()
    {
        rend.material = checkpoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("ball"))
        {
            player.SetSpawn(transform.position);
            CheckpointActive();
        }
    }
}
