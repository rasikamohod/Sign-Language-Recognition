using Microsoft.Kinect;
using System;

namespace KinectSimpleGesture
{
    public class byeGestu
    {
        readonly int WINDOW_SIZE = 50;

        byeGestSegment[] _byesegments;

        int _byecurrentSegment = 0;
        int _byeframeCount = 0;

        public event EventHandler GestureRecognized;

        public byeGestu()
        {
            byeGestSegment1 waveRightSegment1 = new byeGestSegment1();
            byeGestSegment2 waveRightSegment2 = new byeGestSegment2();
            compare_dist d = new compare_dist();
            //Console.WriteLine("byeee");
            _byesegments = new byeGestSegment[]
            {
                waveRightSegment1,
                waveRightSegment2,
                d
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
        public void byeUpdate(Skeleton skeleton)
        {
            //if (_currentSegment != 0)
            //{
            GesturePartResult result = _byesegments[_byecurrentSegment].byeUpdate(skeleton);
            //Console.WriteLine("after update");
            if (result == GesturePartResult.Succeeded)
            {
                if (_byecurrentSegment + 1 < _byesegments.Length)
                {

                    _byecurrentSegment++;
                    _byeframeCount = 0;
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
            else if (result == GesturePartResult.Failed || _byeframeCount == WINDOW_SIZE)
            {
                Reset();
            }
            else
            {
                _byeframeCount++;
            }
            //}
        }

        /// <summary>
        /// Resets the current gesture.
        /// </summary>
        public void Reset()
        {
            _byecurrentSegment = 0;
            _byeframeCount = 0;
        }
    }
}
