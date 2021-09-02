using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    Transform current;

    // Start is called before the first frame update
    void Start()
    {
        current = transform;
        CreatTail();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatTail()
    {
        // создаем хвост
        // current - текущая цель элемента хвоста, начинаем с головы
        // Transform current = transform;
        for (int i = 0; i < 3; i++)
        {
            // создаем примитив куб и добавляем ему компонент Tail
            PartOfTail partOfTail = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<PartOfTail>();
            // помещаем "хвост" за "хозяина"
            partOfTail.transform.position = current.transform.position - current.transform.up * 2;
            // ориентация хвоста как ориентация хозяина
            partOfTail.transform.rotation = transform.rotation;
            // элемент хвоста должен следовать за хозяином, поэтому передаем ему ссылку на его
            partOfTail.target = current.transform;
            // дистанция между элементами хвоста - 2 единицы
            partOfTail.targetDistance = 1;
            // удаляем с хвоста колайдер, так как он не нужен
            Destroy(partOfTail.GetComponent<Collider>());
            // следующим хозяином будет новосозданный элемент хвоста
            current = partOfTail.transform;
        }
    }

    void IncreaseTail()
    {
        // создаем примитив куб и добавляем ему компонент Tail
        PartOfTail partOfTail = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<PartOfTail>();
        // помещаем "хвост" за "хозяина"
        partOfTail.transform.position = current.transform.position - current.transform.up * 2;
        // ориентация хвоста как ориентация хозяина
        partOfTail.transform.rotation = transform.rotation;
        // элемент хвоста должен следовать за хозяином, поэтому передаем ему ссылку на его
        partOfTail.target = current.transform;
        // дистанция между элементами хвоста - 2 единицы
        partOfTail.targetDistance = 1;
        // удаляем с хвоста колайдер, так как он не нужен
        Destroy(partOfTail.GetComponent<Collider>());
        // следующим хозяином будет новосозданный элемент хвоста
        current = partOfTail.transform;
    }
}
