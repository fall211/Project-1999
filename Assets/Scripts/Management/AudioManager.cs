using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audioSourceOne;
    private AudioSource audioSourceTwo;
    private AudioSource audioSourceThree;
    private AudioSource audioSourceFour;
    private AudioSource audioSourceFive;
    private AudioSource audioSourceSix;
    private AudioSource audioSourceSeven;
    private AudioSource audioSourceEight;
    private AudioSource audioSourceNine;
    private AudioSource audioSourceTen;
    private AudioSource audioSourceEleven;
    private AudioSource audioSourceTwelve;
    private AudioSource audioSourceThirteen;
    private AudioSource audioSourceFourteen;
    private AudioSource audioSourceFifteen;
    public AudioClip[] audioClips;
    public float[] audioClipVolumes;
    private List<int> audioQueue = new();

    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    private void Start() {
        audioSourceOne = gameObject.AddComponent<AudioSource>();
        audioSourceTwo = gameObject.AddComponent<AudioSource>();
        audioSourceThree = gameObject.AddComponent<AudioSource>();
        audioSourceFour = gameObject.AddComponent<AudioSource>();
        audioSourceFive = gameObject.AddComponent<AudioSource>();
        audioSourceSix = gameObject.AddComponent<AudioSource>();
        audioSourceSeven = gameObject.AddComponent<AudioSource>();
        audioSourceEight = gameObject.AddComponent<AudioSource>();
        audioSourceNine = gameObject.AddComponent<AudioSource>();
        audioSourceTen = gameObject.AddComponent<AudioSource>();
        audioSourceEleven = gameObject.AddComponent<AudioSource>();
        audioSourceTwelve = gameObject.AddComponent<AudioSource>();
        audioSourceThirteen = gameObject.AddComponent<AudioSource>();
        audioSourceFourteen = gameObject.AddComponent<AudioSource>();
        audioSourceFifteen = gameObject.AddComponent<AudioSource>();
    }

    void Update(){
        if (audioQueue.Count > 0){
            if (!audioSourceOne.isPlaying){
                audioSourceOne.clip = audioClips[audioQueue[0]];
                audioSourceOne.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);
            }
            else if (!audioSourceTwo.isPlaying){
                audioSourceTwo.clip = audioClips[audioQueue[0]];
                audioSourceTwo.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);
            }
            else if (!audioSourceThree.isPlaying){
                audioSourceThree.clip = audioClips[audioQueue[0]];
                audioSourceThree.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);
            }
            else if (!audioSourceFour.isPlaying){
                audioSourceFour.clip = audioClips[audioQueue[0]];
                audioSourceFour.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);
            }
            else if (!audioSourceFive.isPlaying){
                audioSourceFive.clip = audioClips[audioQueue[0]];
                audioSourceFive.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);
            }
            else if (!audioSourceSix.isPlaying){
                audioSourceSix.clip = audioClips[audioQueue[0]];
                audioSourceSix.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);
            }
            else if (!audioSourceSeven.isPlaying){
                audioSourceSeven.clip = audioClips[audioQueue[0]];
                audioSourceSeven.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);
            }
            else if (!audioSourceEight.isPlaying){
                audioSourceEight.clip = audioClips[audioQueue[0]];
                audioSourceEight.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);
            }
            else if (!audioSourceNine.isPlaying){
                audioSourceNine.clip = audioClips[audioQueue[0]];
                audioSourceNine.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);
            }
            
            else if (!audioSourceTen.isPlaying){
                audioSourceTen.clip = audioClips[audioQueue[0]];
                audioSourceTen.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);

            }
            else if (!audioSourceEleven.isPlaying){
                audioSourceEleven.clip = audioClips[audioQueue[0]];
                audioSourceEleven.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);

            }
            else if (!audioSourceTwelve.isPlaying){
                audioSourceTwelve.clip = audioClips[audioQueue[0]];
                audioSourceTwelve.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);

            }
            else if (!audioSourceThirteen.isPlaying){
                audioSourceThirteen.clip = audioClips[audioQueue[0]];
                audioSourceThirteen.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);

            }
            else if (!audioSourceFourteen.isPlaying){
                audioSourceFourteen.clip = audioClips[audioQueue[0]];
                audioSourceFourteen.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);

            }
            else if (!audioSourceFifteen.isPlaying){
                audioSourceFifteen.clip = audioClips[audioQueue[0]];
                audioSourceFifteen.PlayOneShot(audioClips[audioQueue[0]], audioClipVolumes[audioQueue[0]] * TopDownManager.Instance.audioScale);
                audioQueue.RemoveAt(0);

            }
        }
    }


    public void AddToAudioQueue(int index){
        audioQueue.Add(index);
    }
}
