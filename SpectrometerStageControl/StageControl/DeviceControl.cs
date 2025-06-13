using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Thorlabs.MotionControl.DeviceManagerCLI;
using Thorlabs.MotionControl.GenericMotorCLI;
using Thorlabs.MotionControl.GenericMotorCLI.ControlParameters;
using Thorlabs.MotionControl.GenericMotorCLI.AdvancedMotor;
using Thorlabs.MotionControl.GenericMotorCLI.KCubeMotor;
using Thorlabs.MotionControl.GenericMotorCLI.Settings;
using Thorlabs.MotionControl.KCube.DCServoCLI;

namespace SpectrometerStageControl
{
    public class DeviceControl
    {
        #region Class Members
        private string serialNumber_;
        private KCubeDCServo device_;
        private bool isHomed_;
        #endregion

        public DeviceControl(string serialNumber)
        {
            try
            {
                if (!checkDeviceList(serialNumber))
                    throw new InvalidOperationException("Device does not exist.");

                serialNumber_ = serialNumber;
                device_ = KCubeDCServo.CreateKCubeDCServo(serialNumber_);

                // Connect to device
                try
                {
                    Console.WriteLine($"Opening {serialNumber} device.");
                    device_.Connect(serialNumber_);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to open device {serialNumber}");
                    throw ex;
                }

                if (!device_.IsSettingsInitialized())
                {
                    try
                    {
                        Console.WriteLine("Initializing Settings");
                        device_.WaitForSettingsInitialized(5000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Settings failed to initialize. {ex.StackTrace}");
                        throw ex;
                    }
                }

                // Start polling
                device_.StartPolling(250);
                Thread.Sleep(500);

                // Enable the device
                device_.EnableDevice();
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating DeviceControl: {ex.Message}");
                throw;
            }
        }

        public void Disconnect() 
        {
            device_.StopPolling();
            device_.Disconnect(true);
        }

        private bool checkDeviceList(string sn)
        {
            try
            { 
                // Tell the device manager to get the list of all devices connected to the computer
                DeviceManagerCLI.BuildDeviceList();

                List<string> serialNumbers = DeviceManagerCLI.GetDeviceList(KCubeDCServo.DevicePrefix);
                if (!serialNumbers.Contains(sn))
                {
                    Console.WriteLine($"{sn} is not a valid serial number");
                    Console.ReadKey();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // An error occurred - see ex for details
                Console.WriteLine($"Exception raised by BuildDeviceList {ex}");
                Console.ReadKey();
                return false;
            }
        }

        public void InputSettings(MotorSettings settings)
        {
            MotorConfiguration motorConfiguration = device_.LoadMotorConfiguration(serialNumber_);
            motorConfiguration.DeviceSettingsName = "MTS25";
            motorConfiguration.UpdateCurrentConfiguration();

            KCubeDCMotorSettings currentDeviceSettings = device_.MotorDeviceSettings as KCubeDCMotorSettings;
            device_.SetSettings(currentDeviceSettings, true, false);

            VelocityParameters velParam = new VelocityParameters();
            velParam.MaxVelocity = settings.MaxVelocityMms;
            velParam.MinVelocity = settings.MinVelocityMms;
            velParam.Acceleration = settings.MaxAccelerationMms2;
            device_.SetVelocityParams(velParam);
        }

        public void SetMovementSettings() { }

        public void Home(MotorSettings settings) 
        {
            HomeParameters homeParam = new HomeParameters();
            homeParam.Velocity = settings.HomingVelocityMms;
            homeParam.OffsetDistance = settings.HomingOffsetMm;
            device_.SetHomingParams(homeParam);

            Console.WriteLine("Homing device");
            taskComplete_ = false;
            taskID_ = device_.Home(CommandCompleteFunction);

            while (!taskComplete_)
            {
                Thread.Sleep(100);

                StatusBase status = device_.Status;
                Console.WriteLine("Device Homing {0}", status.Position);
            }
            Console.WriteLine("Device Homed");
            isHomed_ = true;
        }

        public void MoveTo(decimal posMm) 
        {
            Console.WriteLine($"Moving Device to {posMm} mm");

            taskComplete_ = false;
            taskID_ = device_.MoveTo(posMm, CommandCompleteFunction);

            while (!taskComplete_)
            {
                Thread.Sleep(100);

                StatusBase status = device_.Status;
                Console.WriteLine($"Device Moving {status.Position}");
            }
            Console.WriteLine("Device Moved");
        }

        #region Task Checker
        private static bool taskComplete_;
        private static ulong taskID_;
        public static void CommandCompleteFunction(ulong taskID)
        {
            if ((taskID_ > 0) && (taskID_ == taskID))
                taskComplete_ = true;
        }
        #endregion

    }
}
