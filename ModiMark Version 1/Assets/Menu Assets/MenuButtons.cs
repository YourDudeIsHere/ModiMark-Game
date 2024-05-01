using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
   
    public Button Play;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnMouseExit()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Play = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
 
   
}
