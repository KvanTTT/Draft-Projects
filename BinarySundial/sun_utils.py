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