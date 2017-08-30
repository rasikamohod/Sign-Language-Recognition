using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System;

namespace KinectSimpleGesture
{
    class ThankuGestu
    {
        readonly int WINDOW_SIZE = 30;

        ThankuGestureSegment[] _thankusegments;

        int _thankucurrentSegment = 0;
        int _thankuframeCount = 0;

        public event EventHandler GestureRecognized;

        public ThankuGestu()
        {
            ThankuSegment1 waveRightSegment1 = new ThankuSegment1();
            ThankuSegment2 waveRightSegment2 = new ThankuSegment2();

            //compare_depth d = new compare_depth(); 
               //Console.WriteLine("depth.....");
               _thankusegments = new ThankuGestureSegment[]
            {
                waveRightSegment2,
                waveRightSegment1
            };
        }

        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton data.</param>
        public void thankuUpdate(Skeleton skeleton)
        {
            //if (_currentSegment != 0)
            //{
            GesturePartResult result = _thankusegments[_thankucurrentSegment].thankuUpdate(skeleton);
                //Console.WriteLine("after update");
                if (result == GesturePartResult.Succeeded)
                {
                    if (_thankucurrentSegment + 1 < _thankusegments.Length)
                    {

                        _thankucurrentSegment++;
                        _thankuframeCount = 0;
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
                else if (result == GesturePartResult.Failed || _thankuframeCount == WINDOW_SIZE)
                {
                    Reset();
                }
                else
                {
                    _thankuframeCount++;
                }
            //}
        }

        /// <summary>
        /// Resets the current gesture.
        /// </summary>
        public void Reset()
        {
            _thankucurrentSegment = 0;
            _thankuframeCount = 0;
        }
    }
    
}
