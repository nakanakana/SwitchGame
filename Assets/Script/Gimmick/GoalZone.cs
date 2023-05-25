using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    public static GoalZone instance;
    private MeshRenderer meshRenderer=null;
    private BoxCollider collider=null;
    public GameObject particleObject;
    [SerializeField]
    private ParticleSystem particle;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
        meshRenderer.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneChange.instance.Count <= 0)
        {
            //if (!meshRenderer.enabled)
            //{
            //    meshRenderer.enabled = true;
            //}
            if (!collider.enabled)
            {
                collider.enabled = true;
                ParticleSystem newParticle = Instantiate(particle);
                newParticle.transform.position = this.transform.position;
                newParticle.Play();

            }
            
        }

        //if (SceneChange.instance.ChangeFlag)
        //{
        //    SceneChange.instance.Change();
        //}


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneChange.instance.ChangeFlag = true;

        }
    }




    }
