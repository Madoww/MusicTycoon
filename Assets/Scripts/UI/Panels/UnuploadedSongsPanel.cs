using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnuploadedSongsPanel : MonoBehaviour
{
    [SerializeField] private UIUnuploadedSong UIUploadedSongPrefab;
    [SerializeField] private Transform uploadedSongsTransform;

    private List<UIUnuploadedSong> unuploadedSongs = new List<UIUnuploadedSong>();

    private void OnEnable()
    {
        SongManager.Instance.OnUpload += RefreshUI;
        RefreshUI();
    }

    private void OnDisable()
    {
        SongManager.Instance.OnUpload -= RefreshUI;
        ClearUI();
    }

    private void ClearUI()
    {
        for (int i = unuploadedSongs.Count - 1; i >= 0; i--)
        {
            Destroy(unuploadedSongs[i].gameObject);
            unuploadedSongs.RemoveAt(i);
        }
    }

    private void RefreshUI()
    {
        ClearUI();
        foreach (Song song in SongManager.Instance.songs)
        {
            if (!song.wasUploaded)
            {
                UIUnuploadedSong unuploadedSong = Instantiate(UIUploadedSongPrefab, uploadedSongsTransform);
                //@TODO clear this up
                unuploadedSong.title.SetText(song.name);
                unuploadedSong.genre.SetText(song.genre.genreName);
                unuploadedSong.songToUpload = song;

                unuploadedSongs.Add(unuploadedSong);
            }
        }
    }
}
