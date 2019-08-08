using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    public GameWeights gameWeights;
    public LevelGenerator levelGenerator;
    public UIGameScreen uiGameScreen;
    public static Game Instance;
    [HideInInspector]
    public Transform mainCameraTransform;
    public SmoothFollowCamera smothCam;
    public Transform targetCamera;
    public Player player;
    public bool isGameOver = false;
    public FallDistanceMeter fallDistanceMeter = new FallDistanceMeter();
    public TouchWallDistanceMeter touchWallDistanceMeter = new TouchWallDistanceMeter();
    public CharactersCollection charactersCollection;
    CharacterInitializer chi;
    public ParticleSystem particleDie;
    int counterInternalRetry = 0;

    private void Awake()
    {
        Instance = this;
        CreateCharacter(Vector3.zero);
    }

    void CreateCharacter(Vector3 position)
    {
        GameObject character = GameObject.Instantiate(charactersCollection.characters[DataMan.Instance.charactersData.CurrentSkin].playerPrefab);
        character.transform.position = position;
        chi = character.GetComponent<CharacterInitializer>();
        player = chi.player;
    }

    private void Start()
    {
        this.smothCam.SetTarget(chi.pivot);
        EventsMan.Instance.Call_OnNewGameStart();
    }

    public void GameOver()
    {
        if (counterInternalRetry < 1)
        {
            Game.Instance.GetComponent<DieAnimation>().OnDie();
            this.isGameOver = true;
            Time.timeScale = 1;
            this.smothCam.RemoveTarget();
            EventsMan.Instance.Call_OnGameOver();
            DataMan.Instance.userData.LastScore = this.fallDistanceMeter.meters;
            this.CheckBestScore();
            this.uiGameScreen.OnGameOverWithRespawnOption();
            GameObject.Destroy(chi.gameObject);
            this.player = null;
            this.chi = null;

        }
        else
        {
            this.uiGameScreen.OnGameOver();

        }

        counterInternalRetry++;
    }

    public void RespawnPlayer()
    {
        Block block = levelGenerator.BlockFactory.GetFirstBlock();
        CreateCharacter(block.starPoint.position);
        this.isGameOver = false;
        Time.timeScale = 1;
        this.smothCam.SetTarget(chi.pivot);
    }
   
    void CheckBestScore()
    {
        if (this.fallDistanceMeter.meters > DataMan.Instance.userData.BestScore)
        {
            DataMan.Instance.userData.BestScore = this.fallDistanceMeter.meters;
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Break();
    }
}
