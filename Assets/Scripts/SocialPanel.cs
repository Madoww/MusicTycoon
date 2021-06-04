using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialPanel : MonoBehaviour
{
    [SerializeField] private SocialSong socialSongPrefab;

    private void OnEnable()
    {
        foreach(Song song in GameManager.Instance.songs)
        {
            SocialSong socialSong = Instantiate(socialSongPrefab, transform);
            socialSong.title.SetText(song.name);
            socialSong.genre.SetText(song.genre.genreName);
        }
    }
}
