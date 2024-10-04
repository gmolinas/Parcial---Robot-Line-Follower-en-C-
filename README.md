# Proyecto: Simulación de Robot Line Follower en Windows Forms con Arquitectura Limpia

---

## Índice

- [Descripción del Proyecto](#descripción-del-proyecto)
- [Características Principales](#características-principales)
- [Arquitectura y Patrones de Diseño](#arquitectura-y-patrones-de-diseño)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Uso de la Aplicación](#uso-de-la-aplicación)
- [Detalles Técnicos](#detalles-técnicos)

---

## Descripción del Proyecto

Este proyecto es una simulación de un **robot Line Follower** desarrollado en **C#** utilizando **Windows Forms** y siguiendo los principios de **Arquitectura Limpia**. El robot sigue una línea negra y realiza acciones basadas en las lecturas de dos sensores infrarrojos simulados por el usuario a través de la interfaz gráfica.

La aplicación permite al usuario interactuar con los sensores, observar las acciones del robot y visualizar una simulación gráfica en tiempo real del movimiento del robot.

---

## Características Principales

- **Simulación Interactiva**: El usuario puede simular las lecturas de los sensores infrarrojos mediante botones en la interfaz.
- **Visualización Gráfica**: La aplicación muestra una simulación en tiempo real donde el fondo se mueve para dar la sensación de movimiento del robot.
- **Registro de Cambios de Estado**: Cada cambio en los sensores es registrado y almacenado en un archivo binario llamado `mision.bin`.
- **Búsqueda de Registros**: Permite buscar y mostrar los cambios de estado registrados según un rango de fechas especificado por el usuario.
- **Aplicación de Patrones de Diseño**: Utiliza patrones como **Observer**, **Strategy** y **Repository** para una arquitectura modular y mantenible.
- **Arquitectura Limpia**: El proyecto está organizado en capas siguiendo los principios de la arquitectura limpia, facilitando la escalabilidad y mantenimiento.

---

## Arquitectura

### Arquitectura Limpia

El proyecto sigue la **Arquitectura Limpia** propuesta por Robert C. Martin, organizando el código en capas que separan las preocupaciones y mantienen las dependencias unidireccionales hacia el interior:

1. **Dominio (Domain)**: Contiene las entidades y modelos del negocio.
2. **Aplicación (Application)**: Incluye la lógica de negocio y casos de uso.
3. **Infraestructura (Infrastructure)**: Implementa detalles tecnológicos y acceso a datos.
4. **Presentación (Presentation)**: Contiene la interfaz de usuario y controladores.

---

## Estructura del Proyecto

```
Proyecto/
│
├── Domain/
│   ├── Enums/
│   │   ├── Direccion.cs
│   │   └── SensorState.cs
│   ├── Entities/
│   │   ├── Movimiento.cs
│   │   └── StateChangeRecord.cs
│   └── Interfaces/
│       ├── IObserver.cs
│       └── ISubject.cs
│
├── Application/
│   ├── Interfaces/
│   │   ├── IControladorMovimiento.cs
│   │   └── IStateChangeRepository.cs
│   ├── UseCase/
│        ├── ControladorMovimiento.cs
│        └── StateChangeService.cs
│
├── Infrastructure/
│   ├── Services/
│   │   └── BinaryFileStateChangeRepository.cs
│   └── (Otros servicios de infraestructura)
│
├── Presentation/
│   ├── Controllers/
│   │   └── RobotController.cs
│   ├── Forms/
│   │   ├── Form1.cs
│   │   └── Form1.Designer.cs
│   └── Program.cs
│
├── App.config
└── README.md
```


## Uso de la Aplicación

### Interfaz de Usuario

La aplicación presenta una interfaz con los siguientes componentes:

- **Panel de Simulación**: Área donde se muestra la simulación gráfica del robot.
- **Botones de Sensores**:
  - **Sensor Izquierdo Blanco/Negro**: Simulan el estado del sensor izquierdo.
  - **Sensor Derecho Blanco/Negro**: Simulan el estado del sensor derecho.
- **Indicadores de Estado**:
  - **Estado del Sensor Izquierdo**: Muestra el estado actual (Blanco o Negro).
  - **Estado del Sensor Derecho**: Muestra el estado actual (Blanco o Negro).
  - **Acción Actual**: Indica la acción que el robot está realizando.
- **Búsqueda de Registros**:
  - **Fecha Desde** y **Fecha Hasta**: Permiten especificar un rango de fechas para buscar cambios de estado.
  - **Botón Buscar**: Inicia la búsqueda y muestra los resultados en una lista.

### Simulación del Robot

- **Auto Estático**: El auto se muestra en una posición fija dentro del panel de simulación.
- **Movimiento del Fondo**: El fondo se mueve en dirección opuesta a la acción del robot para simular el movimiento.
  - **Avanzar**: El fondo se mueve hacia abajo.
  - **Retroceder**: El fondo se mueve hacia arriba.
  - **Girar a la Izquierda**: El fondo se mueve hacia la derecha.
  - **Girar a la Derecha**: El fondo se mueve hacia la izquierda.

### Interacción con la Aplicación

1. **Simular Lecturas de Sensores**:

   - Presiona los botones correspondientes para cambiar el estado de los sensores.
   - Los estados posibles son **Blanco** y **Negro** para cada sensor.

2. **Observar las Acciones del Robot**:

   - La acción actual del robot se muestra en la etiqueta **Acción Actual**.
   - La simulación gráfica refleja la acción mediante el movimiento del fondo.

3. **Buscar Cambios de Estado**:

   - Selecciona un rango de fechas utilizando los controles **Fecha Desde** y **Fecha Hasta**.
   - Haz clic en **Buscar** para mostrar los registros de cambios de estado en la lista.

---

## Detalles Técnicos

### Simulación del Movimiento

- El movimiento se basa en los valores de los motores devueltos por la clase `Movimiento`.
- El `Timer_Tick` actualiza el desplazamiento del fondo utilizando las potencias y direcciones de los motores.
- La velocidad y dirección del movimiento se calculan en función de las configuraciones de los motores izquierdo y derecho.

### Registro de Cambios de Estado

- Cada vez que hay un cambio en los estados de los sensores, se crea un registro con la fecha/hora y los valores de los sensores.
- Los registros se almacenan en un archivo binario `mision.bin` utilizando la clase `BinaryFileStateChangeRepository`.
- El patrón **Repository** permite cambiar el mecanismo de persistencia fácilmente.

### Patrones Implementados

- **Observer**: La interfaz de usuario (`Form1`) se suscribe al `RobotController` y es notificada de los cambios, actualizando la interfaz en consecuencia.
- **Strategy**: El `ControladorMovimiento` determina las acciones del robot basadas en las lecturas de los sensores.
- **Repository**: El acceso a los datos se abstrae, permitiendo cambiar el almacenamiento sin afectar otras capas.

### Organización del Código

- **Domain**: Contiene las entidades fundamentales y las interfaces de observadores (`IObserver`, `ISubject`).
- **Application**: Define los casos de uso y lógica de negocio, incluyendo el `ControladorMovimiento` y el `StateChangeService`.
- **Infrastructure**: Implementa los detalles de persistencia con `BinaryFileStateChangeRepository`.
- **Presentation**: Contiene la interfaz de usuario (`Form1`), el controlador del robot y las interacciones con el usuario.
