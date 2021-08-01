using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SongType
{
    beat = 0,
    song
}

[System.Serializable]
public class Song
{
    public float QualityIndex
    {
        set { qualityIndex = value; }
        get => qualityIndex;
    }

    public string name;
    public SongGenre genre;
    public SongType type;
    public int hoursSpentProducing;
    public float qualityIndex;

    public bool wasUploaded;
    public int plays;
    public int likes;
    public int dislikes;
}
