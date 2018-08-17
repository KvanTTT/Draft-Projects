import bpy
from bpy import context
from math import *

#import sun_utils
#from sun_utils import *
import datetime

sce = bpy.context.scene

bl_info = {
    "name": "Binary Sundial",
    "description": "",
    "author": 'Ivan Kochurkin (KvanTTT)',
    "category": "Add Mesh"
}

class AltitudeAzimuth:
    def __init__(self, altitude, azimuth):
       self.altitude = altitude
       self.azimuth = azimuth

    def __repr__(self):
        return str(self.altitude) + " " + str(self.azimuth)
    
def generate_sun_pos_for_hours(dt, latitude, longitude, rng):
    result = {}
    for i in rng:
        result[i] = calculate_sun_pos(datetime.datetime(dt.year, dt.month, dt.day, i), latitude, longitude)
    return result

def calculate_sun_pos(dt, latitude, longitude):
    deg2Rad = pi / 180.0
    rad2Deg = 180.0 / pi

    # Convert to UTC
    dt = datetime_to_utc(dt)

    # Number of days from J2000.0.
    julianDate = (367 * dt.year -
        int((7.0 / 4.0) * (dt.year + int((dt.month + 9.0) / 12.0))) + 
        int((275.0 * dt.month) / 9.0) +
        dt.day - 730531.5)

    julianCenturies = julianDate / 36525.0

    # Sidereal Time
    siderealTimeHours = 6.6974 + 2400.0513 * julianCenturies

    siderealTimeUT = (siderealTimeHours +
        (366.2422 / 365.2422) * dt.hour)

    siderealTime = siderealTimeUT * 15 + longitude

    # Refine to number of days (fractional) to specific time.
    julianDate += dt.hour / 24.0;
    julianCenturies = julianDate / 36525.0;

    # Solar Coordinates
    meanLongitude = correct_angle(deg2Rad * (280.466 + 36000.77 * julianCenturies))

    meanAnomaly = correct_angle(deg2Rad * (357.529 + 35999.05 * julianCenturies))

    equationOfCenter = deg2Rad * ((1.915 - 0.005 * julianCenturies) *
        sin(meanAnomaly) + 0.02 * sin(2 * meanAnomaly))

    elipticalLongitude = correct_angle(meanLongitude + equationOfCenter)

    obliquity = (23.439 - 0.013 * julianCenturies) * deg2Rad

    # Right Ascension
    rightAscension = atan2(cos(obliquity) * sin(elipticalLongitude), cos(elipticalLongitude))

    declination = asin(sin(rightAscension) * sin(obliquity))

    # Horizontal Coordinates
    hourAngle = correct_angle(siderealTime * deg2Rad) - rightAscension

    if hourAngle > pi:
        hourAngle -= 2 * pi

    altitude = asin(sin(latitude * deg2Rad) *
        sin(declination) + cos(latitude * deg2Rad) *
        cos(declination) * cos(hourAngle))

    # Nominator and denominator for calculating Azimuth
    # angle. Needed to test which quadrant the angle is in.
    aziNom = -sin(hourAngle)
    aziDenom = (tan(declination) * cos(latitude * deg2Rad) -
                sin(latitude * deg2Rad) * cos(hourAngle))

    azimuth = atan(aziNom / aziDenom)

    if aziDenom < 0:
        azimuth += pi
    elif aziNom < 0:
        azimuth += 2 * pi

    return AltitudeAzimuth(altitude, azimuth)

def datetime_to_utc(dt):
    return dt + (datetime.datetime.utcnow() - datetime.datetime.now())

def correct_angle(angleInRadians):
    if angleInRadians < 0:
        return 2 * pi - (abs(angleInRadians) % (2 * pi))
    elif angleInRadians > 2 * pi:
        return angleInRadians % (2 * pi)
    else:
        return angleInRadians

vertex_counts = [3, 4, 6, 32]
#vertex_counts = [4, 4, 4, 4]
hole_obj_count = 4

cylinder = bpy.ops.mesh.primitive_cylinder_add
cube = bpy.ops.mesh.primitive_cube_add
sphere = bpy.ops.mesh.primitive_ico_sphere_add      
plane = bpy.ops.mesh.primitive_plane_add
cylinder = bpy.ops.mesh.primitive_cylinder_add

