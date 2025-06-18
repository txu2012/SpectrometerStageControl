from seabreeze.spectrometers import Spectrometer, list_devices

class SpectrometerControl():
    def __init__(self, serial_number: str, integration_time_micros : int = 100000):
        self._spectrometer = Spectrometer.from_serial_number(serial_number)
        self._wavelengths = self._spectrometer.wavelengths()
        self._spectrometer.integration_time_micros(integration_time_micros)
        self._header = None

    def __enter__(self):
        return self
    
    def __exit__(self):
        return self._spectrometer.close()
    
    @staticmethod
    def get_devices():
        return list_devices()
    
    def get_header(self):
        pass
    
    def get_spectrum(self):
        wavelengths, intensities = self._spectrometer.spectrum()
        return wavelengths, intensities
        
    def test(self):
        spec = Spectrometer.from_first_available()

        devices = list_devices()
        spec = Spectrometer(devices[1])
        spec = Spectrometer.from_serial_number("F01234")
        spec.integration_time_micros(100000)
        spec.f.eeprom.eeprom_read_slot(4)
        spec.features['eeprom'][0].eeprom_read_slot(4)
        wavelengths = spec.wavelengths()
        print(wavelengths)
        
        intensities = spec.intensities()
        print(intensities)
        
        wave, ints = spec.spectrum()
        print(wave)
        print(ints)
        
        spec.features['pixel_binning'][0].set_binning_factor()