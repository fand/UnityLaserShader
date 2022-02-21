#define widthFactor 0.001

float LaserCore(
    float2 uv,
    float width,
    float sharpness
) {
    float c = (width * widthFactor) / uv.x;
    c = clamp(c, 0., 1.);
    c = pow(c, sharpness + 1.);
    return c;
}
