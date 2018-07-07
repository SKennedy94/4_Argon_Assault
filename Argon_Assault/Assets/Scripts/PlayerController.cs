using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    private float Horizontal;
    private float Vertical;
    public bool IsAlive = true;

    [Header("General")]
    [Tooltip("in ms^-1")][SerializeField] private float xSpeed = 10f;
    [Tooltip("in ms^-1")] [SerializeField] private float ySpeed = 6f;
    [SerializeField] private float xRange = 6f;
    [SerializeField] private float yRange = 4.5f;
    [SerializeField] GameObject[] Guns;

    [Header("Screen-Position Based")]
    [SerializeField] private float positionPitchFactor = -5f;
    [SerializeField] private float positionYawFactor = 7f;

    [Header("Control-Throw Based")]
    [SerializeField] private float controlPitchFactor = -20f;
    [SerializeField] private float controlRowFactor = -30f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsAlive)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        } else
        {
            DeactivateGuns();
        }
    }

    void DeactivateGuns()
    {
        foreach (GameObject gun in Guns)
        {
            gun.SetActive(false);
        }
    }

    void ActivateGuns()
    {
        foreach (GameObject gun in Guns)
        {
            gun.SetActive(true);
        }
    }

    private void OnPlayerDeath() // called by string reference
    {
        IsAlive = false;
    }

    private void ProcessRotation()
    {
        float pitch = (transform.localPosition.y * positionPitchFactor) + (Vertical * controlPitchFactor);
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = Horizontal * controlRowFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        Horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = Horizontal * xSpeed * Time.deltaTime;
        float NewXpos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);

        Vertical = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = Vertical * ySpeed * Time.deltaTime;
        float NewYpos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(NewXpos, NewYpos, transform.localPosition.z);
    }
}
