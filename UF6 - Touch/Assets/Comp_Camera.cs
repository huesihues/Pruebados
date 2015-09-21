using UnityEngine;
using System.Collections;

public class Comp_Camera : MonoBehaviour
{
	public Transform transform_player;
	public float DistanceToPlayer;
	public float Y_Offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		Vector3 new_camera_pos = transform_player.position;

		new_camera_pos.x = new_camera_pos.x + DistanceToPlayer;
		new_camera_pos.y = new_camera_pos.y + Y_Offset;
		new_camera_pos.z = new_camera_pos.z;

		transform.position = new_camera_pos;
	}
}
