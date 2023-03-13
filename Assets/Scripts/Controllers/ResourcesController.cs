using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesController : MonoBehaviour
{
    public enum ResourceTypes { fish, wood, coins };

    public List<ResourceInfo> resourceInfos;

    public UIController uiController => SingletonController.singletonController.UIController;

    public void ChangeResourceValue(ResourceTypes _resourceType, int _count)
    {
        ResourceInfo _res = GetResourceInfoByType(_resourceType);

        _res.resourceCount += _count;

        uiController.UpdateResourceValue(_res);

    }

    public ResourceInfo GetResourceInfoByType(ResourceTypes _resourceType)
    {
        for (int i = 0; i < resourceInfos.Count; i++)
        {
            if (_resourceType == resourceInfos[i].resourceType) return resourceInfos[i];
        }
        return null;
    }
}
[System.Serializable]
public class ResourceInfo
{
    public ResourcesController.ResourceTypes resourceType;
    public ResourcePanel resourcePanel;
    public int resourceCount;
}
