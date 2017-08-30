using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System;

namespace KinectSimpleGesture
{
    class WhatGesture
    {
        readonly int WINDOW_SIZE = 30;

        WhatGestureSegment[] _whatsegments;

        int _whatcurrentSegment = 0;
        int _whatframeCount = 0;

        public event EventHandler GestureRecognized;

        public WhatGesture()
        {
            WhatSegment1 waveRightSegment1 = new WhatSegment1();
            //WhatSegment2 waveRightSegment2 = new WhatSegment2();

            //compare_depth d = new compare_depth(); 
            //Console.WriteLine("depth.....");
            _whatsegments = new WhatGestureSegment[]
            {
                //waveRightSegment2,
                waveRightSegment1,
                waveRightSegment1
            };
        }

        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton data.</param>
        public void whatUpdate(Skeleton skeleton)
        {
            //if (_currentSegment != 0)
            //{
            GesturePartResult result = _whatsegments[_whatcurrentSegment].whatUpdate(skeleton);
            //Console.WriteLine("after update");
            if (result == GesturePartResult.Succeeded)
            {
                if (_whatcurrentSegment + 1 < _whatsegments.Length)
                {

                    _whatcurrentSegment++;
                    _whatframeCount = 0;
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
            else if (result == GesturePartResult.Failed || _whatframeCount == WINDOW_SIZE)
            {
                Reset();
            }
            else
            {
                _whatframeCount++;
            }
            //}
        }

        /// <summary>
        /// Resets the current gesture.
        /// </summary>
        public void Reset()
        {
            _whatcurrentSegment = 0;
            _whatframeCount = 0;
        }
    }

}
