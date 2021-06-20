using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGunOnScene : GameManager
{
    public List<GunData> allGun;
    private GameObject gunShowed;
    public int checkInterval = 30;

    IEnumerator GenerateNewGun(List<GunData> gunDatas)
    {
        yield return new WaitForSeconds(checkInterval);

        int gunChoose = Random.Range(0, gunDatas.Count - 1);

        gunShowed = allGun[gunChoose].gunModel;
    }

    public void UpdateWawe(int newWawe)
    {
        gunShowed = null;
        List<GunData> newList =  allGun.FindAll(x => x.recquieredWawe <= newWawe);
        GenerateNewGun(newList);
    }
}
