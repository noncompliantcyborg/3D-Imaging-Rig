import time
import rp2
from machine import Pin
from machine import freq
from machine import mem32

def sm_div_calc(target_f):
    if target_f < 0:
        div = 256
    elif target_f == 0:
        # Special case: set clkdiv to 0.
        div = 0
    else:
        div = freq() * 256 // target_f
        if div <= 256 or div >= 16777216:
            raise ValueError("freq out of range")
    return div << 8
    

# Laser and Camera control by Jonathan Fay & Jamie Andersen Fields
@rp2.asm_pio(set_init=rp2.PIO.OUT_LOW)
def steps0():
    wrap_target()
    label("start")
    pull(block)
    mov(x, osr)
    label("loop2")
    set(pins, 1)   [10]
    set(pins, 0)   [10]
    jmp(x_dec, "loop2")
    irq(block,0)
    wrap()

@rp2.asm_pio(set_init=rp2.PIO.OUT_LOW)
def steps3():
    wrap_target()
    label("start")
    pull(block)
    mov(x, osr)
    label("loop2")
    set(pins, 1)   [10]
    set(pins, 0)   [10]
    jmp(x_dec, "loop2")

    irq(block,3)
    wrap()

CamPos = -999
LasPos = -999
CurCamPos = -999
CurLasPos = -999

CameraHomePin = machine.Pin(14, machine.Pin.IN, machine.Pin.PULL_DOWN)
LaserHomePin = machine.Pin(11, machine.Pin.IN, machine.Pin.PULL_DOWN)

def LaserHitHome(pin):
#    print(pin)
    global lsm
    global lasDirPin
    global LaserHomePin
    if (LaserHomePin.value() == 1):
        if (lasDirPin.value() == 0):
            print("laser home")
            lsm.restart()
            lasDirPin.value(1)
            JogLaser(2000)
    
def CameraHitHome(pin):
#    print(pin)
    global csm
    global camDirPin
    global CameraHomePin
    if (CameraHomePin.value() == 1):
        if (camDirPin.value() == 0):
            print("camera home")
            csm.restart()
            camDirPin.value(1)
            JogCamera(2000)
    

LaserHomePin.irq(trigger=Pin.IRQ_RISING, handler=LaserHitHome)
CameraHomePin.irq(trigger=Pin.IRQ_RISING, handler=CameraHitHome)

camDirPin=machine.Pin(5,machine.Pin.OUT)
lasDirPin=machine.Pin(7,machine.Pin.OUT)

laserPowerPin=machine.Pin(15,machine.Pin.OUT)
laserPowerPin.value(1)




def intHandlerCamera(sm):
    global CamPos
    global CurCamPos
    print("Camera Arrived")
    CurCamPos = CamPos
    ShowPosition()

def intHandlerLaser(sm):
    global LasPos
    global CurLasPos
    print("Laser Arrived")
    CurLasPos = LasPos
    ShowPosition()

def HomeLaser():
    global LasPos
    JogLaser(-400000)
    LasPos=-2000

def JogLaser(dist):
    global lsm
    global lasDirPin
    global LasPos
    if (LasPos + dist) > 225000:
        dist = 225000 - LasPos
    
    d = abs(dist)
    if (d < 0):
        return
    
    LasPos = LasPos + dist
    if (dist < 0 ):
        lasDirPin.value(0)
        lsm.put(d)      
    else:
        lasDirPin.value(1)
        lsm.put(d)

def HomeCamera():
    global CamPos
    JogCamera(-400000)
    CamPos=-2000
        
        
def JogCamera(dist):
    global csm
    global camDirPin
    global CamPos

    if (CamPos + dist) > 200000:
        dist = 200000 - CamPos
    d = abs(dist)
    if (d < 0):
        return
    CamPos = CamPos + dist
    if (dist < 0 ):
        camDirPin.value(0)
        csm.put(d)      
    else:
        camDirPin.value(1)
        csm.put(d)
        
def SeekLaser(location):
    global LasPos
    jog = location - LasPos
    JogLaser(jog)

def SeekCamera(location):
    global CamPos
    jog = location - CamPos
    JogCamera(jog)
    
def ShowPosition():
    global CurCamPos
    global CurLasPos
    print("Loc:{},{}".format(CurCamPos,CurLasPos))
    

def SetLaserSpeed(speed):
    SM0_CLKDIV = 0x50200000 + 0x0c8
    SM1_CLKDIV = 0x50200000 + 0x0e0
    SM2_CLKDIV = 0x50200000 + 0x0f8
    SM3_CLKDIV = 0x50200000 + 0x110 
    mem32[SM3_CLKDIV] = sm_div_calc(speed)
    
def SetCameraSpeed(speed):
    SM0_CLKDIV = 0x50200000 + 0x0c8
    SM1_CLKDIV = 0x50200000 + 0x0e0
    SM2_CLKDIV = 0x50200000 + 0x0f8
    SM3_CLKDIV = 0x50200000 + 0x110 
    mem32[SM0_CLKDIV] = sm_div_calc(speed)

def SetLaserPower(pow):
    global laserPowerPin
    if (pow > 0):
        laserPowerPin.value(0)
    else:
        laserPowerPin.value(1)
    
csm = rp2.StateMachine(0, steps0, freq=150000, set_base=Pin(4))
lsm = rp2.StateMachine(3, steps3, freq=150000, set_base=Pin(6))

csm.irq(handler=intHandlerCamera)
lsm.irq(handler=intHandlerLaser)

csm.active(1)
lsm.active(1)



