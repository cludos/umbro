using UnityEngine;
using System.Collections;

public class camerarotate : MonoBehaviour {
    public GameObject board;
    private Transform target;

	// Use this for initialization
	void Start () {
        target = board.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            transform.LookAt(target);
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * 5);
            transform.RotateAround(target.position, Vector3.right, Input.GetAxis("Mouse Y") * 5);

        }
    }
}
