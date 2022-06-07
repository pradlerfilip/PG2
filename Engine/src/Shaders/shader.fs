#version 330 core
in vec2 TexCoord;

in vec3 Normal;
in vec3 FragPos;  

uniform sampler2D texture1;
uniform vec3 ambientLight;
uniform float U_ambientStrength;
uniform vec3 lightPos; 
uniform mat4 model;

out vec4 FragColor;

void main() 
{	

	//ambient
	float ambientStrength = U_ambientStrength;
	vec3 ambient = ambientStrength * ambientLight;
	// difuse
	vec3 norm = normalize((model * vec4(Normal, 1.0f)).xyz);
	vec3 lightDir = normalize(lightPos - FragPos);
	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * ambientLight;

	//output
	FragColor = vec4(texture(texture1, TexCoord).xyz * (ambient + diffuse), texture(texture1, TexCoord).w);
}