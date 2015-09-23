using RTS;
using UnityEngine;
using System.Collections;

	
public class UserInput2 : MonoBehaviour {

	private Player player;

	Vector3 movement = new Vector3 (0,0,0);

	// Use this for initialization
	void Start () {
		player = transform.root.GetComponent <Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.human) {
			MoveCamera ();
			RotateCamera ();
		}
	}

	private void MoveCamera(){
		Vector3 origin = Camera.main.transform.position;
		Vector3 destination = origin;
		float xpos = Input.mousePosition.x;
		float ypos = Input.mousePosition.y;
		//movimiento horizontal de la camara
		if (xpos >= 0 && xpos < ResourceManager.ScrollWidth) {
			movement.x -= ResourceManager.ScrollSpeed;
		} else if (xpos <= Screen.width && xpos > Screen.width - ResourceManager.ScrollWidth) {
			movement.x += ResourceManager.ScrollSpeed;
		}
		//movimiento vertical de la camara
		if (ypos >= 0 && ypos < ResourceManager.ScrollWidth) {
			movement.z -= ResourceManager.ScrollSpeed;
		} else if (ypos <= Screen.width && ypos > Screen.width - ResourceManager.ScrollWidth) {
			movement.z += ResourceManager.ScrollSpeed;
		}

		movement = Camera.main.transform.TransformDirection (movement);
		movement.y = 0;
		movement.y -= ResourceManager.ScrollSpeed * Input.GetAxis ("Mouse ScrollWheel");

		destination.x += movement.x;
		destination.y += movement.y;
		destination.z += movement.z;

		if (destination.y > ResourceManager.MaxCameraHeight) {
			destination.y = ResourceManager.MaxCameraHeight;
		} else if (destination.y < ResourceManager.MinCameraHeight) {
			destination.y = ResourceManager.MinCameraHeight;
		}

		if (destination != origin){
			Camera.main.transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.ScrollSpeed);
		}


	}

	private void RotateCamera(){

	}
}
