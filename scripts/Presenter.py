from SpectrometerControl import SpectrometerControl
from ThorlabStage import StageControl
import numpy as np

class Presenter():
    def __init__(self, view):
        self._stage = None
        self._spectrometer = None
        self._view = view
        
    def __enter__(self):
        return self
    
    def __exit__(self):
        self._stage.__exit__()
        self._spectrometer.__exit__()   
        return
    
    def start(self):
        self._view.start()
        
    def get_stages(self):
        return StageControl.get_devices()
    
    def get_spectrometers(self):
        return SpectrometerControl.get_devices()    
    
    def connect_stage(self, device: str):
        self._stage = StageControl(device)
    
    def connect_spectrometer(self, serial_number: str):
        self._spectrometer = SpectrometerControl(serial_number)
        
    # Stage controls    
    def home_stage(self):
        self._stage.home_stage()
        
    def move_stage(self, steps: int):
        self._stage.move_stage_by(steps) 
        
    def stop_stage(self):
        self._stage.stop_stage()   
    
    # Full set
    def run_set(self, wavelength_range, range_steps: int = 50, incremental_steps: int = 1):
        print('Run set')
        # Move to initial
        initial_pos = -range_steps
        final_pos = range_steps
        data = list()
        
        print('Moving to initial position')
        # Go to initial position and get first set of data
        current_pos = self._stage.move_stage_by(initial_pos)
        
        while(current_pos < final_pos):
            # get data
            wavelengths, intensities = self._spectrometer.get_spectrum()
            data.append({"position" : current_pos, "wavelengths" : wavelengths, "intensities" : intensities})
            print(f'position: {current_pos}, wavelengths: {wavelengths}, intensities: {intensities}')
            
            # move to next position
            current_pos = self._stage.move_stage_by(current_pos+incremental_steps)
            
            
        print('Finished collecting dataset')
        return data
    
    def trim_data(self, src, wavelength_range):
        print('Trim data')
        
        trimmed_data = list()
        for data in src:            
            print(f'position: {data["position"]}')
            
            min_index = (np.abs(data["wavelengths"] - wavelength_range[0])).argmin()
            max_index = (np.abs(data["wavelengths"] - wavelength_range[1])).argmin()
            
            trimmed_data.append((data["position"], data["wavelengths"][min_index:max_index+1], data["intensities"][min_index:max_index+1]))
            
        return trimmed_data
            