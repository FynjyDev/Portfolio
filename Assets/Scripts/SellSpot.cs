using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellSpot : Spot
{
    public ResourcesController.ResourceTypes sellResourceType;

    public Slider progressImage;

    private float _SellDelay => SingletonController.singletonController.config.sellDelay;

    public override void OnPlayerEnter()
    {
        base.OnPlayerEnter();
        StartCoroutine(Sell());
    }

    public override void OnPlayerExit()
    {
        base.OnPlayerExit();
        StopAllCoroutines();
    }

    private IEnumerator Sell()
    {
        ResourceInfo _resourceInfo = resourcesController.GetResourceInfoByType(sellResourceType);
        progressImage.maxValue = _SellDelay;
        progressImage.value = _SellDelay;

        if (_resourceInfo.resourceCount > 0) yield return null;

        while (_resourceInfo.resourceCount > 0)
        {
            float _sellDelayTemp = _SellDelay;
            progressImage.gameObject.SetActive(true);

            while (_sellDelayTemp > 0)
            {
                _sellDelayTemp -= Time.fixedDeltaTime;

                progressImage.value = _sellDelayTemp;
                yield return null;
            }

            resourcesController.ChangeResourceValue(sellResourceType, -1);
            resourcesController.ChangeResourceValue(ResourcesController.ResourceTypes.coins, 1);

            progressImage.value = _SellDelay;
            progressImage.gameObject.SetActive(false);
        }
    }
}
