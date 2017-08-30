using Microsoft.Kinect;
using System;
namespace KinectSimpleGesture
{
    /// <summary>
    /// Represents a single gesture segment which uses relative positioning of body parts to detect a gesture.
    /// </summary>
    public interface byeGestSegment
    {
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        GesturePartResult byeUpdate(Skeleton skeleton);
    }

    public static class byeGlobals
    {
        public static float dist1 = 0.00f;
        public static float dist2 = 0.00f;
    }

    public class byeGestSegment1 : byeGestSegment
    {

        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        public GesturePartResult byeUpdate(Skeleton skeleton)
        {
            Console.WriteLine("b4");   
                // Hand above elbow
                if ((skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y))
                {
                    Console.WriteLine("if bye");
                    // Hand right of elbow
                     byeGlobals.dist1 = skeleton.Joints[JointType.HandRight].Position.Y - skeleton.Joints[JointType.WristRight].Position.Y;
                        Console.WriteLine("if bye 2");
                        //Globals.depth1=skeleton.Joints[JointType.HandRight].Position.Z;
                        //Console.WriteLine("depth1..here..." + Globals.depth1);

                        return GesturePartResult.Succeeded;
                    
                }
            
            // Hand dropped
            return GesturePartResult.Failed;
        }
    }

    public class byeGestSegment2 : byeGestSegment
    {
        //public float depth2;
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        public GesturePartResult byeUpdate(Skeleton skeleton)
        {
            // Hand above elbow
            Console.WriteLine("b4 if");
            if ((skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y))
            {
                Console.WriteLine("bye right if1");
                // Hand right of elbow
                if (skeleton.Joints[JointType.HandRight].Position.X == skeleton.Joints[JointType.ElbowRight].Position.X)
                {
                    byeGlobals.dist2 = skeleton.Joints[JointType.HandRight].Position.Y - skeleton.Joints[JointType.WristRight].Position.Y;
                    Console.WriteLine("bye right if2");
                    //Globals.depth1=skeleton.Joints[JointType.HandRight].Position.Z;
                    //Console.WriteLine("depth1..here..." + Globals.depth1);

                    return GesturePartResult.Succeeded;
                }
            }
            // Hand dropped
            return GesturePartResult.Failed;
        }
    }
    public class compare_dist : byeGestSegment
    {
        public GesturePartResult byeUpdate(Skeleton skeleton)
        {
            if (byeGlobals.dist1 > byeGlobals.dist2)
            {
                return GesturePartResult.Succeeded;
            }
            return GesturePartResult.Failed;

        }
    }

}
