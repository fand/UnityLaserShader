#ifndef ARC_MASK_INCLUDED
#define ARC_MASK_INCLUDED

#define M_PI 3.141592653589793
#define M_TWO_PI 6.283185307179586
void ArcMask_float (
    float2 uv,
    float startAngle,
    float endAngle,
    float smooth,
    out float output
) {

    float a = atan2(-uv.x, uv.y);
    output = smoothstep(startAngle - smooth, startAngle, a) * smoothstep(endAngle + smooth, endAngle, a) * smoothstep(-smooth, 0, uv.y);
}
#endif
