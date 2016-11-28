using UnityEngine;
using System.Collections;

public class GraveyardScript : MonoBehaviour
{
    private int[] capBlackPieces = new int[5];
    private int[] capWhitePieces = new int[5];

    public UnityEngine.UI.Text BlackCapt;
    public UnityEngine.UI.Text WhiteCapt;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        BlackCapt.text = capBlackPieces[0] + ", " + capBlackPieces[1] + ",  " + capBlackPieces[2] + ",  " + capBlackPieces[3] + ", " + capBlackPieces[4];
        WhiteCapt.text = capWhitePieces[0] + ", " + capWhitePieces[1] + ",  " + capWhitePieces[2] + ",  " + capWhitePieces[3] + ", " + capWhitePieces[4];
    }

    public void capture(Piece piece)
    {
        if(piece is Pawn)
        {
            if (piece.isWhite)
                capWhitePieces[0]++;
            else
                capBlackPieces[0]++;
        }
        else if (piece is Rook)
        {
            if (piece.isWhite)
                capWhitePieces[1]++;
            else
                capBlackPieces[1]++;
        }
        else if (piece is Knight)
        {
            if (piece.isWhite)
                capWhitePieces[2]++;
            else
                capBlackPieces[2]++;
        }
        else if (piece is Bishop)
        {
            if (piece.isWhite)
                capWhitePieces[3]++;
            else
                capBlackPieces[3]++;
        }
        else if (piece is Queen)
        {
            if (piece.isWhite)
                capWhitePieces[4]++;
            else
                capBlackPieces[4]++;
        }
        else
        {

        }
    }
}
