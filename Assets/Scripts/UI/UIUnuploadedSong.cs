using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUnuploadedSong : MonoBehaviour
{
    public Song songToUpload;

    public TextMeshProUGUI title;
    public TextMeshProUGUI genre;
    public UIButton uploadButton;

    private void Start()
    {
        uploadButton.onClick += UploadSelf;
    }

    private void UploadSelf()
    {
        SongManager.Instance.Upload(songToUpload);
    }
}
