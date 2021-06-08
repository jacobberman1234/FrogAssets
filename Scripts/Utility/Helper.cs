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
}
