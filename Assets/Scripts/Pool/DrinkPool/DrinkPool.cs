﻿using UnityEngine;

namespace Kekw.Pool
{
    /// <summary>
    /// Pool for all the drinks for 'random' spawning.
    /// </summary>
    class DrinkPool: APool
    {
        [SerializeField]
        [Tooltip("Array of available drinks in game.")]
        GameObject[] _drinkPoolObjects;

        /// <summary>
        /// <seealso cref="APool"/>
        /// </summary>
        protected override void InitializePool()
        {
            for (int i = 0; i < _size; i++)
            {
                GameObject temp = Instantiate(_drinkPoolObjects[Random.Range(0, _drinkPoolObjects.Length)]);
                temp.SetActive(false);
                temp.transform.position = this.transform.position;
                _pool.Enqueue(temp.GetComponent<APoolMember>());
            }
        }
    }
}
