using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Game/Config")]
public class Config : ScriptableObject
{
    public float characterMoveSpeed = 4.75f;
    public float characterRotateSpeed = 0.5f;
}