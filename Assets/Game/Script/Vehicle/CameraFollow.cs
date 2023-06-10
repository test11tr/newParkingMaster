using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using test11.Managers;

public class CameraFollow : MonoBehaviour {

	public LevelManager _levelManager;
	[Range(1, 10)]
	public float followSpeed = 2;
	[Range(1, 10)]
	public float lookSpeed = 5;
	Vector3 initialCameraPosition;
	Vector3 initialPlayerPosition;
	Vector3 absoluteInitCameraPosition;
	public Vector3 offset = new Vector3(-30.2179165f,32.8461037f,36.964241f);

	void Start(){
		if (_levelManager == null)
		{
			_levelManager = GameObject.FindGameObjectWithTag("GameManager").transform.GetComponent<LevelManager>();
		}
		
		initialPlayerPosition = _levelManager.SpawnedPlayerVehicle.transform.position;		
	}

	void FixedUpdate()
	{
		Vector3 Target;
		Vector3 currentOffset;

		Target = _levelManager.SpawnedPlayerVehicle.transform.position;
		currentOffset = offset;
		
		//Look at car
		Vector3 _lookDirection = - currentOffset;
		Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);

		//Move to car
		Vector3 _targetPos = currentOffset + Target;
		transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
	}
}
