using System.Collections;
using UnityEngine;

public class FishSpot : Spot
{
    private float _ExtractResourceTime => SingletonController.singletonController.config.maxExtractResourceDelay;
    private int _MaxResourcesCount => SingletonController.singletonController.config.maxReourceCountInSpot;

    public ResourcesController.ResourceTypes resourceType;

    public int tempResourcesCount;

    private void Start()
    {
        StartCoroutine(ExstractResourceDelay());
    }

    public override void OnPlayerEnter()
    {
        if (tempResourcesCount > 0) GiveResources();
        base.OnPlayerEnter();
    }


    public void GiveResources()
    {
        resourcesController.ChangeResourceValue(resourceType, tempResourcesCount);
        tempResourcesCount = 0;
    }

    public IEnumerator ExstractResourceDelay()
    {
        while (tempResourcesCount < _MaxResourcesCount)
        {
            float _tempExtractResourceTime = _ExtractResourceTime;

            while (_tempExtractResourceTime > 0)
            {
                _tempExtractResourceTime -= Time.deltaTime;
                yield return null;
            }

            tempResourcesCount++;
        }
    }
}
