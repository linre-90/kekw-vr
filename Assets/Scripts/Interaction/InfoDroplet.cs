﻿using UnityEngine;
using System.Collections;

namespace Kekw.Interaction
{
    /// <summary>
    /// Info droplets tell player info about school
    /// </summary>
    class InfoDroplet: MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Audio that this droplet plays")]
        AudioSource _audioSource;

        [SerializeField]
        [Tooltip("Animator for this droplet")]
        Animator _animator;

        [SerializeField]
        [Tooltip("Audio play delay")]
        float _delay = 1f;

        private void OnTriggerEnter(Collider other)
        {
            // Start talkin when player enters trigger
            if (other.CompareTag("Player") && !_audioSource.isPlaying)
            {
                _audioSource.PlayDelayed(_delay);
                _animator.SetBool("Talking", true);
                StartCoroutine(ResetTalkAnimation(_audioSource.clip.length + _delay));
            }
        }

        /// <summary>
        /// Reset talking animation after clip is played
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        IEnumerator ResetTalkAnimation(float time)
        {
            yield return new WaitForSecondsRealtime(time);
            _animator.SetBool("Talking", false);
        }
    }
}
