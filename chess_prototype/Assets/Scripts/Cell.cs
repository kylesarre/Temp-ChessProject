using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour 
{
	public GameObject myPiece;
	Vector3 cellCenter;
	public bool isActive;

	// Use this for initialization
	void Start () 
	{
		cellCenter = CellCenter;
		isActive = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void toggleActive()
	{
		isActive = (isActive == true) ? isActive = false : isActive = true;
	}

	public GameObject MyPiece
	{
		get{ return myPiece; }
		set{ myPiece = value; }
	}
	public Vector3 CellCenter
	{
		get{ return cellCenter;}
		private set
		{
			Vector3 origin = transform.position;
			Vector3 midPoint = new Vector3(origin.x + Grid.distanceBetweenTiles, origin.y + Grid.distanceBetweenTiles, origin.z)*(1/2);
			cellCenter = midPoint;
		}
	}
}