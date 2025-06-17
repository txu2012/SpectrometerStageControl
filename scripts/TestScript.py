"""
Created on Thu June 17 2025

@author: Tony
"""

from Presenter import Presenter
from Form import Form

class SpectrometerRunner():
    """Wrapper class for setting the main window"""
    
    def __init__(self):
        form = Form()
        
        self._presenter = Presenter(form)
        form._presenter = self._presenter
        
        self._presenter.start()
        
if __name__ == "__main__":
    print('Starting program.')
    
    #app = SpectrometerRunner()
    
    """
    presenter = Presenter()
    
    spectrometer_devices = presenter.get_spectrometers()
    stage_devices = presenter.get_stages()
    
    presenter.connect_spectrometer("")
    presenter.connect_stage("")
    
    presenter.home_stage()
    presenter.move_stage(1000)
    """