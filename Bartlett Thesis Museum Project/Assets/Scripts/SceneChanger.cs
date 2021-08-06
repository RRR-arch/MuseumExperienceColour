using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;




public class SceneChanger : MonoBehaviour
{
	public string sceneName;
	

    private void Start()
    {
		//SceneManager.LoadScene(scenenames[0], LoadSceneMode.Single);

	}


    public string ChangeScene()
	{
		return sceneName;
	}

	public void Exit()
	{
		Application.Quit();
	}

}
