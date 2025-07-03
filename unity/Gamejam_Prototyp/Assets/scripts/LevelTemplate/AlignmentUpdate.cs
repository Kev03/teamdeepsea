using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentUpdate : MonoBehaviour
{
    public void ChangeAlignment(bool alignment)
    {
        //        currentWrapper.alignment = (visibleSub.gameObject.transform.eulerAngles.y == -180);

        if (alignment)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }


}
