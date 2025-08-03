using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private List<PlayerInputFrame> recordedFrames = new List<PlayerInputFrame>();
    public static GameManager Instance;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private SpriteRenderer overlay;
    [SerializeField] private DialogueManager dialogueManager;

    public int deathCounter = 0;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        DialogueSystem.DialogueHolder.OnDialogueHolderFinished += EnableGameplayControls;
    }

    IEnumerator Start()
    {
        overlay.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        overlay.DOFade(0, 0.7f);

        SetPlayerPosition();
        
        deathCounter = 0;
    }

    public void SetPlayerPosition()
    {
        //dialogueManager.PlayNextDialogue();
        player.GetComponent<Health>().Heal(100);
        player.GetComponent<Health>().hp = 100;
        player.GetComponent<Health>().UIUpdate();
        boss.GetComponent<InputReciver>().isPlaying = false;
        player.GetComponent<PlayerInput>().enabled = false;
        player.GetComponent<Collider2D>().enabled = false;
        boss.GetComponent<Collider2D>().enabled = false;
        player.transform.position = playerSpawnPoint.position;
        player.transform.localScale = Vector3.one;
        Color color = player.GetComponent<SpriteRenderer>().color;
        color.a = 1;    
        player.GetComponent<SpriteRenderer>().color = color;
        var moveTween = player.transform.DOMoveX(-8, 1.8f);
        if (!dialogueManager.TryPlayNextDialogue())
        {
            moveTween.OnComplete(() =>
            {
                EnableGameplayControls();
            });
        }
    }

    private void EnableGameplayControls()
    {
        player.GetComponent<PlayerInput>().enabled = true;
        player.GetComponent<PlayerInput>().StartNewRecording();
        player.GetComponent<Collider2D>().enabled = true;
        boss.GetComponent<InputReciver>().isPlaying = true;
        boss.GetComponent<Collider2D>().enabled = true;
        boss.GetComponent<Weapon>().canShoot = true;
    }

    public void setRecordedFrames(List<PlayerInputFrame> recordedFrames)
    {
        this.recordedFrames = new List<PlayerInputFrame>(recordedFrames);
    }

    public List<PlayerInputFrame> getRecordedFrames()
    {
        return recordedFrames;
    }

    public void StartNewRun(bool isPlayerDead)
    {
        deathCounter++;
        if (deathCounter == 1)
        {
            
        }
        if (deathCounter == 2)
        {
            
        }

        boss.transform.DOMove(enemySpawnPoint.position, 0.5f);
        boss.GetComponent<Health>().Heal(100);
        boss.SetActive(true);
    }

    public Transform GetBossSpawnPoint()
    {
        return enemySpawnPoint;
    }
    
    void setPlayer()
    {
        
    }

}
