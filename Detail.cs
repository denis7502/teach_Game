using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Detail : MonoBehaviour
{

    [SerializeField]
    private GameObject _Message;

    [SerializeField]
    private GameObject _Count;

    [SerializeField]
    private TextMeshProUGUI _otherDetail;

    [SerializeField]
    private Ship _ship;

    private bool final = false;



    // Start is called before the first frame update
    void Start()
    {
        _otherDetail.text = Scenaty.CountDetail.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Scenaty.CountDetail == 0)
        {
            _otherDetail.text = "Все детали собраны идите к кораблю";
            _Message.SetActive(false);
            if (!final)
            {
                _ship.Fineshed();
                final = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        _Count.SetActive(false);
        Scenaty.CountDetail -= 1;
        _otherDetail.text = Scenaty.CountDetail.ToString();
        gameObject.SetActive(false);
        //Destroy(gameObject);
        _Count.SetActive(true);
    }



}
