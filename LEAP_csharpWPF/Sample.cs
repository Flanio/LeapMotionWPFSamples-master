/******************************************************************************\
* Copyright (C) 2012-2014 Leap Motion, Inc. All rights reserved.               *
* Leap Motion proprietary and confidential. Not for distribution.              *
* Use subject to the terms of the Leap Motion SDK Agreement available at       *
* https://developer.leapmotion.com/sdk_agreement, or another agreement         *
* between Leap Motion and you, your company or other organization.             *
\******************************************************************************/
using System;
using System.Threading;
using Leap;

class SampleListener : Listener
{
    private Object thisLock = new Object();

    private void SafeWriteLine(String line)
    {
        //lock (thisLock)
        {
            Console.WriteLine(line);
        }
    }

    public override void OnInit(Controller controller)
    {
        SafeWriteLine("Initialized");
    }

    public override void OnConnect(Controller controller)
    {
        SafeWriteLine("Connected");
        controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
        controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
        controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
        controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
    }

    public override void OnDisconnect(Controller controller)
    {
        //Note: not dispatched when running in a debugger.
        SafeWriteLine("Disconnected");
    }

    public override void OnExit(Controller controller)
    {
        SafeWriteLine("Exited");
    }

    public override void OnFrame(Controller controller)
    {
        // Get the most recent frame and report some basic information
        Frame frame = controller.Frame();

        SafeWriteLine("Frame id: " + frame.Id
                    + ", timestamp: " + frame.Timestamp
                    + ", hands: " + frame.Hands.Count
                    + ", fingers: " + frame.Fingers.Count
                    + ", tools: " + frame.Tools.Count
                    + ", gestures: " + frame.Gestures().Count);
        #region hand
        /*
        foreach (Hand hand in frame.Hands)
        {
            SafeWriteLine("  Hand id: " + hand.Id
                        + ", palm position: " + hand.PalmPosition);
            // Get the hand's normal vector and direction
            Vector normal = hand.PalmNormal;
            Vector direction = hand.Direction;

            // Calculate the hand's pitch, roll, and yaw angles
            SafeWriteLine("  Hand pitch: " + direction.Pitch * 180.0f / (float)Math.PI + " degrees, "
                        + "roll: " + normal.Roll * 180.0f / (float)Math.PI + " degrees, "
                        + "yaw: " + direction.Yaw * 180.0f / (float)Math.PI + " degrees");

            // Get the Arm bone
            Arm arm = hand.Arm;
            SafeWriteLine("  Arm direction: " + arm.Direction
                        + ", wrist position: " + arm.WristPosition
                        + ", elbow position: " + arm.ElbowPosition);

            // Get fingers
            foreach (Finger finger in hand.Fingers)
            {
                SafeWriteLine("    Finger id: " + finger.Id
                            + ", " + finger.Type.ToString()
                            + ", length: " + finger.Length
                            + "mm, width: " + finger.Width + "mm");

                // Get finger bones
                Bone bone;
                foreach (Bone.BoneType boneType in (Bone.BoneType[])Enum.GetValues(typeof(Bone.BoneType)))
                {
                    bone = finger.Bone(boneType);
                    SafeWriteLine("      Bone: " + boneType
                                + ", start: " + bone.PrevJoint
                                + ", end: " + bone.NextJoint
                                + ", direction: " + bone.Direction);
                }
            }

        }
        
        if (!frame.Hands.IsEmpty || !frame.Gestures().IsEmpty)
        {
            SafeWriteLine("");
        }
        */
        #endregion
    }

}

class Sample
{
    //public void initSample()
    public Sample()
    {
        // Create a sample listener and controller
        SampleListener listener = new SampleListener();
        Controller controller = new Controller();

        // Have the sample listener receive events from the controller
        controller.AddListener(listener);

        // Keep this process running until Enter is pressed
        Console.WriteLine("Press Enter to quit...");
        Console.ReadLine();

        // Remove the sample listener when done
        //controller.RemoveListener(listener);
        //controller.Dispose();
    }
}

