#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec2 aTexCoord;
layout (location = 2) in vec3 aNormal;


out vec2 TexCoord; // koordinaty pro texturu
out vec3 Normal; // normaly
out vec3 FragPos; // pozice objektu pred projekci

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
	gl_Position = projection * view * model * vec4(aPos, 1.0f);
	Normal = aNormal;
	FragPos = vec3(model * vec4(aPos, 1.0));
	TexCoord = vec2(aTexCoord.x, aTexCoord.y);
}