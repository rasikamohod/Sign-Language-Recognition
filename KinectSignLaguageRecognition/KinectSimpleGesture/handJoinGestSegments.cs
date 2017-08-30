using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Kinect;
using System;
using System.Text;

namespace KinectSimpleGesture
{

    /// <summary>
    /// Represents a single gesture segment which uses relative positioning of body parts to detect a gesture.
    /// </summary>
    public interface handJoinGestSegment
    {
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        GesturePartResult handJoinUpdate(Skeleton skeleton);
    }

    
    public class handJoinSegment1 : handJoinGestSegment
    {

        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        public GesturePartResult handJoinUpdate(Skeleton skeleton)
        {
            // Hand above elbow
            //if ((skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y))
            //{
            // Hand right of elbow
            if ((((skeleton.Joints[JointType.HandRight].Position.X - skeleton.Joints[JointType.HandLeft].Position.X) < 0.0005) || ((skeleton.Joints[JointType.HandLeft].Position.X - skeleton.Joints[JointType.HandRight].Position.X) < 0.0005)) && (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y) && (skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.ElbowLeft].Position.Y))
            {
                if ((skeleton.Joints[JointType.ShoulderLeft].Position.X < skeleton.Joints[JointType.HandLeft].Position.X) && (skeleton.Joints[JointType.ShoulderRight].Position.X > skeleton.Joints[JointType.HandRight].Position.X))
                {
                    if ((skeleton.Joints[JointType.ShoulderLeft].Position.Y > skeleton.Joints[JointType.HandLeft].Position.Y) && (skeleton.Joints[JointType.ShoulderRight].Position.Y > skeleton.Joints[JointType.HandRight].Position.Y))
                    {
                        //Console.WriteLine("namaskar");
                        // Globals.depth1 = skeleton.Joints[JointType.HandRight].Position.Z;
                        //                Console.WriteLine("depth1..here..." + Globals.depth1);

                        return GesturePartResult.Succeeded;
                    }
                }
            }
            // }

            // Hand dropped
            return GesturePartResult.Failed;
        }
    }

    /*public class handJoinSegment2 : handJoinGestSegment
    {
        //public float depth2;
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        public GesturePartResult handJoinUpdate(Skeleton skeleton)
        {
            // Hand above elbow
            if (skeleton.Joints[JointType.Head].Position.Y > skeleton.Joints[JointType.HandRight].Position.Y && skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ShoulderCenter].Position.Y)
            {
                if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y)
                {
                    // Hand left of elbow
                    if (skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ElbowRight].Position.X)
                    {
                        Console.WriteLine("left of elbw");
                       // Globals.depth2 = skeleton.Joints[JointType.HandRight].Position.Z;
                        Console.WriteLine("depth2..here..." + Globals.depth2);
                        return GesturePartResult.Succeeded;
                    }
                }
            }
            // Hand dropped
            return GesturePartResult.Failed;
        }
    }*/
   
}
