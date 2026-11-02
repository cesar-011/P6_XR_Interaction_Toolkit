# Práctica 2: Realidad Virtual con XR Interaction Toolkit

**Autor:** César Navarro Santos
**Plataforma de Desarrollo:** Unity en Ubuntu (Linux)
**Plataforma Destino (Build):** Android (Meta Quest)

## Descripción del Proyecto
Este proyecto es una aplicación de Realidad Virtual desarrollada con el paquete **XR Interaction Toolkit** de Unity. El objetivo principal es configurar un entorno interactivo donde el usuario pueda desplazarse, agarrar objetos físicos e interactuar con elementos de la interfaz de usuario (UI), utilizando los estándares modernos de OpenXR.

## Entorno y Limitaciones de Hardware (Ubuntu)
Dado que el entorno de desarrollo es Ubuntu, no fue posible utilizar el *Meta XR Simulator* oficial, ya que es exclusivo de Windows. En su lugar, el proyecto se ha configurado, desarrollado y testeado íntegramente utilizando el **XR Device Simulator** genérico de Unity.
- Las físicas, agarres y teletransportes se han validado simulando los mandos (Quest Touch Controllers) a través de teclado y ratón en el simulador integrado.
- La falta de un visor físico Android durante el desarrollo no ha impedido la correcta configuración de los inputs y la compilación final del archivo `.apk`.

## Configuración del Proyecto (OpenXR)
Para asegurar que el APK final sea compatible con las gafas Meta Quest, se configuraron los siguientes perfiles en `Project Settings > XR Plug-in Management > OpenXR` (Pestaña Android):
- **Oculus Touch Controller Profile**
- **Meta Quest Touch Plus Controller Profile**
- **Hand Interaction Profile** (para soporte de seguimiento de manos).

Además, se actualizó el sistema de inputs (`Active Input Handling`) para utilizar el nuevo **Input System Package**, optimizando el rendimiento en Android y evitando conflictos en Gradle.

## Mecánicas Implementadas

### 1. Locomoción del Jugador
Se reemplazó la cámara estándar por un `XR Origin (VR)`. A este objeto principal se le añadieron los componentes **Locomotion Mediator** y **Teleportation Provider** para permitir el desplazamiento por el entorno virtual mediante los joysticks de los mandos.

### 2. Interacción Básica (Cambio de Color)
Se han colocado dos primitivas geométricas en la escena (un Cubo y una Esfera).
- Ambos objetos cuentan con el componente `XR Grab Interactable` y colisionadores.
- Se ha desarrollado el script `CambiarColor.cs`.
- **Funcionamiento:** Mediante los Eventos de Interacción (`Select Entered`), al apuntar y seleccionar el cubo o la esfera con el rayo del mando, el script accede al `MeshRenderer` del objeto y cambia su material a color rojo.

### 3. Interacción con Asset Externo y UI
Se ha integrado un objeto 3D importado de la Asset Store ([Nombre del asset original, ej: Cofre]).
- **Corrección de físicas:** Se activó la propiedad `Convex` en el `Mesh Collider` del objeto para permitir que el `Rigidbody` calcule correctamente las colisiones y repose sobre el plano sin atravesar el suelo.
- **UI Dinámica:** Se creó un Canvas con un texto (TextMeshPro) flotante.
- **Funcionamiento:** Se ha desarrollado el script `ActualizarUI.cs`. Al agarrar físicamente el objeto de la Asset Store (evento `Select Entered` del `XR Grab Interactable`), el script actualiza el texto en pantalla mostrando el mensaje: *"¡Objeto agarrado con éxito!"*.

## Demostración de Funcionamiento
A continuación se muestra una captura en movimiento (GIF) del simulador en acción, demostrando el movimiento de las manos, el cambio de color de las primitivas y la actualización de la UI al agarrar el objeto.

![Demostración del funcionamiento]
<img width="742" height="362" alt="p6" src="https://github.com/user-attachments/assets/b42cb34d-efb6-46d8-a9cc-6a67427f9151" />


---
*Nota: El archivo .apk adjunto a esta entrega ha sido compilado con éxito para Android tras resolver las dependencias del AndroidManifest (Tema y librerías AppCompat).*
