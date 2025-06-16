using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Movmement")]
    public List<Transform> waypoints = new List<Transform>();
    private int targetIndex = 1;
    public float movementSpeed = 4;
    public float rotationSpeed = 6;
    private Animator anim;

    [Header("Life")]
    private bool isDead;
    public float maxLife = 100;
    public float currentLife = 0;
    public Image fillLifeImage;
    private Transform canvasRoot;
    private Quaternion initLifeRotation;

    private void Awake()
    {
        canvasRoot = fillLifeImage.transform.parent.parent;
        initLifeRotation = canvasRoot.rotation;
        anim = GetComponent<Animator>();
        anim.SetBool("Movement", true);
        GetWaypoints();
        // currentLife = maxLife;
    }

    private void Start()
    {
        currentLife = maxLife;
    }
    private void GetWaypoints()
    {
        waypoints.Clear();
        var rootWaypoints = GameObject.Find("WaypointsContainer").transform;
        for (int i = 0; i < rootWaypoints.childCount; i++)
        {
            waypoints.Add(rootWaypoints.GetChild(i));
        }

    }
    // Update is called once per frame
    void Update()
    {
            canvasRoot.transform.rotation = initLifeRotation;
        Movement();
        LookAt();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }

    }

    #region Movment & Rotations
    private void Movement()
    {
        if (isDead)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, movementSpeed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, waypoints[targetIndex].position);
        if (distance <= 0.1f)
        {
            if (targetIndex >= waypoints.Count - 1)
            {
                Debug.Log("Llegaste al final");
                return;
            }
            targetIndex++;
        }
    }
    private void LookAt()
    {
        if (isDead)
        {
            return;
        }
        //transform.LookAt(waypoints[targetIndex]);
        //1) obtener la dirección
        var dir = waypoints[targetIndex].position - transform.position;
        //2) obtener rotación segun dirección.
        var rootTarget = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rootTarget, rotationSpeed * Time.deltaTime);
    }
    #endregion


    public void TakeDamage(float dmg)
    {
        var newLife = currentLife - dmg;
        if (isDead)
            return;
        
        if (newLife <= 0)
        {
            OnDead();
        }
        currentLife = newLife;
        //maxLife 100 - 1
        //currentLife ?
        var fillValue = currentLife * 1 / 100;
        fillLifeImage.fillAmount = fillValue;
        currentLife = newLife;
        StartCoroutine(AnimationDamge());        
    }

    private IEnumerator AnimationDamge()
    {
        anim.SetBool("TakeDamage", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("TakeDamage", false);
    }
    private void OnDead()
    {
        isDead = true;
        anim.SetBool("TakeDamage", false);
        anim.SetBool("Die", true);
        currentLife = 0;
        fillLifeImage.fillAmount = 0;
        StartCoroutine(OnDeadEffect());
    }
    private IEnumerator OnDeadEffect()
    {
        yield return new WaitForSeconds(1f);
        var finalPositionY = transform.position.y - 5;
        Vector3 target = new Vector3(transform.position.x, finalPositionY, transform.position.z);
        while (transform.position.y != finalPositionY)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 1.5f * Time.deltaTime);
            yield return null;
        }
    }

}
