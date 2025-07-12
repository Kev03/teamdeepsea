using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortBackRequest : MonoBehaviour
{

    public void PortBack()
    {
        LastPortback.Instance.PortBack();
    }

}
