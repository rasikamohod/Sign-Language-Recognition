using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;

namespace KinectSimpleGesture
{
    class Program

    {
        static WaveGesture _gesture = new WaveGesture();
        static ThankuGestu thanku_gesture = new ThankuGestu();
        static handJoinGestu handJoin_gesture = new handJoinGestu();
        static WhatGesture what_gesture = new WhatGesture();

        //static byeGestu _byegesture = new byeGestu();
        static void Main(string[] args)
        {
            var sensor = KinectSensor.KinectSensors.Where(s => s.Status == KinectStatus.Connected).FirstOrDefault();
            Console.WriteLine("hello.....");
            if (sensor != null)
            {
                Console.WriteLine("hello.....");
                sensor.SkeletonStream.Enable();
                sensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated; // Use seated tracking
                sensor.SkeletonFrameReady += Sensor_SkeletonFrameReady;
                //Console.WriteLine("hello.....skelton ready");
                _gesture.GestureRecognized += Gesture_GestureRecognized;
                thanku_gesture.GestureRecognized += Gesture_GestureRecognized;
                handJoin_gesture.GestureRecognized += Gesture_GestureRecognized;
                what_gesture.GestureRecognized += Gesture_GestureRecognized;
                //_byegesture.GestureRecognized += Gesture_GestureRecognized;
                sensor.Start();
            }

            Console.ReadKey();
        }

        static void Sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (var frame = e.OpenSkeletonFrame())
            {
                if (frame != null)
                {
                    Skeleton[] skeletons = new Skeleton[frame.SkeletonArrayLength];

                    frame.CopySkeletonDataTo(skeletons);

                    if (skeletons.Length > 0)
                    {
                        var user = skeletons.Where(u => u.TrackingState == SkeletonTrackingState.Tracked).FirstOrDefault();
                        //Console.WriteLine("b4");
                        if (user != null)
                        {
                            //Console.WriteLine("afta");
                            _gesture.Update(user);
                            thanku_gesture.thankuUpdate(user);
                            handJoin_gesture.handJoinUpdate(user);
                            what_gesture.whatUpdate(user);
                            //_byegesture.byeUpdate(user);
                        }
                    }
                }
            }
        }

        static void Gesture_GestureRecognized(object sender, EventArgs e)
        {
            WaveGesture wg=new WaveGesture();
            ThankuGestu tg = new ThankuGestu();
            handJoinGestu ng = new handJoinGestu();
            WhatGesture whatg = new WhatGesture();
            //byeGestu bg = new byeGestu();
            if (sender.GetType().Name.ToString().Equals(wg.GetType().Name.ToString()))
            {
                Console.WriteLine("Hello!!");
                using (SpeechSynthesizer synth =
                new SpeechSynthesizer())
                {
                    synth.Speak("Hello");
                }
            }
            else if (sender.GetType().Name.ToString().Equals(tg.GetType().Name.ToString()))
            {
                Console.WriteLine("Thanku!");
                using (SpeechSynthesizer synth =
                new SpeechSynthesizer())
                {
                    synth.Speak("Thank You");
                }
            }
            else if (sender.GetType().Name.ToString().Equals(ng.GetType().Name.ToString()))
            {
                Console.WriteLine("namaste");
                using (SpeechSynthesizer synth =
                new SpeechSynthesizer())
                {
                    synth.Speak("namaste");
                }
            }
            else if (sender.GetType().Name.ToString().Equals(whatg.GetType().Name.ToString()))
            {
                Console.WriteLine("What is");
                using (SpeechSynthesizer synth =
                new SpeechSynthesizer())
                {
                    synth.Speak("What is");
                }
            }
           /* else if (sender.GetType().Name.ToString().Equals(bg.GetType().Name.ToString()))
            {
                Console.WriteLine("Bye");
                using (SpeechSynthesizer synth =
                new SpeechSynthesizer())
                {
                    synth.Speak("bye");
                }
            }*/
        }
    }
}
