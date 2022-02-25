#include "./LaserCore.cginc"

float2 rotate(float2 uv, float t) {
    float c = cos(t), s = sin(t);
    return mul(float2x2(c, s, -s, c), uv);
}

// fake random
float rand(float t) {
    return frac(sin(t * 84.) * 498.);
}

void RapidFire_float (
    float2 uv,
    float width,
    float sharpness,
    float xBlur,
    float angle,
    float time,
    float count,
    float randomness,
    float decay,
    out float output
) {
    float dr = (angle * 2.) / (count - 1.);

    count = floor(count);
    count = max(count, 2.);

    float total;
    for (float i = 0.; i < count; i++) {
        float t = i / (count - 1.);

        float offset = i / count;
        float timeI = frac(time + offset);
        float iterI = floor(time + offset);

        float rot = lerp(
            lerp(-angle, angle, t), // fixed angle
            lerp(-angle, angle, rand(t + iterI)), // random angle
            clamp(randomness, 0., 1.)
        );

        float2 uvi = rotate(uv, rot);

        float level = smoothstep(decay, 0., timeI);

        total += LaserCore(uvi, width, sharpness, xBlur) * level;
    }

    output = total;
}
