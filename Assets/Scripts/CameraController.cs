using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector2 camLook;
    Vector2 smothV;
    public float sensitivity = 5.0f;
    public float smooting = 2.0f;

    GameObject character;


	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smooting, sensitivity * smooting));
        smothV.x = Mathf.Lerp(smothV.x, md.x, 1f / smooting);
        smothV.y = Mathf.Lerp(smothV.y, md.y, 1f / smooting);
        camLook += smothV;

        transform.localRotation = Quaternion.AngleAxis(-camLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(camLook.x, character.transform.up);

    }
}
