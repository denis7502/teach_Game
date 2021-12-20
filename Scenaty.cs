using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scenaty : MonoBehaviour
{
    [SerializeField]
    private List<Detail> _Detail;

    int k = 1;

    public static int CountDetail = 1;

    Vector3 temp ;



    // Start is called before the first frame update
    void Start()
    {
        temp = _Detail[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDetail != k)
        {
            SpawnPosition();
            k -= 1;

        }

    }
    public void SpawnPosition()
    {
        List<Detail> _DetailCopy = _Detail;

        if (_Detail.Count != 0 & k > 0)
        {
            int index = Random.Range(0, 5);
            int index_1 = Random.Range(0, k);
            Vector3 SpawnPosition = _DetailCopy[index].transform.position;
            while (SpawnPosition == temp)
            {
                index = Random.Range(0, 5);
                SpawnPosition = _DetailCopy[index].transform.position;
            }
            
            temp = SpawnPosition;

            Instantiate(_Detail[index_1], SpawnPosition, Quaternion.identity).gameObject.SetActive(true);

            ///_Detail.Remove(_Detail[index_1]);
        }
    }
}
