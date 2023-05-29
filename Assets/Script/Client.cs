using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Client : MonoBehaviour
{
    private const int MaxNumberOfFactoryBuildings = 3;
    private const string MiniTurret = "MiniTurret";
    private const string AutoTurret = "AutoTurret";

    private readonly Transform[] _factoryBuildings = new Transform[MaxNumberOfFactoryBuildings];

    public TMP_Dropdown buildingDropdown;
    public TMP_Dropdown factoryTypeDropdown;
    public GameObject FacA;
    public GameObject FacB;
    public GameObject FacC;
    private void Start()
    {
        InvokeRepeating(nameof(CreateBullet), 3, 2);
    }

    public void CreateBullet()
    {
        for (var i = 0; i < MaxNumberOfFactoryBuildings; i++)
        {
            // Skip if the no turret
            if (_factoryBuildings[i] == null || _factoryBuildings[i].GetComponent<BulletFactory>() == null) continue;

            // Create random bullet
            if (Random.Range(0, 2) == 0)
            {
                _factoryBuildings[i].GetComponent<BulletFactory>().CreateFastBullet();
            }
            else
            {
                _factoryBuildings[i].GetComponent<BulletFactory>().CreateSlowBullet();
            }
        }
    }

    // Trigger when user click button
    public void AssignFactoryToBuilding()
    {
        Transform turretTransform = null;
        int typeOfTurret = 0;
        switch (factoryTypeDropdown.captionText.text)
        {
            case "Mini Turret":
                typeOfTurret = 1;
                break;
            case "Auto Turret":
                typeOfTurret = 2;
                break;
        }
        switch (buildingDropdown.captionText.text)
        {
            case "Position A":
                CreateFactory(0,typeOfTurret, FacA, out turretTransform);
                break;

            case "Position B":
                CreateFactory(1, typeOfTurret, FacB, out turretTransform);
                break;

            case "Position C":
                CreateFactory(2, typeOfTurret, FacC, out turretTransform);
                break;
        }

        if (turretTransform == null)
        {
            Debug.Log("Could not initialize or load factory transform");
            return;
        }
        
        BulletFactory bulletFactory = turretTransform.gameObject.GetComponent<BulletFactory>();
        Destroy(bulletFactory);

        switch (factoryTypeDropdown.captionText.text)
        {
            case "Mini Turret":
                MiniBulletFactory miniTurretFactory = turretTransform.gameObject.AddComponent<MiniBulletFactory>();
                miniTurretFactory.TurretTransform = turretTransform;
                break;
            case "Auto Turret":
                AutoBulletFactory autoTurretFactory = turretTransform.gameObject.AddComponent<AutoBulletFactory>();
                autoTurretFactory.TurretTransform = turretTransform;
                break;
        }
       
    }

    private Transform CreateFactoryBuilding(GameObject Fac,int typeOfTurret)
    {
        string turretName = MiniTurret;
        if (typeOfTurret == 2)
        {
            turretName = AutoTurret;
        }
        var factory = Resources.Load(turretName) as GameObject;
        if (factory == null) throw new System.ArgumentException(turretName + "could not be found inside or loaded from Resources folder");
        Transform newFactory = Instantiate(factory.transform, new Vector2(Fac.transform.position.x, Fac.transform.position.y), Quaternion.identity);
        return newFactory;
    }

    private void CreateFactory(int arrayPosition,int typeOfTurret, GameObject Fac, out Transform factoryBuildingTransform)
    {
        if (_factoryBuildings[arrayPosition] == null)
        {
            // Create transforms for factory building
            _factoryBuildings[arrayPosition] = CreateFactoryBuilding(Fac,typeOfTurret);
            factoryBuildingTransform = _factoryBuildings[arrayPosition];
        }
        else
        {
            // Reuse existing transforms
            factoryBuildingTransform = _factoryBuildings[arrayPosition];
        }
    }
}