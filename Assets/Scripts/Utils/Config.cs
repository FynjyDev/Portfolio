using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Game/Config")]
public class Config : ScriptableObject
{
    [Header("Character Movement Pharameters")]
    public float characterMoveSpeed = 4.75f;
    public float characterRotateSpeed = 0.5f;

    [Header("Resource Spots Pharameters")]
    public int maxResourceCountInSpot;
    public float minExtractResourceDelay, maxExtractResourceDelay; 
    
    [Header("Sell Spots Pharameters")]
    public float sellDelay;
}