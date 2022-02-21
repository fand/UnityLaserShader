#include "./LaserCore.cginc"

float2 rotate(float2 uv, float t) {
    float c = cos(t), s = sin(t);
    return mul(float2x2(c, s, -s, c), uv);
}

void RapidFire_float (
    float2 uv,
    float width,
    float sharpness,
    float angle,
    float time,
    out float output
) {
    float iter = 5.;
    float dr = (angle * 2.) / (iter - 1.);

    float total;
    for (float i = 0.; i < iter; i++) {
        float rot = dr * i - angle;
        float2 uvi = rotate(uv, rot);

        float t = frac(time + 1. / iter * i);
        float level = smoothstep(0., 1., t);
        total += LaserCore(uvi, width, sharpness) * t;
    }

    output = total;
}
