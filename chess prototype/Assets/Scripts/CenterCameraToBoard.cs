using UnityEngine;
using System.Collections;

public class CenterCameraToBoard : MonoBehaviour {
	private GameObject grid_obj;
	private Grid grid_scr;
	// Use this for initialization
	void Start () 
	{
		grid_obj = GameObject.Find ("obj_grid");
		grid_scr = grid_obj.GetComponent<Grid>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CenterCameraToObject();
	}
	void CenterCameraToObject()
	{
		// check to make sure our grid exists
		if ( !grid_obj.Equals(null) )
		{
			// calculate the center of the grid based on the length and width of the cells
			Vector3 gridCenterVector = new Vector3 (grid_scr.NumOfColumns/2, grid_scr.NumOfRows/2, 0);
			// calculate the camera's centered position using the sum of the grid's current position and the center vector of the grid
			transform.position = new Vector3( grid_obj.GetComponent<Transform>().position.x, grid_obj.GetComponent<Transform>().position.y, transform.position.z ) + gridCenterVector;
		}
	}
}
