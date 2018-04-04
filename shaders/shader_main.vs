#version 430 core

layout(location=0) in vec3 position;
layout(location=1) in vec3 normal;

out vec3 pos;
out vec3 norm;

uniform mat4 MVP;
uniform int draw_mode;

void main() {
	if (draw_mode == 0) {
		pos = position;
		norm = normal;

	    gl_Position = MVP*vec4(pos, 1.0);
	} else {
		float size = 128;
		pos = size*vec3(gl_VertexID % 2 , gl_VertexID / 2, 0) - vec3(vec2(size-8)/2, 0.0); 
		norm = vec3(0, 0, 1);

		gl_Position = MVP*vec4(pos, 1.0);
	}
}