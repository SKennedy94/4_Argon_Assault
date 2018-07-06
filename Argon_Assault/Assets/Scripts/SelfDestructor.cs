using UnityEngine;

public class SelfDestructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5f);	
	}
}
