using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawCursor : MonoBehaviour
{
    public Texture2D paw;

    void Start() 
    {
    //set the cursor origin to its centre. (default is upper left corner)
     Vector2 cursorOffset = new Vector2(paw.width/2, paw.height/2);
     
      //Sets the cursor to the paw sprite with given offset 
      //and automatic switching to hardware default if necessary
      Cursor.SetCursor(paw, cursorOffset, CursorMode.Auto);
    }
}
