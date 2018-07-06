using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    private float Horizontal;
    private float Vertical;

    [Tooltip("in ms^-1")][SerializeField] private float xSpeed = 4f;
    [Tooltip("in ms^-1")] [SerializeField] private float ySpeed = 4f;
    [SerializeField] private float xRange = 5f;
    [SerializeField] private float yRange = 5f;
    [SerializeField] private float positionPitchFactor = -5f;
    [SerializeField] private float controlPitchFactor = -20f;
    [SerializeField] private float positionYawFactor = 5f;
    [SerializeField] private float controlRowFactor = -20f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
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
