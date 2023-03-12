using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpot : Spot
{
    private float _ExtractResourceTime => SingletonController.singletonController.config.maxExtractResourceDelay;
    private int _MaxResourcesCount => SingletonController.singletonController.config.maxReourceCountInSpot;

    public ResourcesController.ResourceTypes resourceType;

    public int tempResourcesCount;

    public List<GameObject> resourcesObjects;

    private void Start()
    {
        StartCoroutine(ExstractResource());
    }

    public override void OnPlayerEnter()
    {
        if (tempResourcesCount > 0) GiveResources();
        base.OnPlayerEnter();
    }

    public void GiveResources()
    {
        resourcesController.ChangeResourceValue(resourceType, tempResourcesCount);

        if (tempResourcesCount >= _MaxResourcesCount)
        {
            StopAllCoroutines();
            tempResourcesCount = 0;
            StartCoroutine(ExstractResource());
        }
        else tempResourcesCount = 0;

        for (int i = 0; i < resourcesObjects.Count; i++) resourcesObjects[i].SetActive(false);
    }

    public IEnumerator ExstractResource()
    {
        while (tempResourcesCount < _MaxResourcesCount)
        {
            float _tempExtractResourceTime = _ExtractResourceTime;

            while (_tempExtractResourceTime > 0)
            {
                _tempExtractResourceTime -= Time.deltaTime;
                yield return null;
            }

            if (resourcesObjects.Count >= tempResourcesCount) resourcesObjects[tempResourcesCount].SetActive(true);
            tempResourcesCount++;
            Debug.Log(tempResourcesCount);
        }

    }
}
