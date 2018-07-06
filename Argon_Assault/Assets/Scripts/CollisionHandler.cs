using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Stop controls");
        SendMessage("OnPlayerDeath");
    }
}
