using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddedCommands : MonoBehaviour
{
    // This is just for Improved Commands

    //Improved Instantiate, will instead instantiate object under this scripts gameObject, Can change the Rotation with "vector3 eular"
    public void ImprovedInstantiate(GameObject Object, Vector3 vector3, Vector3 euler)
    {
        Object = Instantiate(Object, vector3, Quaternion.Euler(euler));
        Object.transform.parent = this.transform;
    }
    // Tim.B
}
