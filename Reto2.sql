Identificación de Microservicios
Gestión de Estudiantes:

Microservicio: Estudiantes
Endpoints:
/estudiantes: Obtener todos los estudiantes.
/estudiantes/{id}: Obtener información de un estudiante específico.
/estudiantes/crear: Crear un nuevo estudiante.
/estudiantes/{id}/actualizar: Actualizar información de un estudiante.
/estudiantes/{id}/eliminar: Eliminar un estudiante.

Gestión de Notas:

Microservicio: Notas
Endpoints:
/notas: Obtener todas las notas.
/notas/{id}: Obtener información de una nota específica.
/notas/crear: Registrar una nueva nota.
/notas/{id}/actualizar: Actualizar información de una nota.
/notas/{id}/eliminar: Eliminar una nota.
Gestión de Cursos:

Microservicio: Cursos
Endpoints:
/cursos: Obtener todos los cursos.
/cursos/{id}: Obtener información de un curso específico.
/cursos/crear: Crear un nuevo curso.
/cursos/{id}/actualizar: Actualizar información de un curso.
/cursos/{id}/eliminar: Eliminar un curso.
Gestión de Profesores:

Microservicio: Profesores
Endpoints:
/profesores: Obtener todos los profesores.
/profesores/{id}: Obtener información de un profesor específico.
/profesores/crear: Crear un nuevo profesor.
/profesores/{id}/actualizar: Actualizar información de un profesor.
/profesores/{id}/eliminar: Eliminar un profesor.
Gestión de Matrículas:

Microservicio: Matriculas
Endpoints:
/matriculas: Obtener todas las matrículas.
/matriculas/{id}: Obtener información de una matrícula específica.
/matriculas/crear: Realizar una nueva matrícula.
/matriculas/{id}/actualizar: Actualizar información de una matrícula.
/matriculas/{id}/eliminar: Eliminar una matrícula.

CREATE DATABASE ColegioABC123;

USE ColegioABC123;

CREATE TABLE Estudiantes (
    id_estudiante INT PRIMARY KEY,
    nombre VARCHAR(50),
    apellido VARCHAR(50),
    edad INT,
    grado VARCHAR(10)
);

CREATE TABLE Notas (
    id_nota INT PRIMARY KEY,
    id_estudiante INT,
    id_curso INT,
    valor FLOAT,
    FOREIGN KEY (id_estudiante) REFERENCES Estudiantes(id_estudiante),
    FOREIGN KEY (id_curso) REFERENCES Cursos(id_curso)
);

CREATE TABLE Cursos (
    id_curso INT PRIMARY KEY,
    nombre_curso VARCHAR(50),
    descripcion TEXT
);

CREATE TABLE Profesores (
    id_profesor INT PRIMARY KEY,
    nombre VARCHAR(50),
    apellido VARCHAR(50),
    especialidad VARCHAR(50)
);

CREATE TABLE Matriculas (
    id_matricula INT PRIMARY KEY,
    id_estudiante INT,
    id_curso INT,
    id_profesor INT,
    fecha_matricula DATE,
    FOREIGN KEY (id_estudiante) REFERENCES Estudiantes(id_estudiante),
    FOREIGN KEY (id_curso) REFERENCES Cursos(id_curso),
    FOREIGN KEY (id_profesor) REFERENCES Profesores(id_profesor)
);

