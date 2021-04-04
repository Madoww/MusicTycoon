using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Song Genre", menuName = "Song Genre")]
public class SongGenre : ScriptableObject
{
    public string genreName;
    [Range(0, 100)]
    public int beatImportance;
}
