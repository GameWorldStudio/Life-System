using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject currentGun;
    private GameObject gunModel;

    public GameObject handGun;

    public void SetGunProperties(GunData gunData)
    {
        if(currentGun != null)
        {
            Destroy(currentGun);
        }
        currentGun = gunModel = gunData.gunModel;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(handGun != null && currentGun != null && gunModel != null)
            currentGun.transform.position = handGun.transform.position;
    }
}
