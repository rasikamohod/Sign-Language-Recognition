using Microsoft.Kinect;
using System;
namespace KinectSimpleGesture
{
    /// <summary>
    /// Represents a single gesture segment which uses relative positioning of body parts to detect a gesture.
    /// </summary>
    public interface IGestureSegment
    {
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        GesturePartResult Update(Skeleton skeleton);
    }

    
    public class WaveSegment1 : IGestureSegment
    {
        
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        public GesturePartResult Update(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.Head].Position.Y < skeleton.Joints[JointType.HandRight].Position.Y)
            {
                // Hand above elbow
                if ((skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y))
                {
                    // Hand right of elbow
                    if (skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowRight].Position.X)
                    {
                        //Console.WriteLine("right of elbw");
                        //Globals.depth1=skeleton.Joints[JointType.HandRight].Position.Z;
                        //Console.WriteLine("depth1..here..." + Globals.depth1);

                        return GesturePartResult.Succeeded;
                    }
                }
            }
            // Hand dropped
            return GesturePartResult.Failed;
        }
    }

    public class WaveSegment2 : IGestureSegment
    {
        //public float depth2;
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        public GesturePartResult Update(Skeleton skeleton)
        {
            // Hand above elbow
            if (((skeleton.Joints[JointType.Head].Position.Y - skeleton.Joints[JointType.HandRight].Position.Y) < 0.5) || ((skeleton.Joints[JointType.HandRight].Position.Y - skeleton.Joints[JointType.Head].Position.Y) < 0.5))
            {
            if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y)
            {
                // Hand left of elbow
                if (skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ElbowRight].Position.X)
                {
                    //Console.WriteLine("left of elbw");
                    //Globals.depth2=skeleton.Joints[JointType.HandRight].Position.Z;
                    //Console.WriteLine("depth2..here..." + Globals.depth2);
                    return GesturePartResult.Succeeded;
                }
            }
            }
            // Hand dropped
            return GesturePartResult.Failed;
        }
    }
  

}
