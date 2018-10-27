using Listeners;
using System;
using System.Collections;
using UnityEngine;
using static Tools.Runnable;

namespace Tools
{


    public class TimeStuff
    {
        public static MonoBehaviour refe;

        private static void CheckRefe()
        {
            if (!refe)
            {
                refe = Updater.Instance;
            }
        }

        public static void DoAfter(Lambda p, float v)
        {
            CheckRefe();
            refe.StartCoroutine(Future(p, v));
        }
        public static void DoAfter(Runnable p, float v)
        {
            CheckRefe();
            refe.StartCoroutine(Future(p, v));
        }

        public static void DoAfterFrames(Runnable p, int frames)
        {
            CheckRefe();
            refe.StartCoroutine(WaitFramesAndDo(frames, p));
        }
        public static void DoAfterFrames(Lambda p, int frames)
        {
            CheckRefe();
            refe.StartCoroutine(WaitFramesAndDo(frames, p));
        }

        private static IEnumerator WaitFramesAndDo(int frames, Lambda f)
        {
            yield return Frames(frames);
            f?.Invoke();
        }
        private static IEnumerator WaitFramesAndDo(int frames, Runnable f)
        {
            yield return Frames(frames);
            f?.Invoke();
        }

        private static IEnumerator Future(Runnable p, float v)
        {
            yield return new WaitForSecondsRealtime(v);
            p?.Invoke();
        }
        private static IEnumerator Future(Lambda p, float v)
        {
            yield return new WaitForSecondsRealtime(v);
            p?.Invoke();
        }

        public static IEnumerator Frames(int frames)
        {
            for (int i = 0; i < frames; i++)
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }
    


}