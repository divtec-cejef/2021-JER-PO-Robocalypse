using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUFO : MonoBehaviour
{
    public Texture2D UFO;

    void Start()
    {
        Cursor.SetCursor(UFO, Vector2.zero, CursorMode.ForceSoftware);
    }

}
