using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ResimOynat2 : MonoBehaviourPunCallbacks
{
    public List<RawImage> images; // RawImage listesi olarak değiştirildi
    public Button nextButton;
    public Button prevButton;
    private int index;

    public void ToggleLeft()
    {
        images[index].enabled = false; // setActive yerine enabled kullanıldı
        index--;
        if (index < 0)
            index = images.Count - 1;
        images[index].enabled = true; // setActive yerine enabled kullanıldı
    }

    public void ToggleRight()
    {
        images[index].enabled = false; // setActive yerine enabled kullanıldı
        index++;
        if (index == images.Count)
            index = 0;
        images[index].enabled = true; // setActive yerine enabled kullanıldı
    }

    [PunRPC]
    public void NextImageRPC()
    {
        ToggleRight();
    }

    [PunRPC]
    public void PrevImageRPC()
    {
        ToggleLeft();
    }

    public void OnNextButtonPressed()
    {
        photonView.RPC("NextImageRPC", RpcTarget.AllBuffered);
    }

    public void OnPrevButtonPressed()
    {
        photonView.RPC("PrevImageRPC", RpcTarget.AllBuffered);
    }
}
