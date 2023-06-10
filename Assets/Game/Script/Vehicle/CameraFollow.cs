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
	Vector3 initialPlayerPosition;
	public Vector3 offsetIsoCamera = new Vector3(-12.5799999f,14.6999998f,15.8599997f);
	public Vector3 offsetNearCamera = new Vector3(0f,4.982f,-8.02000046f);

	[SerializeField] private enum CameraType
	{
		NearCamera,
		IsometricCamera,
	}
	[SerializeField] private CameraType _cameraType;

	void Start(){
		if (_levelManager == null)
		{
			_levelManager = GameObject.FindGameObjectWithTag("GameManager").transform.GetComponent<LevelManager>();
		}
		
		initialPlayerPosition = _levelManager.SpawnedPlayerVehicle.transform.position;		
		_cameraType = CameraType.NearCamera; //default camera
	}

	void FixedUpdate()
	{
		Vector3 Target;
		Vector3 currentOffset;

		Target = _levelManager.SpawnedPlayerVehicle.transform.position;

		if(Input.GetKeyDown(KeyCode.C)){
			if(_cameraType == CameraType.NearCamera){
				_cameraType = CameraType.IsometricCamera;
			}else if(_cameraType == CameraType.IsometricCamera){
				_cameraType = CameraType.NearCamera;
			}
		}
		
		if(_cameraType == CameraType.NearCamera){
			currentOffset = offsetNearCamera;
			//Look at car
			Vector3 _lookDirection = - currentOffset;
			Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
			transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
			//Move to car
			Vector3 _targetPos = currentOffset + Target;
			transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
		}else if(_cameraType == CameraType.IsometricCamera){
			currentOffset = offsetIsoCamera;
			//Look at car
			Vector3 _lookDirection = - currentOffset;
			Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
			transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
			//Move to car
			Vector3 _targetPos = currentOffset + Target;
			transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
		}
	}
}