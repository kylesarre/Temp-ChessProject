using UnityEngine;
using System.Collections;

public class PowerUpListController : MonoBehaviour
{
    Upgrade power1,
        power2, 
        power3;
    
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void setPower1(Upgrade i)
    {
        power1 = i;
    }

    public void setPower2(Upgrade i)
    {
        power2 = i;
    }

    public void setPower3(Upgrade i)
    {
        power3 = i;
    }

    public void getPower1()
    {
        // hardcoding for now for the sake of the demo
        power1 = new PawnStraightCapture();
        power1.ApplyUpgrade();
    }

    public void getPower2()
    {
        power2 = new BishopColorSwap();
        power2.ApplyUpgrade();
    }

    public void getPower3()
    {
        power3 = new PawnShift();
        power3.ApplyUpgrade();
    }

    public void clearPowers()
    {
        power1.RemoveUpgrade();
        power2.RemoveUpgrade();
        power3.RemoveUpgrade();
    }
}
