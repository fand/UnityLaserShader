#ifndef LASER_CORE_INCLUDED
#define LASER_CORE_INCLUDED

#define widthFactor 0.001

float LaserCore(
    float2 uv,
    float width,
    float sharpness,
    float xBlur
) {
    uv.x /= (1. + uv.y * xBlur * 100.);

    float c = (width * widthFactor) / abs(uv.x);
    c = clamp(c, 0., 1.);
    c = pow(c, sharpness + 1.);
    return c;
}

#endif
