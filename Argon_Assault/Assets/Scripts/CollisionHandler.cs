using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] float loadDelay = 4f;

    [SerializeField] GameObject deathfx;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathfx.SetActive(true);
        Invoke("ReloadScene", loadDelay);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
