using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public int count;

    float dtimer = 3.0f;

    [SerializeField] private SceneReference sceneToLoad;
    [SerializeField] private Light directionLight;

    [Header("Loading�摜�̃I�u�W�F�N�g����Ă�������")]
    [SerializeField] GameObject loadingUI;

    // ���[�h�̐i���󋵂��Ǘ����邽�߂̕ϐ�
    private AsyncOperation async;

    [Header("�X�e�[�W�J�ڊJ�n�܂ł̒x������")]
    [SerializeField]
    private float delayTime;
    // ���[�h���J�n���郁�\�b�h
    public void StartLoad()
    {


        StartCoroutine(LoadScene());
    }
    public static SceneChange instance;

    public bool changeFlag = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        directionLight.intensity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            //dtimer -= Time.deltaTime;

            //if (dtimer <= 0)
            //    SceneManager.LoadScene(sceneToLoad);
            //if (GoalZone.instance.gameObject.activeSelf)
            //{
            //    GoalZone.instance.gameObject.SetActive(true);
            //}
        }

        if (ChangeFlag)
        {
            loadingUI.SetActive(true);
            delayTime -= Time.deltaTime;

            if (delayTime <= 0.0f)
            {
                Change();
            }
        }

    }

    public void SubEnemyCount()
    {

        count--;
        //Debug.Log(count);
    }

   public int Count
    {
        set
        {
            count = value;
        }
        get
        {
            return count;
        }
    }

    public void Change()
    {
        StartLoad();
    }

    private IEnumerator LoadScene()
    {
        
        // �V�[����񓯊��Ń��[�h����
        async = SceneManager.LoadSceneAsync(sceneToLoad);
       
        
        while (true)
        {
            //async.allowSceneActivation = false;
            yield return null;
            //if (async.progress >= 0.9f)
            //{

            //    async.allowSceneActivation = true;
            //    // ���[�h�o�[��100%�ɂȂ��Ă�1�b�����\���ێ�
            //    yield return new WaitForSeconds(0);
            //    break;
            //}
            // Debug.Log(async.progress);

        }






        // ���[�h��ʂ��\���ɂ���
        loadingUI.SetActive(false);

        
    }


    public bool ChangeFlag
    {
        set
        {
            changeFlag = value;
        }
        get
        {
            return changeFlag;
        }
    }

}
