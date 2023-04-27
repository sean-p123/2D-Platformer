using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
   // private static CameraFollowScript _instance;

 /*void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }*/
    
    public float followSpeed = 5;
    public float yOffset = 3;
    public float xOffset = 0;
    [SerializeField] public float zOffset = 13f;
    public Transform target;
    GameObject newTarget;
    private void Start()
    {
        newTarget = GameObject.FindGameObjectWithTag("Player");
        if (newTarget != null)
        {
            target = newTarget.transform;
        }
    }
   
// Update is called once per frame
void Update()
    {
     //   GameObject newTarget = GameObject.FindGameObjectWithTag("Player");

        if (newTarget != null)
        {


            
            if (newTarget != null)
            {
                target = newTarget.transform;
            }
            if (target.position.y > -4)
            {
                Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -zOffset);
                transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
            }

        }

    }

    /*
    void OnEnable()
    {
        GameManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-enable the CameraFollowScript component
        this.enabled = true;
    }*/
}