rotate = bpy.ops.transform.rotate
resize = bpy.ops.transform.resize

bpy.ops.object.select_all(action='SELECT')
bpy.ops.object.delete()

plane(location=(0,0,-4))
resize(value=(50,50,1))
bpy.context.object.name = "plane"

def generate_combinations(format, count):
    result = []
    for ind in range(0, 2 ** count):
        if format == 0:
            result.append(ind)
        elif format == 1:
            result.append(ind ^ (ind >> 1))
    return result

def create_hole_objects(number, count, comb):
    strNumber = str(number)
    
    for i in range(4):
        if ((comb >> i) & 1) == 1:
            cylinder(vertices=vertex_counts[i], location=(-1.5 + i,0,0), depth=15, radius=0.3)
            bpy.context.object.name = "holeObj" + strNumber + str(i)
            
    
    bpy.ops.object.select_pattern(pattern="holeObj" + strNumber + "*", extend=False)
    rotate(value=pi/2, axis=(1,0,0))
    

def substract(obj, name):
    bpy.context.scene.objects.active = obj
    bpy.ops.object.modifier_add(type='BOOLEAN')
    bpy.context.object.modifiers["Boolean"].operation = 'DIFFERENCE'
    bpy.context.object.modifiers["Boolean"].object = bpy.data.objects[name]
    bpy.ops.object.modifier_apply(apply_as='DATA', modifier="Boolean")
    
def substract_group(obj, number, count, comb):
    strNumber = str(number)
    
    for j in range(count):
        if ((comb >> j) & 1) == 1:
            substract(obj, "holeObj" + strNumber + str(j))

#bpy.ops.object.duplicate()
#bpy.ops.view3d.pastebuffer()

rng = range(7, 20)
poses = generate_sun_pos_for_hours(datetime.datetime.now(), 55.7522222, 37.6155556, rng)

combs = generate_combinations(0, hole_obj_count)

for i, pos in poses.items():
    create_hole_objects(i, hole_obj_count, combs[i % 12])
    rotate(value=pos.altitude, axis=(1,0,0))
    rotate(value=-pos.azimuth, axis=(0,0,1))
    
cube(location=(0,0,0))
resize(value=(3,3,3))
#sphere(subdivisions=4,location=(0,0,0),size=3)
#cylinder(location=(0,0,0), vertices=32, radius=3.0, depth=3.0)
bpy.context.object.name = "object1"
object1 = bpy.context.object 

for i, pos in poses.items():
    substract_group(object1, i, hole_obj_count, combs[i % 12])

bpy.ops.object.select_pattern(pattern="holeObj*", extend=False)
bpy.ops.object.delete()

bpy.ops.object.camera_add(view_align=True, location=(15.074, 0, 7.17318), rotation=(66.733/180*pi, 0.762/180*pi, 90/180*pi), layers=(True, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False))
bpy.context.object.data.sensor_width = 150

bpy.ops.object.lamp_add(type='SUN', view_align=False, location=(0, 0, 5), layers=(True, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False))
bpy.context.object.data.shadow_method = 'RAY_SHADOW'
bpy.context.object.data.sky.use_sky = True
bpy.ops.script.python_file_run(filepath="C:\\Program Files\\Blender Foundation\\Blender\\2.70\\scripts\\presets\\sunsky\\classic.py")
sun = bpy.context.object

pos = poses[15]
bpy.context.object.rotation_euler = (-pos.altitude + pi/2,0,-pos.azimuth + pi)

#bpy.context.space_data.viewport_shade = 'RENDERED'
#bpy.context.scene.active = bpy.data.scenes["Scene"].(null)

frame = 0
for hour in rng:
    bpy.context.scene.frame_set(frame)
    pos = poses[hour]
    bpy.context.scene.objects.active = sun
    bpy.context.object.rotation_euler = (-pos.altitude + pi/2, 0,-pos.azimuth + pi)
    bpy.ops.anim.keyframe_insert()
    frame += 10
    
bpy.context.scene.frame_set(0)
bpy.context.scene.frame_end = frame