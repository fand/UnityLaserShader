#include "./LaserCore.cginc"

void Laser_float (
    float2 uv,
    float width,
    float sharpness,
    out float output
) {
    output = LaserCore(uv, width, sharpness);
}
