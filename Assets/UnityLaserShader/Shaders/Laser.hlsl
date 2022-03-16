#include "./LaserCore.cginc"

void Laser_float (
    float2 uv,
    float width,
    float sharpness,
    float xBlur,
    float splitWidth,
    float splitMix,
    out float output
) {
    output = LaserCore(uv, width, sharpness, xBlur, splitWidth, splitMix);
}
