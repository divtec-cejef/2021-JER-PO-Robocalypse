using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlayerOption : MonoBehaviour
{
    public static bool onePlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void modifyPlayerCount()
    {
        onePlayer = !onePlayer;
    }
    
    public void isOnePlayer()
    {
        onePlayer = true;
    }

    public void isNotOnePlayer()
    {
        onePlayer = false;
    }

    public bool onePlayerOrNot()
    {
        return onePlayer;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
