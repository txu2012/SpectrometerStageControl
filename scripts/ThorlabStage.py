from pylablib.devices import Thorlabs
import time

# 512 encoder counts/steps per revolution
# 67 rotations per mm
# 34,304 steps per mm
# 29nm per step
    
class StageControl():
    def __init__(self, deviceName):
        self._stage = Thorlabs.KinesisMotor(deviceName, scale="step")
    
    def __enter__(self):
        return self
    
    def __exit__(self):
        return self._stage.close()
    
    @staticmethod
    def get_devices():
        return Thorlabs.list_kinesis_devices()
    
    def home_stage(self):
        self._stage.home()
        self._stage.wait_for_home()
        return self._stage.is_homed()   
        
    def move_stage_by(self, steps: int):
        self._stage.move_by(steps)
        self._stage.wait_move()
        return self._stage.get_position()
    
    def jog_stage(self, direction: bool):
        dir = "+" if direction else "-"
        self._stage.jog(dir)
    
    def stop_stage(self):
        self._stage.stop()
        
    def get_status(self):
        return self._stage.get_status()
        
    def get_position(self):
        return self._stage.get_position()
    
    def get_homed_status(self):
        return self._stage.is_homed()
    
    def test_motor(self):
        devices = Thorlabs.list_kinesis_devices()
        stage = Thorlabs.KinesisMotor(devices[0], scale="step")

        stage.home()  # home the stage
        stage.wait_for_home()  # wait until homing is done
        stage.move_by(34304)  # move by 34304 steps (1mm)
        stage.wait_move()  # wait until moving is done
        stage.jog("+")  # initiate jog (continuous move) in the positive direction
        time.sleep(1.)  # wait for 1 second
        stage.stop()  # stop the motion
        stage.close()