using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Setting.Player))
        {
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                switch (gameObject.tag)
                {
                    case Setting.TagGress:
                        collision.gameObject.GetComponent<Player>().PlayerAudio.IsOnGress = true;
                        break;

                    case Setting.TagWood:
                        collision.gameObject.GetComponent<Player>().PlayerAudio.IsOnWood = true;
                        break;

                    case Setting.TagMetal:
                        collision.gameObject.GetComponent<Player>().PlayerAudio.IsOnMetal = true;
                        break;
                }
            }
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(Setting.Player))
        {
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                switch (gameObject.tag)
                {
                    case Setting.TagGress:
                        collision.gameObject.GetComponent<Player>().PlayerAudio.IsOnGress = false;
                        break;

                    case Setting.TagWood:
                        collision.gameObject.GetComponent<Player>().PlayerAudio.IsOnWood = false;
                        break;

                    case Setting.TagMetal:
                        collision.gameObject.GetComponent<Player>().PlayerAudio.IsOnMetal = false;
                        break;
                }
            }
        }
    }
}
