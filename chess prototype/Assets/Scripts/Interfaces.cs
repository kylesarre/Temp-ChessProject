using UnityEngine;
using System.Collections;

public interface IPiece
{
	int Position { get; set;}
	void move ();
}