shader_type canvas_item;

void fragment() {
    vec4 original_color = texture(TEXTURE, UV);
    float gray = 0.2;
    COLOR = vec4(vec3(gray), min(original_color.a, 0.8));
}
