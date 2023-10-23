using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Chest, Skeleton
}

public abstract class BaseState<T>
{
    public abstract void Enter(T monster);
    public abstract void Update(T monster);
    public abstract void Exit(T monster);
}

public class Monster : MonoBehaviour,IInteractable
{
    public float damage;
    [SerializeField] private float hp;
    public ViewDetector detector;
    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public GameObject damageText;
    public Transform Canvas;
    public Stack<GameObject> textList = new Stack<GameObject>();

    public void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject gameObject = Instantiate(damageText);
            textList.Push(gameObject);
            gameObject.SetActive(false);
            gameObject.transform.parent = Canvas;
            gameObject.transform.position = Canvas.position;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Die()
    {

    }

    public void PlayAnimation()
    {

    }

    public virtual void TakeHit(float damage)
    {
        Hp -= damage;
        Debug.Log(Hp);
    }

    public IEnumerator DestroyCo(GameObject text)
    {
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
        text.transform.position = Canvas.position;
        textList.Push(text);
    }
}
