using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Client : MonoBehaviour
{
    private const int MaxNumberOfFactoryBuildings = 3;
    private const string MiniTurret = "MiniTurret";
    private const string AutoTurret = "AutoTurret";

    // The client class keeps references to the factory building transforms. We do this to be able to keep the same
    // object/building in the scene but change the underlying vehicle factory implementation on-the-fly
    // Each time we instantiate a new vehicle factory, the corresponding factory building transform reference
    // needs to be assigned.
    private readonly Transform[] _factoryBuildings = new Transform[MaxNumberOfFactoryBuildings];

    // We also keep references to all container ships as the vehicle factory needs to know where to send the newly
    // produced vehicles. Each time we instantiate a new vehicle factory, the corresponding container ship reference
    // needs to be assigned.
    private readonly Transform[] _containerShips = new Transform[MaxNumberOfFactoryBuildings];

    public TMP_Dropdown buildingDropdown;
    public TMP_Dropdown factoryTypeDropdown;
    public GameObject FacA;
    public GameObject FacB;
    public GameObject FacC;
    public GameObject Turret;
    private void Start()
    {
        InvokeRepeating(nameof(ProduceVehicles), 5, 3);
    }

    public void ProduceVehicles()
    {
        for (var i = 0; i < MaxNumberOfFactoryBuildings; i++)
        {
            // Skip if the no turret
            if (_factoryBuildings[i] == null || _factoryBuildings[i].GetComponent<TurretFactory>() == null) continue;

            // Create random bullet
            if (Random.Range(0, 2) == 0)
            {
                _factoryBuildings[i].GetComponent<TurretFactory>().CreateFastBullet();
            }
            else
            {
                _factoryBuildings[i].GetComponent<TurretFactory>().CreateSlowBullet();
            }
        }
    }

    // This method is called whenever the "Assign" button is clicked in the user interface.
    // The method checks which building is selected and which factory implementation is needed.
    // If a building already exists, the existing building transform is reused. Otherwise it is created.
    // The same goes for the container ship
    public void AssignFactoryToBuilding()
    {
        Transform factoryBuildingTransform = null;
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
                CreateFactoryBuildingAndShip(0,typeOfTurret, FacA, out factoryBuildingTransform);
                break;

            case "Position B":
                CreateFactoryBuildingAndShip(1, typeOfTurret, FacB, out factoryBuildingTransform);
                break;

            case "Position C":
                CreateFactoryBuildingAndShip(2, typeOfTurret, FacC, out factoryBuildingTransform);
                break;
        }

        if (factoryBuildingTransform == null)
        {
            Debug.Log("Could not initialize or load factory transform");
            return;
        }

        // Before attaching a new vehicle factory implementation (script) to the factory building, we need to deactivate the transform
        // This is necessary as the transform might otherwise access the factory implementation (script) while we are trying to 
        // change it which would cause all sorts of issues...

        factoryBuildingTransform.gameObject.SetActive(false);

        // Out of laziness, we simply destroy any existing / attached vehicle factory implementation even if the same one is assigned again :-)
        TurretFactory vehicleFactory = factoryBuildingTransform.gameObject.GetComponent<TurretFactory>();
        Destroy(vehicleFactory);

        // Depending on the selected vehicle factory implementation type, we then assign a new vehicle factory implementation (script) to the transform
        switch (factoryTypeDropdown.captionText.text)
        {
            case "Mini Turret":
                MiniTurretFactory miniTurretFactory = factoryBuildingTransform.gameObject.AddComponent<MiniTurretFactory>();
                miniTurretFactory.factoryBuildingTransform = factoryBuildingTransform;
                break;
            case "Auto Turret":
                AutoTurretFactory autoTurretFactory = factoryBuildingTransform.gameObject.AddComponent<AutoTurretFactory>();
                autoTurretFactory.factoryBuildingTransform = factoryBuildingTransform;
                break;
        }

        // Finally we reactivate the transform and let the newly attached vehicle factory implementation do its magic...
        factoryBuildingTransform.gameObject.SetActive(true);
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

    private void CreateFactoryBuildingAndShip(int arrayPosition,int typeOfTurret, GameObject Fac, out Transform factoryBuildingTransform)
    {
        if (_factoryBuildings[arrayPosition] == null)
        {
            // Create transforms for factory building and ship
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