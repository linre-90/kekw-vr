﻿using UnityEngine;
using System.Collections;
using Kekw.Interaction;

namespace Kekw.Pool
{
    /// <summary>
    /// Behaviour of drinks
    /// </summary>
    class DrinkPoolMember: APoolMember
    {
        Coroutine _destroyDelay;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("KillPlane"))
            {
                if(_destroyDelay == null)
                {
                    _destroyDelay = StartCoroutine(Delay());
                }
            }
        }

        IEnumerator Delay()
        {
            // 5 second timer.
            yield return new WaitForSeconds(5f);
            _destroyDelay = null;
            if(_ownerPool != null){
                this.gameObject.GetComponentInChildren<Vatupassi>().DestroyTrackedVFX();
                _ownerPool.ReturnToPool(this.gameObject);
            }
            // Raise event that notifies spawners that: "Hey one of you should do something! For fuck sake we are missing drink!"
            DrinkSpawnManager.RaiseEvent();
        }
    }
}
