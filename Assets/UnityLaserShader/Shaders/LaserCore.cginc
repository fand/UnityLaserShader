#ifndef LASER_CORE_INCLUDED
#define LASER_CORE_INCLUDED

#define widthFactor 0.001

float  LaserCore(
    float2 uv,
    float width,
    float sharpness,
    float xBlur,
    float splitWidth,
    float splitMix
) {
    float fixedWidth = width * widthFactor; // UVのスケールに補正

    uv.x /= (uv.y * xBlur * 100.); // Y座標でぼかす

    // main bem
    float c = fixedWidth / abs(uv.x);
    c = clamp(c, 0., 1.);
    c = pow(c, sharpness + 1.);

    // Split beam
    uv.x = abs(abs(uv.x) - fixedWidth * splitWidth);
    float cSplit = (fixedWidth * (1. - splitWidth)) / abs(uv.x);
    cSplit = clamp(cSplit, 0., 1.);
    cSplit = pow(cSplit, sharpness + 1.);

    return lerp(c, cSplit, splitMix);
}

#endif
