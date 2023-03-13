using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpot : Spot
{
    private float _MinExtractResourceTime => SingletonController.singletonController.config.minExtractResourceDelay;
    private float _MaxExtractResourceTime => SingletonController.singletonController.config.maxExtractResourceDelay;
    private int _MaxResourcesCount => SingletonController.singletonController.config.maxResourceCountInSpot;

    public ResourcesController.ResourceTypes resourceType;

    public int tempResourcesCount;

    public List<GameObject> resourcesObjects;

    private void Start()
    {
        StartCoroutine(ExtractResource());
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
            StartCoroutine(ExtractResource());
        }
        else tempResourcesCount = 0;

        for (int i = 0; i < resourcesObjects.Count; i++) resourcesObjects[i].SetActive(false);
    }

    public IEnumerator ExtractResource()
    {
        while (tempResourcesCount < _MaxResourcesCount)
        {
            float _tempExtractResourceTime = Random.Range(_MinExtractResourceTime, _MaxResourcesCount);

            while (_tempExtractResourceTime > 0)
            {
                _tempExtractResourceTime -= Time.fixedDeltaTime;
                yield return null;
            }

            if (resourcesObjects.Count >= tempResourcesCount) resourcesObjects[tempResourcesCount].SetActive(true);
            tempResourcesCount++;
        }

    }
}
