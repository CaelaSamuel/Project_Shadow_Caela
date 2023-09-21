using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzzleFlash : MonoBehaviour
{
    public float lifeTimer = 0.05f;
    void Start() => Destroy(this.gameObject, lifeTimer);
}
