using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasicAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Rota en 360º el sprite, da como efecto 3D
            //transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
        //Sube y baja el sprite
            transform.DOLocalMoveY(0.5f, 2f, false).SetLoops(-1, LoopType.Yoyo).SetRelative().SetEase(Ease.Linear);
    }

    public void KillAnimation()
    {
        transform.DOKill();
    }

}
