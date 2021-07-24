using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialPanel : MonoBehaviour
{
    [SerializeField] private SocialSong socialSongPrefab;
    [SerializeField] private Transform root;

    private List<SocialSong> socialSongs = new List<SocialSong>();

    private void OnEnable()
    {
        foreach(Song song in GameManager.Instance.songs)
        {
            SocialSong socialSong = Instantiate(socialSongPrefab, root);
            socialSong.title.SetText(song.name);
            socialSong.genre.SetText(song.genre.genreName);
            socialSongs.Add(socialSong);
        }
    }

    private void OnDisable()
    {
        for(int i = socialSongs.Count-1; i>= 0; i--)
        {
            Destroy(socialSongs[i].gameObject);
            socialSongs.RemoveAt(i);
        }
    }
}
