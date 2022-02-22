//float2 rotate(float2 uv, float t) {
//    float c = cos(t), s = sin(t);
//    return mul(float2x2(c, s, -s, c), uv);
//}

void LaserMask_float (
    float2 uv,
    float angle,
    float smooth,
    out float output
) {
    float a = atan2(-uv.x, uv.y);
    output = smoothstep(-angle - smooth, -angle, a) * smoothstep(angle + smooth, angle, a) * smoothstep(-smooth, 0, uv.y);
}
