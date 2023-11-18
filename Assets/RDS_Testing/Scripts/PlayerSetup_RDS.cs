using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerSetup_RDS : MonoBehaviour
{
  public Movement_RDS movement;
  public GameObject camera;

  public string _nickname;

  public TextMeshPro nicknameText;

  public string team;

  public void IsLocalPlayer()
  {
    movement.enabled = true;
    camera.SetActive(true);
  }

  [PunRPC]
  public void SetColor(string _color)
  {
    var renderer = GetComponent<Renderer>();
    team = _color;
    if (team == "blue")
    {
      renderer.material.SetColor("_Color", Color.blue);
    }
    else if (team == "red")
    {
      renderer.material.SetColor("_Color", Color.red);
    }
  }


  [PunRPC]
  public void SetNickname(string _name)
  {
    _nickname = _name;

    nicknameText.text = _nickname;
  }

 
}
