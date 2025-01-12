using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using TMPro;
using System.Numerics;
public class EffectController : MonoBehaviour
{
    // Start is called before the first frame update
    private float time = 3; //动画播放时间
    public float Time
    {
        get { return time; }
        set
        {
            time = value;
        }
    }
    void Start()
    {
        if (GetComponent<Rigidbody2D>() != null)
        {
            GetComponent<Rigidbody2D>();
        }

        UnityEngine.Vector3 destination = new UnityEngine.Vector3(transform.position.x,transform.position.y+50,transform.position.z);
        this.transform.DOMove(destination,time).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        AutoDestroy();
    }
    void AutoDestroy()
    {
        if (Camera.main.WorldToViewportPoint(this.transform.position).y > 1)
        {
            DOTween.Kill(this.gameObject.transform);
            GameObject.Destroy(this.gameObject);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* Debug.Log("ontriggerEnter2D");
        Debug.Log(collision.gameObject.name);
        TextMeshPro text=collision.gameObject.transform.Find("Health_Text").gameObject.GetComponent<TextMeshPro>();
        float health_flo = float.Parse(text.text);
        health_flo = health_flo - 10;*/
        
    }
}
