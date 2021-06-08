using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static int NumInputToInt()
    {
        for(int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
                return i;
        }
        return -1;
    }
}
