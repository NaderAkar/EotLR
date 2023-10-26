using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ShopManager : MonoBehaviour
{

    public static int coins;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeScene() {
      SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
