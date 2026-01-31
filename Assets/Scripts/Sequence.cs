using UnityEngine;

[CreateAssetMenu(fileName = "New Sequence", menuName = "ScriptableObject/Sequence")]
public class Sequence : ScriptableObject
{
    public Note[] Notes;
}