using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SoundStateHandler : MonoBehaviour
{
    private const string FilePath = "sound_settings.json";

    [SerializeField] Sprite MusicButtonOn;
    [SerializeField] Sprite MusicButtonOff;

    private bool _sound = true;

    void Start()
    {
        if (!File.Exists(FilePath))
            SerializeSoundState();
        SoundStateDTO soundData = JsonUtility.FromJson<SoundStateDTO>(File.ReadAllText(FilePath));
        _sound = soundData.SoundState;
        SetSprite();
    }

    public void OnMouseButtonClick()
    {
        _sound = !_sound;
        SetSprite();
        SerializeSoundState();
    }

    private void SetSprite()
    {
        if (_sound)
            gameObject.GetComponent<Image>().sprite = MusicButtonOn;
        else
            gameObject.GetComponent<Image>().sprite = MusicButtonOff;
    }

    private void SerializeSoundState()
    {
        SoundStateDTO soundDTO = new()
        {
            SoundState = _sound
        };
        File.WriteAllText(FilePath, JsonUtility.ToJson(soundDTO));
    }
}
