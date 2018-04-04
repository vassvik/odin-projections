#version 430 core

in vec3 pos;
in vec3 norm;

uniform int draw_mode;

out vec4 color;

void main() {
	if (draw_mode == 0) {
		vec3 l = normalize(vec3(-0.5, 1.0, -1));
		float s = 0.5 + 0.5*clamp(dot(-l, norm), 0.0, 1.0);
		color = vec4(vec3(s), 0.5);
	} else {
		vec2 uv = pos.xy;
	    vec2 uv2 = fract(uv + 0.5) - 0.5; // add and subtract half a unit to get centered lines 
    
	    // thickness thin line
	    float d2 = 0.015;
	    
	    // falloff after 1.0 thickness, does not scale with resolution
	    float s2 = smoothstep(d2*1.0, d2*2.0, min(abs(uv2.x), abs(uv2.y)));
	    
	    // coloring
	    vec4 bgColor = vec4(96/255.0, 144/255.0, 255/255.0, 1.0);
	    vec4 fgColor = vec4(0.5, 0.5, 0.5, 1.0);
	    
	    color  = bgColor*s2 + fgColor*(1.0 - s2);
	}
}

