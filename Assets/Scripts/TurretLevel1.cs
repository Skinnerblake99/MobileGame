using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLevel1 : MonoBehaviour
{
    //Blake Skinner 07/10/2020 Code sourced from https://www.youtube.com/watch?v=QKhn2kl9_8I&t=32s

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    private Transform target;
    public float turnSpeed = 10f;
    public Transform partToRotate;
    public string enemyTag = "enemyTag";

    public GameObject bulletPrefab;
    public Transform firePoint;

    public int turretLvl;

    public GameObject turretLVLText1;
    public GameObject turretLVLText2;
    public GameObject turretLVLText3;
    public GameObject canvas;

    public bool hasUpgraded1;
    public bool hasUpgraded2;
    public float firstUpgradeCost = 200f;
    public float finalUpgradeCost = 300f;
    float currency;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        turretLvl = 1;
        range = 15f;
        fireRate = 1f;
        turnSpeed = 10f;
        hasUpgraded1 = false;
        hasUpgraded2 = false;
        canvas = this.gameObject.transform.GetChild(2).gameObject;
        turretLVLText1 = canvas.transform.GetChild(0).gameObject;
        turretLVLText2 = canvas.transform.GetChild(1).gameObject;
        turretLVLText3 = canvas.transform.GetChild(2).gameObject;
        turretLVLText1.SetActive(true);
        turretLVLText2.SetActive(false);
        turretLVLText3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime *turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

     void OnMouseDown()
    {
        if (!hasUpgraded1 && PlayerMoney.Money >= firstUpgradeCost)
        {
            Level2();
        }    

        if(hasUpgraded1 &&!hasUpgraded2 && PlayerMoney.Money >= finalUpgradeCost)
        {
            Level3();
        }
    }

    void Shoot()
    {
        //Debug.Log("Shoot");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    void UpdateTarget()
    {
        //Might need to change the way this structure is accessed
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemyTag");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy< shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Level2()
    {
        turretLvl = 2;
        range = 20f;
        fireRate = 1.2f;
        turnSpeed = 12f;
        turretLVLText1.SetActive(false);
        turretLVLText2.SetActive(true);
        turretLVLText3.SetActive(false);
        PlayerMoney.Money -= firstUpgradeCost;
        hasUpgraded1 = true;
    }
    void Level3()
    {
        turretLvl = 3;
        range = 30f;
        fireRate = 1.5f;
        turnSpeed = 15f;
        turretLVLText1.SetActive(false);
        turretLVLText2.SetActive(true);
        turretLVLText3.SetActive(false);
        PlayerMoney.Money -= finalUpgradeCost;
        hasUpgraded2 = true;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
