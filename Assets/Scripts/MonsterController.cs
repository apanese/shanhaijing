using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
public class Monster
{
    public int id
    {
        get;
        set;
    }
    public int health
    {
        get; set;
    }
    public string sprite { get; set; }
    public string controller {  get; set; }
}

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    private int id;
    private float health;
    private float distance;
    private TextMeshPro textPro;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        textPro = this.gameObject.transform.Find("Health_Text").gameObject.GetComponent<TextMeshPro>();
        health = float.Parse(textPro.text);
        animator.SetFloat("Health", health);
    }
    public void init(int id,string monster_sprite,string monster_controller)
    {
        //GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(monster_sprite);
        //AnimatorController test = Resources.Load<RuntimeAnimatorController>(monster_controller);
        AnimatorController controller = Resources.Load<AnimatorController>(monster_controller);
        GetComponent<Animator>().runtimeAnimatorController = Resources.Load<AnimatorController>(monster_controller);
    }
    void Start()
    {
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relatePosition = this.transform.InverseTransformPoint(GameManager.Instance.role.transform.position);
        //Debug.Log(relatePosition);
        if (relatePosition.y>-2&& relatePosition.x < 1)
        {
            animator.SetBool("ifattack",true);
        }
        else
        {
            animator.SetBool("ifattack", false);
        }
        transform.Translate(new Vector2(0, -GameManager.Instance.scrollspeed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        health = health - 10;
        GetComponent<Animator>().SetFloat("Health", health);
        DOTween.To(() => textPro.text, x => textPro.text = x, health.ToString(), 0.1f);
    }
    
    //public void 
}
