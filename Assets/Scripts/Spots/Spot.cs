using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public ResourcesController resourcesController => SingletonController.singletonController.resourcesController;

    private void OnTriggerEnter(Collider other)
    {
        OnPlayerEnter();
    }

    private void OnTriggerStay(Collider other)
    {
        OnPlayerStay();
    }

    private void OnTriggerExit(Collider other)
    {
        OnPlayerExit();
    }

    public virtual void OnPlayerEnter()
    {

    }

    public virtual void OnPlayerStay()
    {
    }

    public virtual void OnPlayerExit()
    {

    }


}
