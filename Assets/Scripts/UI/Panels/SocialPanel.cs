using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialPanel : Singleton<SocialPanel>
{
    [SerializeField] private UIUploadedSong UIUploadedSongPrefab;
    [SerializeField] private Transform uploadedSongsTransform;

    private List<UIUploadedSong> UIUploadedSongs = new List<UIUploadedSong>();

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
        for (int i = UIUploadedSongs.Count - 1; i >= 0; i--)
        {
            Destroy(UIUploadedSongs[i].gameObject);
            UIUploadedSongs.RemoveAt(i);
        }
    }

    public void RefreshUI()
    {
        ClearUI();
        foreach (Song song in SongManager.Instance.songs)
        {
            if (song.wasUploaded)
            {
                UIUploadedSong uploadedSong = Instantiate(UIUploadedSongPrefab, uploadedSongsTransform);
                uploadedSong.title.SetText(song.name);
                uploadedSong.genre.SetText(song.genre.genreName);
                uploadedSong.plays.SetText(song.plays.ToString());
                uploadedSong.likes.SetText(song.likes.ToString());
                uploadedSong.dislikes.SetText(song.dislikes.ToString());

                UIUploadedSongs.Add(uploadedSong);
            }

        }
    }
}
