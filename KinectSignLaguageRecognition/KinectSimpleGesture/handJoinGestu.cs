using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System;

namespace KinectSimpleGesture
{
    class handJoinGestu
    {
        readonly int WINDOW_SIZE = 50;

        handJoinGestSegment[] _handJoinsegments;

        int _handcurrentSegment = 0;
        int _handframeCount = 0;

        public event EventHandler GestureRecognized;

        public handJoinGestu()
        {
            handJoinSegment1 waveRightSegment1 = new handJoinSegment1();
            //handJoinSegment2 waveRightSegment2 = new handJoinSegment2();

            //compare_depth d = new compare_depth();
            //Console.WriteLine("depth.....");
            _handJoinsegments = new handJoinGestSegment[]
            {
                //waveRightSegment2,
                waveRightSegment1
                //waveRightSegment1
                //waveRightSegment2,
                //waveRightSegment1,
               // waveRightSegment2
            };
        }

        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton data.</param>
        public void handJoinUpdate(Skeleton skeleton)
        {
            //if (_currentSegment != 0)
            //{
            GesturePartResult result = _handJoinsegments[_handcurrentSegment].handJoinUpdate(skeleton);
            //Console.WriteLine("after update");
            if (result == GesturePartResult.Succeeded)
            {
                if (_handcurrentSegment + 1 < _handJoinsegments.Length)
                {

                    _handcurrentSegment++;
                    _handframeCount = 0;
                }
                else
                {
                    if (GestureRecognized != null)
                    {
                        GestureRecognized(this, new EventArgs());
                        Reset();
                    }
                }
            }
            else if (result == GesturePartResult.Failed || _handframeCount == WINDOW_SIZE)
            {
                Reset();
            }
            else
            {
                _handframeCount++;
            }
            //}
        }

        /// <summary>
        /// Resets the current gesture.
        /// </summary>
        public void Reset()
        {
            _handcurrentSegment = 0;
            _handframeCount = 0;
        }
    }

}
