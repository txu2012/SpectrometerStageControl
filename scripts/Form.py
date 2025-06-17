import tkinter as tk
from tkinter.ttk import *
import tkinter.scrolledtext as scrolledtext
import serial.tools.list_ports
from Presenter import Presenter

class Form():
    def __init__(self):        
        self._root_window = tk.Tk()
        self._root_window.title("Spectrometer Stage Control")
        #self._root_window.iconbitmap("yukkuri_mini.ico")
        
        self._width = 720
        self._height = 485

        self._selected_port = None
        self._responses = tk.StringVar()
        self._status = tk.StringVar()
        self._lbl_speed = tk.StringVar()
        self._lbl_distance = tk.StringVar()
        self._axis_status = [None, None, None]
        self._nud_distance = 0
        self._distance_val = tk.DoubleVar()
        self._cb_convert = tk.IntVar()
        self._nud_convert = 0
        self._convert_val = tk.IntVar()
        self._btn_connect = None
        self._btn_disconnect = None
        self._cb_polarity = [tk.IntVar(), tk.IntVar(), tk.IntVar()]
        
        self._widget_toggles = []
        self._motor_frame = None
        
        self._presenter = None
        
    def __enter__(self):
        print('Starting')
        return self
        
    def __exit__(self ,type, value, traceback):
        print('Exiting')
        return False
        
    def start(self):
        self.create_connection_frame()
        self.create_params_frame()
        self._root_window.protocol("WM_DELETE_WINDOW", self.on_closing)  
        
        self._root_window.geometry(f"{self._width}x{self._height}")
        self._root_window.resizable(False, False)
        #self.toggle_widgets(False)
        self._root_window.mainloop()
        
    def on_closing(self):
        self._root_window.destroy()
        
    def create_connection_frame(self):        
        conn_frame = tk.LabelFrame(self._root_window, text="Connection", width=710, height=80)
        conn_frame.grid(rowspan=2, columnspan=6, padx=5, pady=5)
        
        tk.Label(conn_frame, text="Stage: ").grid(row=0, column=0, padx=(5,0))
        self._cb_stage = tk.ttk.Combobox(conn_frame, 
                                         state="readonly", 
                                         width=8, 
                                         textvariable=self._selected_port,
                                         #values=[device[0] for device in serial.tools.list_ports.comports() if device[2] != 'n/a'], 
                                         #postcommand= lambda: self._cb_stage.configure(values=[device[0] for device in serial.tools.list_ports.comports() if device[2] != 'n/a'])
                                         values=[device[0] for device in self._presenter.get_stages() if device[2] != 'n/a'], 
                                         postcommand= lambda: self._cb_stage.configure(values=[device[0] for device in self._presenter.get_stages()  if device[2] != 'n/a']))
        self._cb_stage.grid(row=0, column=1, padx=(5, 0))
        
        self._btn_connect = tk.Button(conn_frame, text="Connect", width=10, command=self.connect_clicked)
        self._btn_connect.grid(row=0, column=2, padx=(5,5))
        self._btn_disconnect = tk.Button(conn_frame, text="Disconnect", width=10, command=self.disconnect_clicked)
        self._btn_disconnect.grid(row=0, column=3, padx=(5,5))
        self._btn_disconnect.config(state='disabled')
        
        tk.Label(conn_frame, text="Status: ").grid(row=0, column=4, padx=(200,0))
        tk.Label(conn_frame, text="Disconnected", textvariable=self._status, width=15).grid(row=0, column=5, padx=(0, 10))
        self._status.set("Disconnected")
        
        # Spectrometer
        tk.Label(conn_frame, text="Spectrometer: ").grid(row=1, column=0, padx=(5,0))
        self._cb_spectrometer = tk.ttk.Combobox(conn_frame, 
                                         state="readonly", 
                                         width=8, 
                                         textvariable=self._selected_port,
                                         #values=[device[0] for device in serial.tools.list_ports.comports() if device[2] != 'n/a'], 
                                         #postcommand= lambda: self._cb_spectrometer.configure(values=[device[0] for device in serial.tools.list_ports.comports() if device[2] != 'n/a'])
                                         values=[device[0] for device in self._presenter.get_spectrometers() if device[2] != 'n/a'], 
                                         postcommand= lambda: self._cb_spectrometer.configure(values=[device[0] for device in self._presenter.get_spectrometers() if device[2] != 'n/a']))
        self._cb_spectrometer.grid(row=1, column=1, padx=(5, 0))
        
        self._btn_connect = tk.Button(conn_frame, text="Connect", width=10, command=self.connect_spec_clicked)
        self._btn_connect.grid(row=1, column=2, padx=(5,5))
        self._btn_disconnect = tk.Button(conn_frame, text="Disconnect", width=10, command=self.disconnect_spec_clicked)
        self._btn_disconnect.grid(row=1, column=3, padx=(5,5))
        self._btn_disconnect.config(state='disabled')
        
        tk.Label(conn_frame, text="Status: ").grid(row=1, column=4, padx=(200,0))
        tk.Label(conn_frame, text="Disconnected", textvariable=self._status, width=15).grid(row=1, column=5, padx=(0, 10))
        self._status.set("Disconnected")
        
        conn_frame.grid_propagate(0)
        
    def create_params_frame(self):
        motor_frame = tk.LabelFrame(self._root_window, text="Motor Control", width=710, height=390)
        motor_frame.place(x=5, y=85)
        self._motor_frame = motor_frame
        
        # Responses
        self._txt_response = scrolledtext.ScrolledText(motor_frame, width=34)
        self._txt_response.config(state='disabled')
        self._txt_response.place(x=410, height=360)
        
        # Homing/Limit
        button_frame = tk.Frame(motor_frame, width=300, height=50)
        button_frame.place(x=5, y=2)
        
        btn_home_center = tk.Button(button_frame, text="Home", width=10, height=2, command= lambda: self.btn_home_clicked())
        btn_home_center.grid(row=0, column=0, padx=(0, 5))
        #btn_home_edge = tk.Button(button_frame, text="Home Edge", width=10, height=2, command= lambda: self.btn_home_clicked())
        #btn_home_edge.grid(row=0, column=1, padx=(0, 5))
        #btn_calc_limit = tk.Button(button_frame, text="Calc Limit", width=10, height=2, command = self.btn_calc_limit)
        #btn_calc_limit.grid(row=0, column=2)
        button_frame.grid_propagate(0)
        
        self._widget_toggles.append(btn_home_center)
        #self._widget_toggles.append(btn_home_edge)
        #self._widget_toggles.append(btn_calc_limit)
        
        # mm Conversion
        convert_frame = tk.Frame(motor_frame, width=110, height=55)
        convert_frame.place(x=270, y=0)
        cb_convert = tk.Checkbutton(convert_frame, text='mm Convert',variable=self._cb_convert, onvalue=1, offvalue=0, command=self.cb_convert_checked, anchor="w")
        cb_convert.grid(row=0, column=0, columnspan=2)
        cb_convert.select()
        
        self._convert_val.set(160)
        self._nud_convert = tk.Spinbox(convert_frame, from_=0, to=2000, width=4, textvariable=self._convert_val)
        self._nud_convert.grid(row=1, column=0, sticky="w")
        tk.Label(convert_frame, text="steps/mm", width=8, height=1, anchor="w").grid(row=1, column=1)
        convert_frame.grid_propagate(0)
        
        self._widget_toggles.append(cb_convert)
        self._widget_toggles.append(self._nud_convert)
        
        # Motor Parameters
        parameter_frame = tk.Frame(motor_frame, width=400, height=50)
        parameter_frame.place(x=5, y=50)
        
        tk.Label(parameter_frame, textvariable=self._lbl_speed, width=15, height=2, anchor="w").grid(row=0, column=0)
        self._txt_speed = tk.Text(parameter_frame, width=8, height=1)
        self._txt_speed.grid(row=0, column=1, sticky="w", padx=(0, 5))
        tk.Label(parameter_frame, textvariable=self._lbl_distance, width=15, height=2, anchor="w").grid(row=0, column=2)
        self._nud_distance = tk.Spinbox(parameter_frame, 
                                        from_=0.00, 
                                        to=2000.00, 
                                        increment=0.01, 
                                        format="%.2f",
                                        width=8, 
                                        textvariable=self._distance_val,
                                        command= self.nud_distance_value_updated)
        self._nud_distance.grid(row=0, column=3, sticky="w")# make min/max updateable
        self._nud_distance.bind('<Return>', self.nud_distance_value_updated)
        self._lbl_speed.set('Velocity(mm/s): ')
        self._txt_speed.insert(tk.END, f'{str(0)}')
        self._lbl_distance.set('Distance(mm):')
        self._txt_speed.config(state='disabled')
        parameter_frame.grid_propagate(0)
        
        self._widget_toggles.append(self._nud_distance)
        
        # Axis control
        #axis_frame = tk.Frame(motor_frame, width=400, height=400)
        #axis_frame.place(x=5, y=90)

        #self.create_axis_frame(axis_frame, "X", 0, 0)
        #self.create_axis_frame(axis_frame, "Y", 1, 1)
        #self.create_axis_frame(axis_frame, "Z", 2, 2)
        
        motor_frame.grid_propagate(0)    
        
    def connect_clicked(self):
        self._selected_port = self._cb_stage.get()
        success = False
        
        #if self._selected_port != None and not self._presenter.IsConnected:
        #   success = self._presenter.try_connect(self._selected_port)
           
        #if not success:
        #    tk.messagebox.showerror('Connection Error', f'Error: Failed to connect to {self._selected_port}.')
            
        #self.update_view()
        
    def disconnect_clicked(self):
        #if self._presenter.IsConnected:
        #    self._presenter.try_disconnect()
            
        #self.update_view()
        pass
    
    def connect_spec_clicked(self):
        pass
    
    def disconnect_spec_clicked(self):
        pass
    
    def btn_axis_clicked(self, motor, direction, distance):
        #current_status = copy.deepcopy(self._presenter.MotorStatus)
        
        #current_positions = current_status.Positions
        #current_positions[motor] = current_status.Positions[motor] + (float(distance) * direction * self._presenter.MotorStatus.Polarity[motor])
        #current_status.Positions = current_positions
        
        #success, msg = self._presenter.try_motor_move(motor, current_status._positions[motor])
        
        #if not success:
        #    tk.messagebox.showerror('Motor Error', f'Error: {msg}')
        pass
    
    def btn_home_clicked(self):
        #success, msg = self._presenter.try_motor_home(center)
        
        #if not success:
        #    tk.messagebox.showerror('Homing Error', f'Error: {msg}')
        pass
    
    def btn_calc_limit(self):
        #success, msg = self._presenter.try_calc_limit();
        
        #if not success:
        #    tk.messagebox.showerror('Calculate Limit Error', f'Error: {msg}')
        pass
    
    def nud_distance_value_updated(self, event=None):
        #self._presenter.MotorStatus.MovePosition = self._distance_val.get()
        pass
    
    def cb_convert_checked(self):           
        #self._presenter.MotorStatus.ConvertFlag = True if self._cb_convert.get() == 1 else False            
        
        #if self._presenter.MotorStatus.ConvertFlag:
        #    self._nud_distance.config(increment=0.01)
        #else:
        #    self._nud_distance.config(increment=1.00)
            
        #self._distance_val.set("{:.2f}".format(float(self._presenter.MotorStatus.MovePosition)))
        #self.update_view()  
        pass

    def cb_polarity_checked(self, motor: int):
        #self._presenter.MotorStatus.Polarity[motor] = -1 if self._cb_polarity[motor].get() == 1 else 1
        pass