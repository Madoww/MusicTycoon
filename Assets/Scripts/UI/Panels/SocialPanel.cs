using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialPanel : MonoBehaviour
{
    [SerializeField] private SocialSong socialSongPrefab;
    [SerializeField] private Transform root;

    private void OnEnable()
    {
        foreach(Song song in GameManager.Instance.songs)
        {
            SocialSong socialSong = Instantiate(socialSongPrefab, root);
            socialSong.title.SetText(song.name);
            socialSong.genre.SetText(song.genre.genreName);
        }
    }
}
